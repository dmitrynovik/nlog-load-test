using System;
using System.IO;

namespace nlog_load_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Cleanup();

            //Console.WriteLine("Press any key to start...");
            //Console.Read();

            Console.WriteLine($"PATH: {Environment.CurrentDirectory}");
            Console.WriteLine("Running tests...");
            new LoadTest(10000).Run();

            //Console.WriteLine("Press any key to exit...");
            //Console.Read();
        }

        private static void Cleanup()
        {
            DeleteFile(@"Logs\AppLog.txt");
            DeleteFile(@"Logs\nlog-error-log.txt");
        }

        private static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception e)
                {
                    DumpError(e);
                }
            }
        }

        private static void DumpError(Exception e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
            Console.ForegroundColor = color;
        }
    }
}
