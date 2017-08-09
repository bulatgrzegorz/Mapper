using System;
using System.Collections.Generic;
using System.Linq;
using Mapper.Utilities;
using Moq;
using NUnit.Framework;

namespace Mapper.Tests.ExtractProperties
{
    [TestFixture]
    public class ExtractPropertiesTests
    {
        private Extractings.ExtractProperties _extractProperties;

        private IDetermineThatPropertyIsUserDefined _determineThatPropertyIsUserDefined;

        [SetUp]
        public void SetUp()
        {
            _determineThatPropertyIsUserDefined = new DetermineThatPropertyIsUserDefined();

            _extractProperties = new Extractings.ExtractProperties(
                _determineThatPropertyIsUserDefined);
        }

        [Test]
        public void ExtractPropertiesForType_Check_That_Every_Property_Without_User_Defiend_One_Is_Collected()
        {
            var firstExpectedProperty = new PropertyOfEntity() { PropertyName = "Typ14", PropertyType = typeof(Type) };
            var secondExpectedProperty = new PropertyOfEntity() { PropertyName = "Lista", PropertyType = typeof(List<string>) };

            var returnedProperties = _extractProperties.ExtractPropertiesForType<SampleEntity3>();

            var returnedPropertiesAsArray = returnedProperties.Properties.ToArray();

            Assert.That(returnedPropertiesAsArray[0].PropertyName, Is.EqualTo(firstExpectedProperty.PropertyName));
            Assert.That(returnedPropertiesAsArray[0].PropertyType, Is.EqualTo(firstExpectedProperty.PropertyType));
            Assert.That(returnedPropertiesAsArray[1].PropertyName, Is.EqualTo(secondExpectedProperty.PropertyName));
            Assert.That(returnedPropertiesAsArray[1].PropertyType, Is.EqualTo(secondExpectedProperty.PropertyType));
        }

        [Test]
        public void ExtractPropertiesForType_Check_That_Properties_Are_Collected_With_Child_Propertiies()
        {
            var sampleEntity2Int = new PropertyOfEntity() { PropertyName = "Int13", PropertyType = typeof(int) };
            var sampleEntity2String = new PropertyOfEntity() { PropertyName = "String13", PropertyType = typeof(string) };
            var sampleEntity2SampleEntity3 = new PropertyOfEntity() { PropertyName = "Sample3", PropertyType = typeof(SampleEntity3) };

            var sampleEntity3Type = new PropertyOfEntity() { PropertyName = "Typ14", PropertyType = typeof(Type) };
            var sampleEntity3List = new PropertyOfEntity() { PropertyName = "Lista", PropertyType = typeof(List<string>) };

            var returnedProperties = _extractProperties.ExtractPropertiesForType<SampleEntity2>();

            var returnedPropertiesAsArray = returnedProperties.Properties.ToArray();

            Assert.That(returnedPropertiesAsArray[0].PropertyName, Is.EqualTo(sampleEntity2Int.PropertyName));
            Assert.That(returnedPropertiesAsArray[0].PropertyType, Is.EqualTo(sampleEntity2Int.PropertyType));
            Assert.That(returnedPropertiesAsArray[1].PropertyName, Is.EqualTo(sampleEntity2String.PropertyName));
            Assert.That(returnedPropertiesAsArray[1].PropertyType, Is.EqualTo(sampleEntity2String.PropertyType));
            Assert.That(returnedPropertiesAsArray[2].PropertyName, Is.EqualTo(sampleEntity3Type.PropertyName));
            Assert.That(returnedPropertiesAsArray[2].PropertyType, Is.EqualTo(sampleEntity3Type.PropertyType));
            Assert.That(returnedPropertiesAsArray[3].PropertyName, Is.EqualTo(sampleEntity3List.PropertyName));
            Assert.That(returnedPropertiesAsArray[3].PropertyType, Is.EqualTo(sampleEntity3List.PropertyType));
            Assert.That(returnedPropertiesAsArray[4].PropertyName, Is.EqualTo(sampleEntity2SampleEntity3.PropertyName));
            Assert.That(returnedPropertiesAsArray[4].PropertyType, Is.EqualTo(sampleEntity2SampleEntity3.PropertyType));
        }

        public class SampleEntity
        {
            public int Int12 { get; set; } = 5;

            public string String123 { get; set; } = "12";

            public Type Type12 { get; set; } = typeof(int);

            public SampleEntity2 Sapmple { get; set; }
        }

        public class SampleEntity2
        {
            public int Int13 { get; set; } = 6;

            public string String13 { get; set; } = "13";

            public int Int15 = 1;

            public SampleEntity3 Sample3 { get; set; }
        }

        public class SampleEntity3
        {
            public Type Typ14 { get; set; } = typeof(bool);

            public List<string> Lista { get; set; } = new List<string> { "dead", "deadddd" };
        }
    }
}