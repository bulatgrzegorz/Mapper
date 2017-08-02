using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new Ninject.NinjectKernel(Ninject.NinjectKernel.GetAllModules().ToArray());

            var dea = kernel.Get<IExtractProperties>();

            var sample = new SampleEntity();

            var list = dea.ExtractPropertiesForType<SampleEntity>();
        }
    }
}