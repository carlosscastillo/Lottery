using System.Configuration;
using System.Data;
using System.Windows;

namespace Lottery.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var langCode = Lottery.UI.Properties.Settings.Default.languageCode;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(langCode);

            base.OnStartup(e);
        }
    }

}
