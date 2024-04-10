using Lab_4.Classes;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab_4
{
    public partial class ProductDeliveryDialog : Window
    {
        private ObservableCollection<Book> _books;
        private ObservableCollection<Game> _games;
        private ObservableCollection<Movie> _movies;

        public ProductDeliveryDialog(ObservableCollection<Book> books, ObservableCollection<Game> games, ObservableCollection<Movie> movies)
        {
            InitializeComponent();
            _books = books;
            _games = games;
            _movies = movies;
            ProductTypeComboBox.SelectedIndex = 0; // Välj första produkttypen som standard
        }

        private void ProductTypeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Fyll listan med produktnamn baserat på vald produkttyp
            switch (ProductTypeComboBox.SelectedIndex)
            {
                case 0: // Böcker
                    ProductListBox.ItemsSource = _books;
                    ProductListBox.DisplayMemberPath = "Name"; // Ange egenskapen för namn
                    break;
                case 1: // Spel
                    ProductListBox.ItemsSource = _games;
                    ProductListBox.DisplayMemberPath = "Name"; // Ange egenskapen för namn
                    break;
                case 2: // Filmer
                    ProductListBox.ItemsSource = _movies;
                    ProductListBox.DisplayMemberPath = "Name"; // Ange egenskapen för namn
                    break;
                default:
                    break;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Kontrollera om en produkt är vald
            if (ProductListBox.SelectedItem != null)
            {
                // Lägg till den valda produkten i listan över valda produkter
                // Din kod för att hantera tillägg här...
            }
            else
            {
                MessageBox.Show("Vänligen välj en produkt att lägga till i leveransen.");
            }
        }

        private void DeliverButton_Click(object sender, RoutedEventArgs e)
        {
            // Kontrollera om en giltig leveransmängd har angetts
            // Din kod för att hantera leverans här...
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Stäng dialogrutan utan att göra någon ändring
        }
    }
}
