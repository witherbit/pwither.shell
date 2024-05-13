using pwither.shell.Abstract;
using pwither.shell.Objects;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IHost
    {
        private ShellController ShellController;
        private ShellBase Shell;
        private RevokeTokenInfo RevokeTokenInfo;
        public MainWindow()
        {
            InitializeComponent();
            ShellController = new ShellController();
            ShellController.LoadByPath(@"D:\_root\witherbit\_repos\pwither\pwither.shell\TestShell\bin\Debug\net8.0-windows7.0\TestShell.dll");
        }

        public object Providing => uiFrame;

        public object Invoke(params object[] parameters)
        {
            return null;
        }

        public void InvokeNative()
        {
            
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Shell = ShellController.RegisterShellByIndex(0, this);
            var store = ShellController.ContractStore.GetFromStore(Shell);
            RevokeTokenInfo = store.RevokeTokenInfo;
            Shell.Run();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShellController.ContractStore.Revoke(Shell);
        }
    }
}