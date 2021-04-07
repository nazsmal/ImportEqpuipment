using System;
using System.Windows.Forms;
using ImportEquipment;
using System.ServiceProcess;

namespace Import_Eqp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
              new ImportEqpuipment.MainService()
            };
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
