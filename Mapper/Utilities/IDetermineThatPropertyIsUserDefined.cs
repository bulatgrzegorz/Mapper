using System.Reflection;

namespace Mapper.Utilities
{
    public interface IDetermineThatPropertyIsUserDefined
    {
        bool PropertyIsUserDefined(PropertyInfo propertyInfo);
    }
}
