using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class PropertyOfEntity
    {
        public PropertyOfEntity(string propertyName, Type propertyType, dynamic propertyValue, PropertyInfo propertyinfo)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
            PropertyValue = propertyValue;
            PropertyFullInfo = propertyinfo;
        }

        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
        public dynamic PropertyValue { get; set; }
        public PropertyInfo PropertyFullInfo { get; set; }
        public PropertyOfEntity PropertyParent { get; set; }
    }
}