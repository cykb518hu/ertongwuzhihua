using ICCA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ICCA.Interface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Service service = new Service();
            //service.Test();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                  new Service()
             };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
