using System;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities;

namespace Core.Entities
{
    public class NamespaceInformation
    {
        public readonly IEnumerable<ClassInformation> Classes;
        public readonly string Name;

        public NamespaceInformation(string space, IEnumerable<Type> types)
        {
            Name = space;
            Classes = types.Where(type => !CompilerUtilities.IsCompilerGenerated(type))
                .Select(type => new ClassInformation(type));
        }
    }
}