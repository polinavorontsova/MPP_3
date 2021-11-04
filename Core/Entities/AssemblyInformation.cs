using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core.Entities
{
    public class AssemblyInformation
    {
        public readonly IEnumerable<NamespaceInformation> Namespaces;

        public AssemblyInformation(string path)
        {
            Namespaces = ExtractAssemblyInformation(path)
                .Select(namespaceToTypesPair =>
                    new NamespaceInformation(namespaceToTypesPair.Key, namespaceToTypesPair.Value));
        }

        private static Dictionary<string, List<Type>> ExtractAssemblyInformation(string path)
        {
            var assembly = Assembly.LoadFrom(path);
            var types = GetLoadedAssemblyTypes(assembly);
            return GetNamespacesToTypesDictionary(types);
        }

        private static IEnumerable<Type> GetLoadedAssemblyTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null).ToArray();
            }
        }

        private static Dictionary<string, List<Type>> GetNamespacesToTypesDictionary(IEnumerable<Type> types)
        {
            var namespacesToClassesDictionary = new Dictionary<string, List<Type>>();
            foreach (var type in types)
            {
                var name = type.Namespace ?? "<>";
                if (!namespacesToClassesDictionary.ContainsKey(name))
                    namespacesToClassesDictionary.Add(name, new List<Type>());

                namespacesToClassesDictionary.TryGetValue(name, out var classes);
                classes?.Add(type);
            }

            return namespacesToClassesDictionary;
        }
    }
}