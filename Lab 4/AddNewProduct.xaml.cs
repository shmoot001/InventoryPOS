using Lab_4.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Window
    {
        public string ProductName { get; private set; }
        public decimal ProductPrice { get; private set; }
        public int ProductQuantity { get; private set; }
        public string BookAuthor { get; private set; }
        public string BookGenre { get; private set; }
        public string BookFormat { get; private set; }
        public string BookLanguage { get; private set; }
        public string GamePlattform { get; private set; }
        public string MovieFormat { get; private set; }
        public string MoviePlaytime { get; private set; }
        public string ProductType { get; private set; }


      
        // Egenskap för att lagra produkttypen som valts


        public AddNewProduct()
        {
            InitializeComponent();

        }

        private void ProductTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Hämta den valda ComboBoxItem
            ComboBoxItem selectedItem = (ComboBoxItem)ProductTypeComboBox.SelectedItem;

            // Kontrollera vilken produkttyp som valts och visa motsvarande inmatningsfält
            switch (selectedItem.Content.ToString())
            {
                case "Book":
                    BookFields.Visibility = Visibility.Visible;
                    GameFields.Visibility = Visibility.Collapsed;
                    MovieFields.Visibility = Visibility.Collapsed;
                    break;
                case "Game":
                    BookFields.Visibility = Visibility.Collapsed;
                    GameFields.Visibility = Visibility.Visible;
                    MovieFields.Visibility = Visibility.Collapsed;
                    break;
                case "Movie":
                    BookFields.Visibility = Visibility.Collapsed;
                    GameFields.Visibility = Visibility.Collapsed;
                    MovieFields.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Hämta produktinformation från användarinputen
            ComboBoxItem selectedItem = (ComboBoxItem)ProductTypeComboBox.SelectedItem;
            switch (selectedItem.Content.ToString())
            {
                case "Book":
                   if(ProductNameTextBox.Text != "" && ProductPriceTextBox.Text != null && ProductQuantityTextBox.Text != null)
                    {
                        ProductType = "Book";
                        ProductName = ProductNameTextBox.Text;
                        ProductPrice = decimal.Parse(ProductPriceTextBox.Text);
                        ProductQuantity = int.Parse(ProductQuantityTextBox.Text);
                        BookAuthor = BookAuthorTextBox.Text;
                        BookGenre = BookGenreTextBox.Text;
                        BookFormat = BookFormatTextBox.Text;
                        BookLanguage = BookLanguageTextBox.Text;

                        DialogResult = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Some Data is Missing !!!");
                    }
                    break;
                case "Game":
                    if (ProductNameTextBox.Text != "" && ProductPriceTextBox.Text != null && ProductQuantityTextBox.Text != null)
                    {
                        ProductType = "Game";
                        ProductName = ProductNameTextBox.Text;
                        ProductPrice = decimal.Parse(ProductPriceTextBox.Text);
                        ProductQuantity = int.Parse(ProductQuantityTextBox.Text);
                        GamePlattform = GamePlatformTextBox.Text;
                        DialogResult = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Some Data is Missing !!!");

                    }

                    break;
                case "Movie":
                    if (ProductNameTextBox.Text != "" && ProductPriceTextBox.Text != null && ProductQuantityTextBox.Text != null)
                    {
                        ProductType = "Movie";
                        ProductName = ProductNameTextBox.Text;
                        ProductPrice = decimal.Parse(ProductPriceTextBox.Text);
                        ProductQuantity = int.Parse(ProductQuantityTextBox.Text);
                        MovieFormat = MovieFormatTextBox.Text;
                        MoviePlaytime = MoviePlaytimeTextBox.Text;
                        DialogResult = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Some Data is Missing !!!");
                    }

                    break;
                default:
                    break;
            }
            // SÄKERINMATNING

            // Stäng dialogrutan och indikera att användaren klickade på "Lägg till"
  
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Stäng dialogrutan och indikera att användaren klickade på "Avbryt"
            DialogResult = false;
            Close();
        }
    }
}
