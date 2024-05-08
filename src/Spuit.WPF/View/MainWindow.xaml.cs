using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Spuit.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel ViewModel = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Set window themes to automatically match the system.
            // https://wpfui.lepo.co/documentation/themes.html#automatic-change
            SystemThemeWatcher.Watch(
                this,                    // Window class
                WindowBackdropType.Mica, // Background type
                true                     // Whether to change accents automatically
            );
        }
    }
}