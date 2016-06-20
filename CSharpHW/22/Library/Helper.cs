using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO.Compression;

namespace Library
{
    public enum Genre { classic, humor, drama }
    [Serializable]
    public class Helper
    {

        public static void Validate_user(User user)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                    
                }
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User is OK");
                Console.ResetColor();
            }
        }

        public static bool Validate_literature(Literature book)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);
            if (!Validator.TryValidateObject(book, context, results, true))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);

                }
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book is OK");
                Console.ResetColor();
                return true;
            }
        }

        public static void Exit_helper(User user)
        {
            if (!user.autorized)
            {
                Console.WriteLine(user.login + ", do you want to autorize? (yes/no)");
                string inp = Console.ReadLine();
                if (inp.Equals("yes"))
                {
                    Library.Add_user(user.login);
                    Console.WriteLine("You were added to our database!");
                }
            }

            Console.WriteLine("Bye, " + user.login + ". Please come back!");
            System.Threading.Thread.Sleep(1500);
            Environment.Exit(0);
        }

        public static void Show_help(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of commands:");
            if (user.autorized)
            {
                Console.WriteLine("TAKE_BOOK");
                Console.WriteLine("RETURN_BOOK");
                Console.WriteLine("ADD_BOOK");
            }
            Console.WriteLine("SHOW_INFO");
            Console.WriteLine("CHECK_BOOK");
            Console.WriteLine("POPULAR_IN_GENRE");
            Console.WriteLine("EXIT");
            Console.ResetColor();
        }

        public static void Save_Library(string xml_path, string zip_path)
        {
            using (TextWriter WriteFileStream = new StreamWriter(xml_path))
            {
                try
                {
                    XmlSerializer SerializerObj = new XmlSerializer(typeof(List<Literature>));
                    SerializerObj.Serialize(WriteFileStream, Library.books);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Serialization failed: " + ex.Message);
                }
            }
            using (FileStream fs = new FileStream(zip_path, FileMode.Create))
            {
                using (ZipArchive arch = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    arch.CreateEntryFromFile(xml_path, xml_path);
                }
            }
            if (File.Exists(xml_path))
            {
                File.Delete(xml_path);
            }
        }

        public static void Download_Library(string xml_path, string zip_path)
        {
            if (File.Exists(xml_path))
            {
                File.Delete(xml_path);
            }

            using (ZipArchive archive = ZipFile.Open(zip_path, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(entry.Name);
                }
            }

            List<Literature> list = new List<Literature>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Literature>));
            using (StreamReader reader = new StreamReader(xml_path))
            {
                try
                {
                    list = (List<Literature>)serializer.Deserialize(reader);
                    foreach (Literature book in list)
                    {
                        Library.Add_book(book);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

    }
}
