using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LibraryCardCatalog
{
    public class CardCatalog 
    {

        internal static void ListBooks(List<Book> myBooks) //Almost all of our methods (aside from save & exit) will inherit the list of books
        {
           foreach (Book book in myBooks)

                {
                    Console.WriteLine(book.Title + " " + book.Author + " " + book.YearPublished + " " + book.Genre); //Needed to use "+" instead of "," also added dead space inbetween each to its not all smashed together
                    Console.WriteLine();
                }
           

        }
        internal static List<Book> CallList(string FileName)
        {

            XmlSerializer ser = new XmlSerializer(typeof(List<Book>));

            try
            {
                List<Book> myBooks2;
                using (FileStream fs = new FileStream("C:\\Users\\codingtemple\\Desktop\\" + FileName + ".xml", FileMode.OpenOrCreate))
                {
                    TextReader reader = new StreamReader(fs);
                    myBooks2 = (List<Book>)ser.Deserialize(reader);
                    foreach (Book book in myBooks2)

                    {
                        Console.WriteLine(book.Title + " " + book.Author + " " + book.YearPublished + " " + book.Genre); //Needed to use "+" instead of "," also added dead space inbetween each to its not all smashed together
                        Console.WriteLine();
                    }
                    fs.Close();
                }
                return myBooks2;
            }
            catch (Exception)
            {
                Console.WriteLine("Please save and exit the application");
                return null;
               
            }
                

                
            
    }


        internal static void AddBook(List<Book> myBooks) //inherits list myBooks, need to add the rest of the genres to the writeline, creates a new book at the end called newBook
        {


            Console.WriteLine("What is the title of the book");
            string title = Console.ReadLine();

            Console.WriteLine("What is the author of the book");
            string author = Console.ReadLine();

            Console.WriteLine("When was the book published");
            int year = Convert.ToInt32(Console.ReadLine());

            Genre genre;
            bool displayGenre;
            do
            {
                Console.WriteLine("What is the genre of the book");
                Console.WriteLine("Options are: ScienceFiction, Fiction, Satire, Drama, Action, Adventure, Romance, Mystery, Horror, Health, SelfHelp, Children, Science, History, Poetry, Comics, Art, & Cookbooks ");
                string g = Console.ReadLine();
                displayGenre = Enum.TryParse<Genre>(g, out genre);

            } while (displayGenre == false);

            Book newBook = new Book(title, author, year, genre); //takes the user input and makes a book
            myBooks.Add(newBook); // adds the new book to the list

            Console.WriteLine("Thanks! You have added the book {0} written by {1} pushlised in the year {2} in the Genre {3}", newBook.Title, newBook.Author, newBook.YearPublished, newBook.Genre);
            Console.ReadLine(); //just some fluff gives the user some text showing them what they entered, nonessential



        }



        internal static void BookSave(List<Book> myBooks, string FileName)//this inherits the list myBooks but importantly inherits the string FileName that the user sets in main
        { 
            //code below is for the save function, currently takes the filename the user declared at the startup and saves it to desktop
            var serializer = new XmlSerializer(typeof(List<Book>));

            using (var writer = new StreamWriter("C:\\Users\\codingtemple\\Desktop\\" + FileName + ".xml"))//small edit to allow us to pass file name in the extension
            {
                serializer.Serialize(writer, myBooks);
            }

        }
    }
}







