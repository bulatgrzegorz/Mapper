using System.Collections.Generic;

namespace Mapper
{
    public interface IExtractProperties
    {
        Property ExtractPropertiesForType<T>();

        Property ExtractPropertiesForType<T>(T entity);
    }
}