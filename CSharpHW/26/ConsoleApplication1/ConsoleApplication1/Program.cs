using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private class Paths
        {
            public string target { get; }
            public string destination { get; }

            public Paths(string target, string destination)
            {
                this.target = target;
                this.destination = destination;
            }
        }

        static List<Thread> thread_pool = new List<Thread>();
        static int locker = 1;
        static int max_active_threads = 0;
        static string destination_path = "ArchiveFolder /";

        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the folder: ");
            string path = Console.ReadLine();
            Console.WriteLine("Please wait... ");
            Archivate_Folders_Parallel(new Paths(path, destination_path));
            bool wait = true;
            while (wait)
            {
                    if (locker == 0) wait = false;
            }
            Console.WriteLine("Finished!\nArchiveFolder was created in local directory.\nMax active threads used: {0}", max_active_threads);
            Console.ReadLine();
        }

        private static void Archivate_Folders_Parallel(object obj)
        {
            if (max_active_threads < locker) max_active_threads = locker;
            var parameters = (Paths)obj;
            string target = parameters.target,
            desination = parameters.destination,
            directoryName = Path.GetFileName(target),
            newDirectoryPath = Path.Combine(desination, directoryName);

            Directory.CreateDirectory(newDirectoryPath);

            var directories = Directory.GetDirectories(target);
            Parallel.ForEach(directories, directory =>
            {
                Thread thread = new Thread(Archivate_Folders_Parallel);
                lock (thread_pool)
                {
                    thread_pool.Add(thread);
                }
                ++locker;
                thread.Start(new Paths(directory, newDirectoryPath));
            });
            var files = Directory.GetFiles(target);
            Task newTask = Task.Run(() =>
            {
                Parallel.ForEach(files, file =>
                {
                    var name = Path.GetFileName(file);
                    string newFilePath = newDirectoryPath + "\\" + Path.GetFileName(file) + ".zip";
                    using (FileStream fs = new FileStream(newFilePath, FileMode.Create))
                    {
                        using (ZipArchive archivator = new ZipArchive(fs, ZipArchiveMode.Create))
                        {
                            archivator.CreateEntryFromFile(file, name);
                        }
                    }
                });
            });
            newTask.Wait();
            --locker;
        }

        
    }
}