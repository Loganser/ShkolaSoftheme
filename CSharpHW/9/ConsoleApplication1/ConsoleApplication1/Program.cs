using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        [Flags]
        enum FileAccessEnum : short
        {
            Read = 1,
            Write = 2
        }
        struct FileHandler
        {
            int FileSize;
            string FileName;
            string FilePath;
            FileAccessEnum FileAccess;

            public FileHandler(string FileName, string FilePath, FileAccessEnum FileAccess)
            {
                this.FileName = FileName;
                this.FileSize = 0;
                this.FilePath = FilePath;
                this.FileAccess = FileAccess;
            }

            public void OpenForRead()
            {
                string path = FilePath + "\\" + FileName;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, (System.IO.FileAccess)FileAccessEnum.Read))
                {
                    
                }

            }

            public void OpenForWrite()
            {
                string path = FilePath + "\\" + FileName;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, (System.IO.FileAccess)FileAccessEnum.Write))
                {

                }

            }

            public void OpenFile()
            {
                string path = FilePath + "\\" + FileName;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, (System.IO.FileAccess)FileAccessEnum.Read | (System.IO.FileAccess)FileAccessEnum.Write)) // 1 | 2 = 3
                {

                }

            }

        }
        static void Main(string[] args)
        {
            string fullPath = Directory.GetCurrentDirectory()+ "\\file.txt";
            FileHandler file = new FileHandler("file.txt", Directory.GetCurrentDirectory(), FileAccessEnum.Read| FileAccessEnum.Write);
            file.OpenForRead();
            file.OpenForWrite();
            file.OpenFile();

            Console.ReadLine();
        }
    }
}