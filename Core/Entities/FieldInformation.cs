using System.Reflection;
using Core.Utilities;

namespace Core.Entities
{
    public class FieldInformation
    {
        public readonly string Name;

        public FieldInformation(FieldInfo field)
        {
            Name =
                $"{ModifierUtilities.GetFieldModifiers(field)}{TypeUtilities.GetName(field.FieldType)} {field.Name}";
        }
    }
}