using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class NamespaceInformation
    {
        public readonly string Name;

        public NamespaceInformation(string space, IEnumerable<Type> types)
        {
            Name = space;
        }
    }
}