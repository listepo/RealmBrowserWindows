using System.Windows;
using System.Reflection;
using Microsoft.Win32;
using Realms;

namespace RealmBrowserWindows
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
            AssemblyVersion.Content = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void OpenRealmFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? userClickedOK = openFileDialog.ShowDialog();
            if (userClickedOK == true) {
                var config = new RealmConfiguration(openFileDialog.FileName);
                // TODO: Required Dynamic = true https://github.com/realm/realm-dotnet/issues/778
                var realm = Realm.GetInstance(config);
            }
        }
    }
}
