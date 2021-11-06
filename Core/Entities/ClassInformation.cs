using System;
using System.Reflection;
using Core.Utilities;

namespace Core.Entities
{
    public class ClassInformation
    {
        private const BindingFlags TypeBindingFlags =
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static |
            BindingFlags.Instance | BindingFlags.DeclaredOnly;

        public readonly string Name;

        public ClassInformation(Type type)
        {
            Name = $"{ModifierUtilities.GetClassModifiers(type)}{TypeUtilities.GetName(type)}";
        }
    }
}