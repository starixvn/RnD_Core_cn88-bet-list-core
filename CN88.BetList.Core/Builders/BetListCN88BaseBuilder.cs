namespace CN88.BetList.Core.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Caching;
    using System.Web.Compilation;
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using CN88.BetList.Core.Mappers;

    public class BetListCN88BaseBuilder : IBetListCN88BaseBuilder
    {
        private const string ChoiceBuilderNamespace = "CN88.BetList.Core.Builders.ChoiceBuilders";
        private const string BetInfoBuilderNamespace = "CN88.BetList.Core.Builders.BetInfoBuilders";
        private const string CacheKey = "CN88.BetList.Core.CacheKey";

        private readonly ObjectCache cache;
        private readonly CacheItemPolicy cachePolicy;

        private const string ChoiceName = ".ChoiceCN";
        private const string BetInfoName = ".BetInfoCN";

        public BetListCN88BaseBuilder()
        {
            cache = MemoryCache.Default;
            cachePolicy = new CacheItemPolicy();
            cachePolicy.Priority = CacheItemPriority.NotRemovable;

            var assemblies = GetBetListAssemblies();
            MapperCN88Collector.CollectAllMapperData(assemblies);
        }

        public IChoiceCN88 CreateChoiceBuilder(int betType)
        {
            var betTypeId = betType;

            betTypeId = MapperCN88Collector.GetChoiceBaseBetTypeOf(betTypeId);

            string typeName = string.Join(null, new[] { ChoiceBuilderNamespace, ChoiceName, betTypeId.ToString().Replace('-', '_') });

            return CreateInstance<IChoiceCN88, BaseChoiceCN88>(typeName);
        }

        public IBetInfoCN88 CreateBetInfoBuilder(int betType)
        {
            var betTypeId = betType;

            betTypeId = MapperCN88Collector.GetBetInfoBaseBetTypeOf(betTypeId);
            string typeName = string.Join(null, new[] { BetInfoBuilderNamespace, BetInfoName, betTypeId.ToString().Replace('-', '_') });

            return CreateInstance<IBetInfoCN88, BaseBetInfoCN88>(typeName);
        }

        private T CreateInstance<T, TDefault>(string typeName)
            where TDefault : T, new()
        {
            T instance;
            Type type = GetBetListAssemblies(typeName);

            if (type == null)
            {
                instance = new TDefault();
            }
            else
            {
                instance = (T)Activator.CreateInstance(type);
            }

            cache.Set(typeName, instance.GetType(), cachePolicy);

            return instance;
        }

        private List<Assembly> GetBetListAssemblies()
        {
            var assemblies = (List<Assembly>)cache[CacheKey];

            if (assemblies == null || !assemblies.Any())
            {
                try
                {
                    assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
                }
                catch
                {
                    assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
                }

                assemblies = assemblies.Where(x => x.FullName.StartsWith("CN88.BetList.", StringComparison.InvariantCulture)).ToList();

                cache.Set(CacheKey, assemblies, cachePolicy);
            }

            return assemblies;
        }

        private Type GetType(string typeName, List<Assembly> assemblies)
        {
            var type = (Type)cache[typeName];

            if (type == null)
            {
                foreach (var assembly in assemblies)
                {
                    type = Type.GetType(typeName + ", " + assembly);

                    if (type != null)
                    {
                        return type;
                    }
                }
            }

            return type;
        }

        private Type GetBetListAssemblies(string typeName)
        {
            var assemblies = GetBetListAssemblies();

            return GetType(typeName, assemblies);
        }
    }
}
