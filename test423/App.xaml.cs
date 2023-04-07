using System.Windows;
using Wpf.CartesianChart.SolidColorChart;

namespace ExampleGraph
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SolidColorExample viewModel = new SolidColorExample();
            SolidColorExample mainWindow = new SolidColorExample();
            
            
        }
    }
}
