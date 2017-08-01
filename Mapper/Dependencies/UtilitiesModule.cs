using System;
using Ninject.Modules;
using Mapper.Utilities;

namespace Mapper.Dependencies
{
    public class UtilitiesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDetermineThatPropertyIsUserDefined>()
                .To<DetermineThatPropertyIsUserDefined>()
                .InSingletonScope();
        }
    }
}
