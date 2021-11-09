using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Core.Entities;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private const string TestAssemblyPath = "../../../Core.dll";

        private AssemblyInformation _assemblyInformation;

        [SetUp]
        public void Setup()
        {
            _assemblyInformation = new AssemblyInformation(TestAssemblyPath);
        }

        [Test]
        public void TestNamespacesSuccess()
        {
            var expectedNamespaceNames = new List<string>
            {
                "Core.Utilities",
                "Core.Entities"
            };
            const int expectedNamespacesCount = 2;

            Assert.AreEqual(expectedNamespacesCount, _assemblyInformation.Namespaces.Count());
            foreach (var expectedNamespaceName in expectedNamespaceNames)
            {
                Assert.Contains(expectedNamespaceName, _assemblyInformation.Namespaces
                    .Select(namespaceInfo => namespaceInfo.Name).ToImmutableList());
            }
        }

        [Test]
        public void TestClassesSuccess()
        {
            var expectedUtilityClassNames = new List<string>
            {
                "public CompilerUtilities",
                "public ModifierUtilities",
                "public TypeUtilities"
            };

            var expectedEntityClassNames = new List<string>
            {
                "public AssemblyInformation",
                "public ClassInformation",
                "public FieldInformation",
                "public MethodInformation",
                "public NamespaceInformation",
                "public PropertyInformation",
            };

            var utilityClasses = _assemblyInformation.Namespaces
                .First(information => information.Name.Equals("Core.Utilities"))
                .Classes;
            Assert.AreEqual(utilityClasses.Count(), 3);

            var entityClasses = _assemblyInformation.Namespaces
                .First(information => information.Name.Equals("Core.Entities"))
                .Classes;
            Assert.AreEqual(entityClasses.Count(), 6);

            foreach (var expectedUtilityClassName in expectedUtilityClassNames)
            {
                Assert.Contains(expectedUtilityClassName, utilityClasses
                    .Select(information => information.Name).ToImmutableList());
            }

            foreach (var expectedEntityClassName in expectedEntityClassNames)
            {
                Assert.Contains(expectedEntityClassName, entityClasses
                    .Select(information => information.Name).ToImmutableList());
            }
        }

        [Test]
        public void Test_FieldsSuccess()
        {
            var expectedFieldNames = new List<string>
            {
                "public readonly IEnumerable<FieldInformation> Fields",
                "public readonly IEnumerable<MethodInformation> Methods",
                "public readonly IEnumerable<PropertyInformation> Properties",
                "private static BindingFlags TypeBindingFlags",
            };
            const int expectedFieldsCount = 4;

            var classInformation = _assemblyInformation.Namespaces
                .First(information => information.Name.Equals("Core.Entities")).Classes
                .First(classInformation => classInformation.Name.Equals("public ClassInformation"));

            Assert.AreEqual(expectedFieldsCount, classInformation.Fields.Count());
            foreach (var expectedFieldName in expectedFieldNames)
            {
                Assert.Contains(expectedFieldName, classInformation.Fields
                    .Select(field => field.Name).ToImmutableList());
            }
        }

        [Test]
        public void Test_PropertiesSuccess()
        {
            var expectedPropertyNames = new List<string>
            {
                "String Name { public get; private set; }",
            };
            const int expectedPropertiesCount = 1;

            var classInformation = _assemblyInformation.Namespaces
                .First(information => information.Name.Equals("Core.Entities")).Classes
                .First(classInformation => classInformation.Name.Equals("public ClassInformation"));

            Assert.AreEqual(expectedPropertiesCount, classInformation.Properties.Count());
            foreach (var expectedPropertyName in expectedPropertyNames)
            {
                Assert.Contains(expectedPropertyName, classInformation.Properties
                    .Select(field => field.Name).ToImmutableList());
            }
        }

        [Test]
        public void Test_MethodsSuccess()
        {
            var expectedMethodNames = new List<string>
            {
                "private static IEnumerable<PropertyInformation> GetProperties(IEnumerable<MemberInfo> members)",
                "private static IEnumerable<FieldInformation> GetFields(IEnumerable<MemberInfo> members)",
                "private static IEnumerable<MethodInformation> GetMethods(IEnumerable<MemberInfo> members)",
            };
            const int expectedMethodsCount = 3;

            var classInformation = _assemblyInformation.Namespaces
                .First(information => information.Name.Equals("Core.Entities")).Classes
                .First(classInformation => classInformation.Name.Equals("public ClassInformation"));

            Assert.AreEqual(expectedMethodsCount, classInformation.Methods.Count());
            foreach (var expectedMethodName in expectedMethodNames)
            {
                Assert.Contains(expectedMethodName, classInformation.Methods
                    .Select(method => method.Name).ToImmutableList());
            }
        }
    }
}