using Mapper.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mapper.Tests1.Utilities
{
    [TestFixture]
    public class DetemineThatPropertyIsUserDefinedTests
    {
        private DetermineThatPropertyIsUserDefined _determineThatPropertyIsUserDefined;

        [SetUp]
        public void SetUp()
        {
            _determineThatPropertyIsUserDefined = new DetermineThatPropertyIsUserDefined();
        }

        [Test]
        public void PropertyIsUserDefined_Check_That_Returning_False_For_Property_From_Mscorlib_assembly()
        {
            var testClass = new TestClass();

            PropertyInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.TestInt));

            var isUserDefined = _determineThatPropertyIsUserDefined.PropertyIsUserDefined(propertyInfo);

            Assert.That(propertyInfo.PropertyType.Assembly.GetName().Name, Is.EqualTo("mscorlib"));
            Assert.That(!isUserDefined);
        }

        [Test]
        public void PropertyIsUserDefined_Check_That_Returning_True_For_Property_From_Mscorlib_assembly()
        {
            var testClass = new TestClass();

            PropertyInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestInnerClass));

            var isUserDefined = _determineThatPropertyIsUserDefined.PropertyIsUserDefined(propertyInfo);

            Assert.That(propertyInfo.PropertyType.Assembly.GetName().Name, Is.Not.EqualTo("mscorlib"));
            Assert.That(isUserDefined);
        }

        private class TestClass
        {
            public int TestInt { get; set; }

            public TestInnerClass TestInnerClass { get; set; }
        }

        private class TestInnerClass
        {
        }
    }
}