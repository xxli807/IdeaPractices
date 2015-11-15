using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;


namespace AddSubtractMultiplyDivideFractions.Service
{
    public static class IOC
    {
        public static StandardKernel standKernel = new StandardKernel();

        public static void InitDI()
        {
            standKernel.Bind<IOperation>().To<OperationService>();
        }


        public static StandardKernel GetStandardKernel()
        {
            return standKernel;
        }
    }
}
