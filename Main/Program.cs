using Controller;
using Microsoft.IdentityModel.Tokens;
using Model;
using System.Collections.Generic;
using Service;

namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int command = 0;

            do
            {
                ShowMenu();

                command = ReadCommand();

                switch (command)
                {
                    case 1:
                        Console.WriteLine(new CarController().InsertCar(CreateCar()) ? "\nCar inserted successfully" : "\nFailed to insert car!");
                        break;

                    case 2:
                        ShowCar();
                        break;

                    case 3:
                        ShowAllCars();
                        break;

                    case 4:
                        UpdateCar();
                        break;

                    case 5:
                        DeleteCar();
                        break;
                }

                Console.Write("\nPress any key to continue...");
                Console.ReadKey();

                Console.Clear();

            } while (command > 0 && command < 6);

        }

        private static Car CreateCar()
        {
            Console.Write("\nCar name: ");
            var name = ReadString();

            Console.Write("Car color: ");
            var color = ReadString();

            Console.Write("Car year: ");
            var year = ReadCommand();

            Console.Write("Insurance description: ");

            return new()
            {
                Id = 0,
                Name = name,
                Color = color,
                Year = year,
                Insurance = new Insurance() { Description = ReadString() }
            };
        }

        private static void ShowCar()
        {
            Console.Write("\nCar id: ");
            int id = ReadCommand();

            Console.WriteLine("");

            Console.WriteLine(new CarController().GetCarById(id) == null ? "Car not found" : new CarController().GetCarById(id));
        }

        private static void ShowAllCars()
        {
            List<Car> cars = new CarController().GetAllCars();

            if (cars.Count == 0)
            {
                Console.WriteLine("\nNo cars found");
                return;
            }

            foreach (var car in cars)
                Console.WriteLine("\n" + car);
        }

        private static void UpdateCar()
        {
            ShowAllCars();

            if (new CarController().GetAllCars().Count == 0)
                return;

            var car = CreateCar();
            
            Console.Write("\nCar id: ");            
            car.Id = ReadCommand();

            Console.WriteLine(new CarController().UpdateCar(car) ? "\nCar updated successfully" : "\nFailed to update car!");
        }

        private static void DeleteCar()
        {
            Console.Write("\nCar id: ");
            int id = ReadCommand();

            Console.WriteLine(new CarController().DeleteCar(id) ? "\nCar deleted successfully" : "\nFailed to delete car!");
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n > COMMANDS <\n");

            Console.Write("[1] Insert\n" +
                          "[2] Show\n" +
                          "[3] Show all\n" +
                          "[4] Update\n" +
                          "[5] Delete\n" +
                          "[any other number] Exit\n\n" +

                          "Option: ");
        }

        private static string ReadString()
        {
            string? str;
            int cursorTop = Console.CursorTop;
            int cursrorLeft = Console.CursorLeft;

            do
            {
                Console.SetCursorPosition(cursrorLeft, cursorTop);
                str = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(str));

            return str;
        }

        private static int ReadCommand()
        {
            int command;
            int cursorTop = Console.CursorTop;
            int cursorLeft = Console.CursorLeft;

            try
            {
                command = int.Parse(ReadString());
            }
            catch (Exception)
            {
                ClearLine(cursorTop, cursorLeft);
                return ReadCommand();
            }

            return command;
        }

        private static void ClearLine(int top, int left)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine("                                                 ");
            Console.SetCursorPosition(left, top);
        }
    }
}