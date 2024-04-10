using Lab_4.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Game> Games { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }

        private int getID<T>(ObservableCollection<T> products) where T : Product
        {
            // Kontrollera om listan inte är tom
            if (products.Count > 0)
            {
                // Hämta den sista produkten i listan
                T lastProduct = products[products.Count - 1];

                // Kontrollera om produkten inte är null och att den har minst ett värde
                if (lastProduct != null)
                {
                    // Hämta värdet i ID-egenskapen för den sista produkten och öka det med 1
                    return lastProduct.Id + 1;
                }
            }
            else
            {
                Console.WriteLine("Listan är tom.");
            }

            // Returnera 0 om listan är tom eller om det finns något fel
            return 0;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveProduct removeProductDialog = new RemoveProduct(Books, Games, Movies);
            removeProductDialog.ShowDialog();
            if (removeProductDialog.DialogResult == true)
            {

                

            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
       
            DataLoader.SaveBooksToCSV(Books, "Books.csv");
            DataLoader.SaveGamesToCSV(Games, "Games.csv");
            DataLoader.SaveMoviesToCSV(Movies, "Movies.csv");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Kod för att hantera knappklick för att lägga till produkt
            // Öppna dialogrutan för att lägga till produkt
            AddNewProduct dialog = new AddNewProduct();
            dialog.ShowDialog();

            // Hämta resultatet från dialogrutan (om användaren klickade på OK)
            if (dialog.DialogResult == true)
            {
                if(dialog.ProductType == "Book")
                {
                    string name = dialog.ProductName;
                    decimal price = dialog.ProductPrice;
                    int quantity = dialog.ProductQuantity;
                    string aurthor = dialog.BookAuthor;
                    string genre = dialog.BookGenre;
                    string format = dialog.BookFormat;
                    string language = dialog.BookLanguage;
                    int id = getID(Books);
                    Books.Add(new Book(id, name, price, quantity, aurthor,genre, format, language));

                    DataLoader.SaveBooksToCSV(Books, "Books.csv");
                }
                else if (dialog.ProductType == "Game")
                {
                    string name = dialog.ProductName;
                    decimal price = dialog.ProductPrice;
                    int quantity = dialog.ProductQuantity;
                    string plattform = dialog.GamePlattform;
                    int id = getID(Games);


                    Games.Add(new Game(id, name, price, quantity, plattform));

                    DataLoader.SaveGamesToCSV(Games, "Games.csv");
                }
                else
                {
                    string name = dialog.ProductName;
                    decimal price = dialog.ProductPrice;
                    int quantity = dialog.ProductQuantity;
                    string format = dialog.MovieFormat;
                    string playtime = dialog.MoviePlaytime;
                    int id = getID(Movies);

                    Movies.Add(new Movie(id, name, price, quantity, format, playtime));
                    DataLoader.SaveMoviesToCSV(Movies, "Movies.csv");

                }

            }
        }


        private void AddToInventory_Click(object sender, RoutedEventArgs e)
        {
            ProductDeliveryDialog productDeliveryDialog = new ProductDeliveryDialog(Books, Games, Movies);
            productDeliveryDialog.ShowDialog();
        }
        public MainWindow()
        {
            InitializeComponent();
            Books = DataLoader.LoadBooksFromCSV("Books.csv"); // Anropa metoden från den nya klassen
            Games = DataLoader.LoadGamesFromCSV("Games.csv"); // Anropa metoden från den nya klassen
            Movies = DataLoader.LoadMoviesFromCSV("Movies.csv"); // Anropa metoden från den nya klassen
            DataContext = this;
            Closing += MainWindow_Closing; // Lägg till evenemanthanteraren för Closing-evenemanget

        }
    }

}