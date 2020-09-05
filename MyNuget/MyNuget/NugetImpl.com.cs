using System;
namespace MyNuget
{
    public static class NugetImpl
    {
        private static Lazy<NugetInterface> _feature = new Lazy<NugetInterface>(() => CreateTestNuget(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static NugetInterface CreateTestNuget()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
            return new NugetPlatformImpl();   //Modify the Implementation Class name name with yours
#endif

        }

        public static NugetInterface Feature
        {
            get
            {
                return _feature.Value == null ? throw new NotImplementedException("This Platform is Not Supported") : _feature.Value;
            }
        }
    }
}
