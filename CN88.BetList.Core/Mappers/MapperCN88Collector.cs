namespace CN88.BetList.Core.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Caching;
    using Fanex.BetList.Core.Mapper;

    public static class MapperCN88Collector
    {
        private const string BetListMapperNamespace = "CN88.BetList.Core.Mappers.{0}Mapper";

        private const string CacheKey = "CN88.BetList.Core.Mappers.{0}";
        private const string Choice = "ChoiceCN88";
        private const string BetInfo = "BetInfoCN88";
        private const string ParentChild = "ParentChildCN88";

        private static ObjectCache cache = MemoryCache.Default;
        private static object locker = new object();

        public static void CollectAllMapperData(IList<Assembly> assemblies)
        {
            lock (locker)
            {
                if (!CacheHasMapperData())
                {
                    CollectAndCacheMapperData(assemblies);
                }
            }
        }

        public static int GetChoiceBaseBetTypeOf(int betTypeId)
        {
            var choiceMapper = (IDictionary<int, int>)cache[string.Format(CacheKey, Choice)];

            return (choiceMapper != null && choiceMapper.ContainsKey(betTypeId))
                ? choiceMapper[betTypeId]
                : betTypeId;
        }

        public static int GetBetInfoBaseBetTypeOf(int betTypeId)
        {
            var betInfoMapper = (IDictionary<int, int>)cache[string.Format(CacheKey, BetInfo)];

            return (betInfoMapper != null && betInfoMapper.ContainsKey(betTypeId))
                ? betInfoMapper[betTypeId]
                : betTypeId;
        }

        public static int GetParentBetTypeOf(int betTypeId)
        {
            var parentChildMapper = (IDictionary<int, int>)cache[string.Format(CacheKey, ParentChild)];

            return (parentChildMapper != null && parentChildMapper.ContainsKey(betTypeId)) ? parentChildMapper[betTypeId] : betTypeId;
        }

        private static bool CacheHasMapperData()
            => (IDictionary<int, int>)cache[string.Format(CacheKey, Choice)] != null
                || (IDictionary<int, int>)cache[string.Format(CacheKey, BetInfo)] != null
                || (IDictionary<int, int>)cache[string.Format(CacheKey, ParentChild)] != null;

        private static void CollectAndCacheMapperData(IList<Assembly> assemblies)
        {
            var choiceMapperData = CollectMapperDataOf(Choice, assemblies);
            var parentChildMapperData = CollectMapperDataOf(ParentChild, assemblies);
            var betInfoMapperData = CollectMapperDataOf(BetInfo, assemblies);

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.NotRemovable;

            cache.Set(string.Format(CacheKey, Choice), choiceMapperData, policy);
            cache.Set(string.Format(CacheKey, BetInfo), betInfoMapperData, policy);
            cache.Set(string.Format(CacheKey, ParentChild), parentChildMapperData, policy);
        }

        private static IDictionary<int, int> CollectMapperDataOf(string componentName, IList<Assembly> assemblies)
        {
            string typeName = string.Join(null, new[] { string.Format(BetListMapperNamespace, componentName) });

            IDictionary<int, int> mapperData = new Dictionary<int, int>();

            foreach (var assembly in assemblies)
            {
                Type type = Type.GetType(typeName + ", " + assembly);

                if (type != null)
                {
                    IMapper mapper = Activator.CreateInstance(type) as IMapper;

                    mapperData = AddDataFromMapperObj(mapper, mapperData);
                }
            }

            return mapperData;
        }

        private static IDictionary<int, int> AddDataFromMapperObj(IMapper mapper, IDictionary<int, int> mapperData)
        {
            var combineMapperData = mapperData.Concat(mapper.MapperData.Where(item => !mapperData.Keys.Contains(item.Key))).ToDictionary(pair => pair.Key, pair => pair.Value);

            return combineMapperData;
        }
    }
}