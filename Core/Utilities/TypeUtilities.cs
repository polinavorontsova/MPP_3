using System;

namespace Core.Utilities
{
    public class TypeUtilities
    {
        public static string GetName(Type type)
        {
            return type.IsGenericType ? GetGenericName(type) : type.Name;
        }

        private static string GetGenericName(Type type)
        {
            var typeName = "";
            var temp = type.GetGenericTypeDefinition().Name;
            var ind = temp.LastIndexOf('`');
            typeName += temp.Substring(0, ind) + "<";
            var argumentTypes = type.GetGenericArguments();
            foreach (var argumentType in argumentTypes)
                if (argumentType.IsGenericType)
                    typeName += GetName(argumentType) + ", ";
                else
                    typeName += argumentType.Name + ", ";

            typeName = typeName.Substring(0, typeName.Length - 2) + ">";
            return typeName;
        }
    }
}