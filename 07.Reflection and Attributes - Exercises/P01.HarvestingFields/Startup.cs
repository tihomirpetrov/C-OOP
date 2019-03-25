namespace P01.HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);

            string commmand = Console.ReadLine();

            while (commmand != "HARVEST")
            {
                IEnumerable<FieldInfo> fields = null;

                switch (commmand)
                {
                    case "private":
                        fields = GetPrivateFields(classType);
                        break;
                    case "protected":
                        fields = GetProtectedFields(classType);
                        break;
                    case "public":
                        fields = GetPublicFields(classType);
                        break;
                    case "all":
                        fields = GetAllFields(classType);
                        break;
                }

                foreach (var field in fields)
                {
                    string accessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected";
                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }

                commmand = Console.ReadLine();
            }
        }
        private static IEnumerable<FieldInfo> GetAllFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        }

        private static IEnumerable<FieldInfo> GetPublicFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        }

        private static IEnumerable<FieldInfo> GetProtectedFields(Type classType)
        {
            return classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.IsFamily);
        }

        private static IEnumerable<FieldInfo> GetPrivateFields(Type classType)
        {
            return classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.IsPrivate);
        }
    }
}