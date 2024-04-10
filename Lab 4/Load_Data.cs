using Lab_4.Classes;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lab_4
{
    public class DataLoader
    {

        public static void SaveMoviesToCSV(ObservableCollection<Movie> movies, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var movie in movies)
                    {
                        // Skriv varje filmens egenskaper till en rad i CSV-filen
                        writer.WriteLine($"{movie.Id};{movie.Name};{movie.Price};{movie.Quantity};{movie.Format};{movie.Playtime}");
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error writing to file {filePath}: {ex.Message}");
            }
        }

        public static void SaveBooksToCSV(ObservableCollection<Book> books, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var book in books)
                    {
                        // Skriv varje boks egenskaper till en rad i CSV-filen
                        writer.WriteLine($"{book.Id};{book.Name};{book.Price};{book.Quantity};{book.Author};{book.Genre};{book.Format};{book.Language}");
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error writing to file {filePath}: {ex.Message}");
            }
        }

        public static void SaveGamesToCSV(ObservableCollection<Game> games, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var game in games)
                    {
                        // Skriv varje spels egenskaper till en rad i CSV-filen
                        writer.WriteLine($"{game.Id};{game.Name};{game.Price};{game.Quantity};{game.Platform}");
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error writing to file {filePath}: {ex.Message}");
            }
        }


        public static ObservableCollection<Movie> LoadMoviesFromCSV(string filePath)
        {
            var movies = new ObservableCollection<Movie>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        // Kontrollera om raden är null
                        if (line != null)
                        {
                            var values = line.Split(';');

                            if (values.Length >= 5)
                            {
                                int id;
                                decimal price;
                                int quantity;

                                if (int.TryParse(values[0], out id) &&
                                    decimal.TryParse(values[2], out price) &&
                                    int.TryParse(values[3], out quantity))
                                {
                                    movies.Add(new Movie(id, values[1], price, quantity, values[4], values[5]));
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading file {filePath}: {ex.Message}");
            }

            return movies;
        }
        public static ObservableCollection<Game> LoadGamesFromCSV(string filePath)
        {
            var games = new ObservableCollection<Game>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        // Kontrollera om raden är null
                        if (line != null)
                        {
                            var values = line.Split(';');

                            if (values.Length >= 4)
                            {
                                int id;
                                decimal price;
                                int quantity;

                                if (int.TryParse(values[0], out id) &&
                                    decimal.TryParse(values[2], out price) &&
                                    int.TryParse(values[3], out quantity))
                                {
                                    games.Add(new Game(id, values[1], price, quantity, values[4]));
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading file {filePath}: {ex.Message}");
            }

            return games;
        }
        public static ObservableCollection<Book> LoadBooksFromCSV(string filePath)
        {
            var books = new ObservableCollection<Book>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        // Kontrollera om raden är null
                        if (line != null)
                        {
                            var values = line.Split(';');

                            if (values.Length >= 7)
                            {
                                int id;
                                decimal price;
                                int quantity;

                                if (int.TryParse(values[0], out id) &&
                                    decimal.TryParse(values[2], out price) &&
                                    int.TryParse(values[3], out quantity))
                                {
                                    books.Add(new Book(id, values[1], price, quantity, values[4], values[5], values[6], values[7]));
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading file {filePath}: {ex.Message}");
            }

            return books;
        }
    }
}
