using System.Reflection;

namespace Mapper.Utilities
{
    public class DetermineThatPropertyIsUserDefined : IDetermineThatPropertyIsUserDefined
    {
        public bool PropertyIsUserDefined(PropertyInfo propertyInfo)
        {
            return !string.Equals(propertyInfo.PropertyType.Assembly.GetName().Name, "mscorlib");
        }
    }
}