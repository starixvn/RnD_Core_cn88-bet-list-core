namespace Fanex.BetList.Example.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;
    using CN88.BetList.Core.Builders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.TicketHelper;
    using Fanex.BetList.Example.Extension.BetListExcelBuilderExt;
    using Fanex.BetList.Example.MVC.Models;
    using Fanex.BetList.Example.MVC.Services;
    using Fanex.BetList.Example.MVC.ViewModel;

    public class BetListCN88Controller : Controller
    {
        private readonly DataService dataService;
        private const string DefaultLanguage = "en-US";

        public BetListCN88Controller()
        {
            dataService = new DataService();
        }

        private string DataSourcePath
        {
            get { return Session["DataSourcePath"].ToString(); }
            set { Session["DataSourcePath"] = value; }
        }

        public ActionResult Sportsbook(BetListData model = null)
        {
            var betTypes = dataService.QueryBetTypes();
            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/CN88/Sportsbook.xls";
#pragma warning disable S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
            model = GetDataSource(model, sourcePath: DataSourcePath);
#pragma warning restore S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
            model.DataFilePath = DataSourcePath;

            return View(model);
        }

        public ActionResult NonSports(BetListData model = null)
        {
            var betTypes = dataService.QueryCN88NonSportsBetTypes();
            ViewBag.BetTypes = CreateSelectListItem(betTypes);
            DataSourcePath = "~/App_Data/CN88/NonSports.xls";
#pragma warning disable S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
            model = GetDataSource(model, sourcePath: DataSourcePath);
#pragma warning restore S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
            model.DataFilePath = DataSourcePath;

            return View(model);
        }

        private BetListData GetDataSource(BetListData model, string sourcePath)
        {
            if (model != null
                && !string.IsNullOrWhiteSpace(model.Language) && model.Language != DefaultLanguage)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(model.Language);
            }

            BetListData betListData = dataService.GetBetListData(sourcePath, model.BetTypeId);

            // check whether request filter by bet type id, and does not contain select all
            if (model.BetTypeId != 0)
            {
                model.Tickets = betListData
                    .Tickets
                    .Where(ticket => model.BetTypeId == ticket.BetTypeId)
                    .Select(ticket => ticket)
                    .ToList();

                model.TicketData = betListData
                  .TicketData
                  .Where(ticketData => model.BetTypeId == ticketData.BetTypeId)
                  .Select(ticket => ticket)
                  .ToList();

                model.TicketData = model.TicketData ?? new List<ITicketData>();
                model.Tickets = model.Tickets ?? new List<ITicket>();
            }
            else
            {
                model.TicketData = betListData.TicketData ?? new List<ITicketData>();
                model.Tickets = betListData.Tickets ?? new List<ITicket>();
            }

            return model;
        }

        private IEnumerable<SelectListItem> CreateSelectListItem(IEnumerable<BetType> betTypes)
        {
            return betTypes.Select(betType => new SelectListItem { Text = betType.Name, Value = betType.Id.ToString() });
        }

        public void ExportExcel(BetListData query)
        {
            var builder = new BetListCN88ExcelBuilder();
            ITicketHelper ticketHelper = new TicketHelper();
            Func<object, string> funcGetOddsTypeName = ticketHelper.GetOddsTypeNameById;
            const short excelColumns = 3;
            builder.BuildWorksheet("BetList", excelColumns);
            var index = 0;

            var model = GetDataSource(query, sourcePath: DataSourcePath);
            var tickets = model.Tickets;
            var ticketData = model.TicketData;

            if (tickets != null)
            {
                foreach (ITicket ticket in tickets)
                {
                    index++;
                    ticketHelper.Index = index;

                    builder
                        .AddNo(index)
                        .AddBetInfo(ticket, ticketHelper, funcGetOddsTypeName)
                        .AddChoice(ticket, ticketHelper, ticketData);
                }

                var ms = new MemoryStream();
                var resultWorkbook = builder.GetBetList();
                resultWorkbook.Write(ms);
                ExportToExcel(ms, "BetList.xls");
            }
        }

        private void ExportToExcel(MemoryStream excelStream, string fileName)
        {
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            Response.Clear();
            Response.BinaryWrite(excelStream.GetBuffer());
            Response.End();
        }

        public void DownloadExcelFile(string dataFilePath)
        {
            FileInfo file = new FileInfo(Server.MapPath(dataFilePath));

            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Type", "application/Excel");
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }
    }
}
