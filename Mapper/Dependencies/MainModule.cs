using System;
using Ninject.Modules;

namespace Mapper.Dependencies
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>()
                .To<Mapper>()
                .InSingletonScope();

            Bind<IExtractProperties>()
                .To<ExtractProperties>()
                .InSingletonScope();
        }
    }
}