using System.ComponentModel;
using System.Configuration.Install;
using System.Management;
using System.Windows.Forms;

namespace ImportEqpuipment
{
    //    [RunInstaller(true)]
    //    public partial class ServiceInstaller : Installer
    //    {
    //        Timer t;
    //        Timer t1;
    //        // Запуск службы
    //        protected override void OnStart(string[] args)
    //        {

    //        }
    //        // Остановка службы
    //        protected override void OnStop()
    //        {
    //            t = null;
    //            t1 = null;
    //        }
    //    public ServiceInstaller()
    //    {
    //        InitializeComponent();
    //    }
    //    private void serviceProcessInstaller1_Committed(object sender, InstallEventArgs e)
    //    {
    //        string serviceName = "Lims_Eqp_Import";
    //        ManagementObjectSearcher ms = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE DisplayName = '" + serviceName + "'");
    //        foreach (ManagementObject mo in ms.Get())
    //        {
    //            ManagementBaseObject inParams = mo.GetMethodParameters("Change");
    //            inParams["DesktopInteract"] = true;
    //            mo.InvokeMethod("Change", inParams, null);
    //            break;
    //        }
    //        // устновка службы
    //        ManagedInstallerClass.InstallHelper(new[] { openFileDialog1.FileName });

    //        // удаление службы
    //        ManagedInstallerClass.InstallHelper(new[] { @"/u", openFileDialog.FileName });
}
    //}
//}
