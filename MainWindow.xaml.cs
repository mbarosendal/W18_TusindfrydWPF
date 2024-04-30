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

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FlowerSort> flowerSorts;
        public MainWindow()
        {
            InitializeComponent();

            flowerSorts = new List<FlowerSort>();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Et instans af det andet vindue, CreateFlowerSortsDialog.xaml.cs. (altså et instans af en xaml.cs!)
            CreateFlowerSortsDialog cfsDialog = new CreateFlowerSortsDialog();
            // ShowDialog() er en metode, som åbner det andet vindue, og venter på hvordan vinduet lukkes,
            // ShowDialog() returnerer så en nullable boolean (bool?), som angiver, hvordan vinduet blev lukket.
            // Hvis brugeren klikker på en knap, der er mærket med DialogResult-egenskaben som true (Det er OK-knappen her i programmet), vil ShowDialog() returnere true.
            // Hvis dialogboksen lukkes på en anden måde, f.eks.ved at klikke på krydset i dialogboksens titellinje eller ved at kalde Close() - metoden, vil ShowDialog() returnere false.
            bool? ShowDialogResult = cfsDialog.ShowDialog();

            if (ShowDialogResult == true)
            {
                flowerSorts.Add(cfsDialog.currentFlowerSort);
                // Opdater ListBox med den nye flowerSorts liste.
                lbFlowerSorts.ItemsSource = null; // Clear først ItemsSource, så den gamle list ikke vises også.
                lbFlowerSorts.ItemsSource = flowerSorts; // Sæt ItemsSource til den nye liste igen, så kun den nye liste, med det nye objekt, kommer med.
            }
        }

    }
}