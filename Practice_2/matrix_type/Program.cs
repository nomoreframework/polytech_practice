using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace matrix_type
{
    class Program
    {
       static MenuConsumer menu = new MenuConsumer(print, read, kill, new List<MyMatrix>(2));
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    menu.ShowMenu();
                }
                catch (Exception ex)
                {
                    print(ex.Message);
                }
                finally
                {
                    print("-----------------");
                }
            }
        }
        static string read()
        {
           string input_chars = Console.ReadLine();
            return input_chars;
        }
        static void print(string message)
        {
            Console.WriteLine(message);
        }
        static void kill()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
