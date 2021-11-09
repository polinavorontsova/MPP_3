using System.Reflection;
using Core.Utilities;

namespace Core.Entities
{
    public class PropertyInformation
    {
        public readonly string Name;

        public PropertyInformation(PropertyInfo property)
        {
            Name =
                $"{TypeUtilities.GetName(property.PropertyType)} {property.Name} {{ {ModifierUtilities.GetPropertyModifiers(property)} }}";
        }
    }
}