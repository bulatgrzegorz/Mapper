using Ninject;
using System.Linq;
using Mapper.Extractings;

namespace Mapper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new Ninject.NinjectKernel(Ninject.NinjectKernel.GetAllModules().ToArray());

            var dea = kernel.Get<IExtractProperties>();
        }
    }
}