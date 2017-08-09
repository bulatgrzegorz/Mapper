namespace Mapper.Extractings
{
    public interface IExtractProperties
    {
        Property ExtractPropertiesForType<T>();

        Property ExtractPropertiesForType<T>(T entity);
    }
}