using System.Collections.Generic;
using System.Linq;

namespace Mapper
{
    public class Property
    {
        public IEnumerable<PropertyOfEntity> Properties { get; set; }

        public IEnumerable<PropertyOfEntity> FlatProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}