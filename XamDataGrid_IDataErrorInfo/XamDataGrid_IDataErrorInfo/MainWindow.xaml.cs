using System.Windows;
using XamDataGrid_IDataErrorInfo.ViewModel;

namespace XamDataGrid_IDataErrorInfo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel vm = new MainViewModel();
            this.DataContext = vm;
        }
    }
}
