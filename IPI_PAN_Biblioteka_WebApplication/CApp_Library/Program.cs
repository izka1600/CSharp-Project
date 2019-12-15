using DB_Model_EFCore.Models;
using DB_Model_EFCore.Controllers;
using System;
using DB_Model_EFCore.Class;

namespace CApp_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var c = new BooksController();
                c.CreateNewBook(new NewBook()
                {
                    BookName = "gory",
                    PublicationDate = DateTime.Now,
                    FirstName = "Jerzy",
                    LastName = "Kukuczka",
                    CoverName = "test",
                    DataCarrierName = "CD"
                });

                //var r = new ReaderController();
                //r.CreateNewReader(new Reader()
                //{
                //    FirstName = "Łukasz",
                //    LastName = "Dejko",
                //    Email = "lukasz@lukasz.pl",
                //    AccessRights = "r"
                //});
                Console.WriteLine("Zrobione");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            
            Console.ReadKey();
        }
    }
}
