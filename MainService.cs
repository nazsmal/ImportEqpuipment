using System.ServiceProcess;


namespace ImportEqpuipment
{
    //https://msdn.microsoft.com/ru-ru/library/vstudio/zt39148a%28v=vs.110%29.aspx
    //installutil.exe Service.exe

    /// <summary> Запуск службы </summary>
    public partial class MainService : ServiceBase
    {
        LogFile file;
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            file = new LogFile();

            file.Write("OnStart");
        }

        protected override void OnStop()
        {
            file.Write("OnStop");

            file.Dispose();
        }
    }
}
