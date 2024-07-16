using ShippingSystem.Domain.Enums;

namespace ShippingSystem.Shared
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            var list = new List<string>()
            {
                $"{module}.Create.1",
                $"{module}.Update.2",
                $"{module}.View.3",
                $"{module}.Delete.4"
            };
            list.Add($"PermissionsForRole.Create.1");
            list.Add($"PermissionsForRole.View.3");

            return list;
        }
        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();
            var modules = Enum.GetValues(typeof(PermissionsTypes));
            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));
            return allPermissions;
        }
    }
}
