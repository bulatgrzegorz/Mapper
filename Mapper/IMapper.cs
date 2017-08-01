namespace Mapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source);
    }
}