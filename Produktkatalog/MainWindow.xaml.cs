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
using Produktkatalog.ViewModel;

namespace Produktkatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mvvm;
        public MainWindow()
        {
            _mvvm = new MainWindowViewModel(); //hier initialisiert 
            DataContext = _mvvm; // Hier der DATAContext hinzugefügt 

            InitializeComponent();

        }
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            // Wenn der Expander geöffnet ist, wird die Höhe der ersten Zeile auf "Auto" gesetzt, sodass sie sich an den Inhalt anpasst.
            Grid.SetRowSpan(Expander, 2); 
            // Expander spannt über beide Zeilen
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            // Wenn der Expander geschlossen ist, wird die Höhe der ersten Zeile wieder auf Auto gesetzt
            Grid.SetRowSpan(Expander, 1); // Expander nimmt nur die erste Zeile ein
        }
    }
}