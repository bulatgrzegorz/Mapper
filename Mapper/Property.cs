using System.Collections.Generic;

namespace Mapper
{
    public class Property
    {
        public IEnumerable<PropertyOfEntity> Properties { get; set; }

        public IEnumerable<PropertyOfEntity> FlatProperties => Properties;
    }
}