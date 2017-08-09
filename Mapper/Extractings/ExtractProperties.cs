using System;
using System.Collections.Generic;
using System.Reflection;
using Mapper.Utilities;

namespace Mapper.Extractings
{
    public class ExtractProperties : IExtractProperties
    {
        private readonly IDetermineThatPropertyIsUserDefined _determineThatPropertyIsUserDefined;

        public ExtractProperties(
            IDetermineThatPropertyIsUserDefined determineThatPropertyIsUserDefined)
        {
            _determineThatPropertyIsUserDefined = determineThatPropertyIsUserDefined;
        }

        public Property ExtractPropertiesForType<T>()
        {
            return new Property() { Properties = ExtractPropertiesBaseOnType(typeof(T), null) };
        }

        public Property ExtractPropertiesForType<T>(T entity)
        {
            return new Property() { Properties = ExtractPropertiesBaseOnType(typeof(T), entity) };
        }

        private IEnumerable<PropertyOfEntity> ExtractPropertiesBaseOnType(Type typeOfEntity, object entity)
        {
            var propertiesInfo = new List<PropertyInfo>(typeOfEntity.GetProperties());

            foreach (var prop in propertiesInfo)
            {
                var propertyOfEntity = new PropertyOfEntity(prop.Name, prop.PropertyType, entity == null ? null : prop.GetValue(entity), prop);

                if (_determineThatPropertyIsUserDefined.PropertyIsUserDefined(propertyOfEntity.PropertyFullInfo))
                {
                    foreach (PropertyOfEntity innerProperty in ExtractPropertiesBaseOnType(propertyOfEntity.PropertyType, propertyOfEntity.PropertyValue))
                    {
                        yield return innerProperty;
                    }
                }
                yield return propertyOfEntity;
            }
        }
    }
}