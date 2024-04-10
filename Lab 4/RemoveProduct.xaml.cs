using Lab_4.Classes;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab_4
{
    public partial class RemoveProduct : Window
    {
        private ObservableCollection<Book> _books;
        private ObservableCollection<Game> _games;
        private ObservableCollection<Movie> _movies;

        public RemoveProduct(ObservableCollection<Book> books, ObservableCollection<Game> games, ObservableCollection<Movie> movies)
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

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Kontrollera om en produkt är vald
            if (ProductListBox.SelectedItem != null)
            {
                // Fråga användaren om de är säkra på att de vill radera produkten
                var result = MessageBox.Show("You SURE", "Bekräfta radering", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // Ta bort den valda produkten från respektive lista baserat på vald produkttyp
                    switch (ProductTypeComboBox.SelectedIndex)
                    {
                        case 0: // Böcker
                            _books.Remove((Book)ProductListBox.SelectedItem);
                            break;
                        case 1: // Spel
                            _games.Remove((Game)ProductListBox.SelectedItem);
                            break;
                        case 2: // Filmer
                            _movies.Remove((Movie)ProductListBox.SelectedItem);
                            break;
                        default:
                            break;
                    }
                    DialogResult = true; // Ange att borttagningen lyckades
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en produkt att ta bort.");

                DialogResult = true;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Stäng dialogrutan utan att göra någon ändring
        }
    }
}
