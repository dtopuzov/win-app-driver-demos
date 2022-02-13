using Framework;
using Framework.Settings;
using Framework.Utils;
using OpenQA.Selenium;

namespace OpenEdge
{
    public class Prowin : App
    {
        public Prowin(AppSettings settings) : base(settings) { }

        public void OpenApplicationMenuItem(string item)
        {
            Click(By.Name(item));
        }

        public override void Stop()
        {
            base.Stop();
            Processes.KillByName("prowin");
        }
    }
}
