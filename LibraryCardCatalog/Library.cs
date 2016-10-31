using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryCardCatalog
{
    public class Program
    {


        public static void Main(string[] args)
        {

            List<Book> myBooks = new List<Book>();// *Important* so for the list to be used by all of the methods it needed to be delcared in main so its been moved from the ListBooks method to here


            Console.WriteLine("Choose file name");
            string FileName = Console.ReadLine(); // this is where the user inputs FileName for the SaveBook method
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu(myBooks, FileName);
            }
        }


        public static bool MainMenu(List<Book> myBooks, string FileName)//all of the methods now are given access to the list myBooks through the argument of the method
        {
            Console.WriteLine("Welcome to the digital library, choose an option:");
            Console.WriteLine("1) List Current Books");
            Console.WriteLine("2) To Add A Book");
            Console.WriteLine("3) To Save and Exit");
            Console.WriteLine("4) To Retrieve List");
            string a = Console.ReadLine();
            int x;
            int.TryParse(a, out x);


            if (x == 1)
            {
                Console.Clear();
                CardCatalog.ListBooks(myBooks); //when invoking the method ListBooks I need to pass myBooks into the argument
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                return true;
            }
            else if (x == 2)
            {
                Console.Clear();
                CardCatalog.AddBook(myBooks); // Same deal as ListBooks we need to pass myBooks in the argument
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                return true;
            }
            else if (x == 3)
            {
                Console.Clear();
                CardCatalog.BookSave(myBooks, FileName);//calling the Save method
                Console.Clear();
                return false;
            }
            else if (x == 4)
            {
                Console.Clear();
                myBooks = CardCatalog.CallList(FileName);
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                return true;           
            }


            else
            {
                Console.Clear();
                Console.WriteLine("Option not available.");
                Console.WriteLine("Press enter to continue."); // Added this option so if the user puts a random number it won't crash.
                Console.ReadLine();
                Console.Clear();
                return true;
            }

        }


    }


}


