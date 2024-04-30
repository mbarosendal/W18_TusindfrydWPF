using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortsDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortsDialog : Window
    {
        // Til at holde FlowerSort-objektet, der laves ud fra bruger input.
        private FlowerSort flowerSort;
        // Til at holde FlowerSort-objektet, der laves ud fra bruger input, og som kan bruges uden for klassen (public!).
        public FlowerSort currentFlowerSort;

        public CreateFlowerSortsDialog()
        {
            InitializeComponent();

            flowerSort = new FlowerSort();

            // Øvelse 5.6: sæt den her til true for at teste, og se txt_TextChanged-eventen på linje 82.
            //btnOK.IsEnabled = false;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            TrySetFlowerSortProperties();
        }

        private void TrySetFlowerSortProperties()
        {
            try
            {
                if (IsAllInfoFilled())
                {
                    flowerSort.Name = txtNavn.Text;
                    flowerSort.PicturePath = txtBillede.Text;
                    flowerSort.ProductionTime = int.Parse(txtProdtid.Text);
                    flowerSort.HalfLifeTime = int.Parse(txtHalvtid.Text);
                    flowerSort.Size = int.Parse(txtStørrelse.Text);
                    currentFlowerSort = flowerSort;
                    DialogResult = true;
                }
                else
                {
                    lblMessage.Content = "Udfyld alle værdier.";
                }
            }
            catch (Exception)
            {
                lblMessage.Content = "Ukorrekt værdi indtastet.";
            }
        }

        private bool IsAllInfoFilled()
        {
            if (txtNavn.Text != "" && txtBillede.Text != "" && txtProdtid.Text != "" && txtHalvtid.Text != "" && txtStørrelse.Text != "")
                return true; 
            else 
                return false;
        }

        private void btnFortryd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            // En metode fra ShowDialog() (linje 34 i MainWindow.xaml.cs), den gør det samme som this.Close().
        }

        // Øvelse 5.6: Tjek om alle tekstbokse har indhold, før OK-knappen gøres aktiv.
        // Den kan tjekke alle tekstboksene for indhold, fordi alle tekstboksene peger på den samme event: TextChanged="txt_TextChanged"
        // OK-knappen skal gøres IsEnabled = false (linje 34), før det her giver mening,
        // og jeg valgte i stedet at bruge tekst output til bruger i lblMessage(linje 58), så metoden her er ubrugelig p.t.
        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsAllInfoFilled())
            {
                btnOK.IsEnabled = true;
            }
        }
    }
}
