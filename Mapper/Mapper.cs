using Mapper.Extractings;

namespace Mapper
{
    public class Mapper : IMapper
    {
        private readonly IExtractProperties _extractProperties;

        public Mapper(
            IExtractProperties extractProperties)
        {
            _extractProperties = extractProperties;
        }

        public TDestination Map<TDestination, TSource>(TSource source)
        {
            var destinationProperties = _extractProperties.ExtractPropertiesForType<TDestination>();
            var sourceProperties = _extractProperties.ExtractPropertiesForType(source);

            return default(TDestination);
        }
    }
}