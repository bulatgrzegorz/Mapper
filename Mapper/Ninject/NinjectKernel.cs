using Ninject;
using Ninject.Modules;
using System.Collections.Generic;
using Mapper.Dependencies;

namespace Mapper.Ninject
{
    public class NinjectKernel : StandardKernel
    {
        public static IEnumerable<INinjectModule> GetAllModules()
        {
            yield return new MainModule();
            yield return new UtilitiesModule();
        }

        public NinjectKernel(params INinjectModule[] modules) : base(modules)
        {
        }
    }
}