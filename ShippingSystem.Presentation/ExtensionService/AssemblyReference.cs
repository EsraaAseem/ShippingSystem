using System.Reflection;


namespace ShippingSystem.Presentation.ExtensionService
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
