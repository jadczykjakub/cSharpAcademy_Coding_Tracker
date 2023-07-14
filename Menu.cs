using System;

namespace cSharpAcademy_Coding_Tracker
{
    internal class Menu
    {
        internal static void ShowMenu()
        {
            Console.Clear();

            bool closeApp = false;

            while(closeApp == false)
            {
                Console.WriteLine("Hello, what would you like to do?");
                Console.WriteLine("Type 0 to close app");
                Console.WriteLine("Type 1 to Insert Coding Session");
                Console.WriteLine("Type 2 to Read All Coding Session");

                string input = Validation.Integer(Console.ReadLine());

                switch (input)
                {
                    case "0":
                        Console.WriteLine("Goodbye");
                        closeApp = true;
                        break;
                    case "1":
                        CodingController.Insert();
                        break;
                    case "2":
                        CodingController.ReadAll();
                        break;
                    default: Console.WriteLine("bye"); 
                        break;
                }
            }
        }
    }
}
