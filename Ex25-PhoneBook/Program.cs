using Ex25_PhoneBook;

internal class Program
{
    static int theme = (new Random()).Next(-1, 3);

    static void SetForegroundColor()
    {
        switch (theme)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
        }
    }

    static void PrintBetweenColor(string message)
    {
        SetForegroundColor();
        Console.Write(message);
        Console.ResetColor();
    }

    static void PrintBetweenColor(string toColor, string message)
    {
        PrintBetweenColor(toColor);
        Console.Write(message);
    }

    static void ClearScreen()
    {
        if (++theme == 4)
            theme = 0;

        Console.Clear();

        PrintBetweenColor(@"
             _____  _                        ____              _    
            |  __ \| |                      |  _ \            | |   
            | |__) | |__   ___  _ __   ___  | |_) | ___   ___ | | __
            |  ___/| '_ \ / _ \| '_ \ / _ \ |  _ < / _ \ / _ \| |/ /
            | |    | | | | (_) | | | |  __/ | |_) | (_) | (_) |   < 
            |_|    |_| |_|\___/|_| |_|\___| |____/ \___/ \___/|_|\_\

		" + "\n");
    }

    static void ShowMenu(int screen)
    {
        switch (screen)
        {
            case 1:
                PrintBetweenColor("\n\t\t[1] ", "Register person\n");
                PrintBetweenColor("\t\t[2] ", "Edit person register\n");
                PrintBetweenColor("\t\t[3] ", "Remove person\n");
                PrintBetweenColor("\t\t[4] ", "See registered persons\n");
                PrintBetweenColor("\t\t[0] ", "Exit\n");
                break;

            case 2:
                PrintBetweenColor("\n\t\t[1] ", "Edit name\n");
                PrintBetweenColor("\t\t[2] ", "Edit Phone number\n");
                PrintBetweenColor("\t\t[3] ", "Edit Address\n");
                PrintBetweenColor("\t\t[4] ", "Edit Email\n");
                PrintBetweenColor("\t\t[0] ", "Cancel\n");
                break;

            case 3:
                PrintBetweenColor("\n\t\t[1] ", "Edit zip-code\n");
                PrintBetweenColor("\t\t[2] ", "Edit ciy\n");
                PrintBetweenColor("\t\t[3] ", "Edit state\n");
                PrintBetweenColor("\t\t[4] ", "Edit public place\n");
                PrintBetweenColor("\t\t[5] ", "Edit public place type\n");
                PrintBetweenColor("\t\t[6] ", "Edit childhood\n");
                PrintBetweenColor("\t\t[7] ", "Edit number\n");
                PrintBetweenColor("\t\t[8] ", "Edit complement\n");
                PrintBetweenColor("\t\t[0] ", "Cancel\n");
                break;
        }
    }

    static void Pause()
    {
        PrintBetweenColor("\n\t\tPress any key to continue...");
        Console.ReadKey();
    }

    static void ShowTitle(string title)
    {
        PrintBetweenColor($"\t\t\t\t {title.ToUpper()}\n");
    }

    static int GetMenu(string title, string message, int screen, int min, int max)
    {
        string command;
        int value;

        do
        {
            do
            {
                ClearScreen();
                ShowTitle(title);
                ShowMenu(screen);
                PrintBetweenColor($"\n\t\t{message}: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out value));

        } while (value < min || (min != max && value > max));

        return value;
    }

    static int GetValue(string title, string message, int min, int max)
    {
        string command;
        int value;

        do
        {
            do
            {
                ClearScreen();
                PrintBetweenColor($"\t\t\t {title.ToUpper()}\n");
                PrintBetweenColor($"\n\t\t{message}: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out value));

        } while (value < min || (min != max && value > max));

        return value;
    }

    static string GetString(string title, string message)
    {
        string input;

        do
        {
            ClearScreen();
            ShowTitle(title);
            Console.Write($"\n\t\t{message}: ");
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    static PhoneList PhonesRegister()
    {
        PhoneList phones = new PhoneList();
        string title = "phone register";
        string input;

        do
        {
            phones.Add(new Phone(GetString(title, "type phone number")));

            Console.WriteLine("\n\t\tPress 'y' to register another phone number");

        } while (Console.ReadLine().Equals('y'));

        return phones;
    }

    static Address AddressRegister()
    {
        string title = "address register";
        Address address = new Address();

        address.SetZipCode(GetString(title, "Type your zip-code"));
        address.SetCity(GetString(title, "Type your city"));
        address.SetState(GetString(title, "Type your state"));
        address.SetPublicPlace(GetString(title, "Type your publicPlace"));
        address.SetPublicPlaceType(GetString(title, "Type your public place type"));
        address.SetChildhood(GetString(title, "Type your childhood"));
        address.SetNumber(GetValue(title, "Type your number", 1, 1));
        address.SetComplement(GetString(title, "Type your complement ('n/a' if you dont want to)"));

        return address;
    }

    static void RegisterPerson(PersonList persons)
    {
        string title = "person register";
        
        Person person = new Person(GetString(title, "Type name"), GetString(title, "Type email"), PhonesRegister(), AddressRegister());

        if (persons.Add(person))
            PrintBetweenColor("\n\t\tPerson successfully registered!");
        else
            PrintBetweenColor("\n\t\tYou already have a person with the same name!");
    }

    static void EditPerson(Person person)
    {
        if (person != null)
        {
            int menuOption, addressOption;
            string title = "person edit";

            do
            {
                menuOption = GetMenu(title, "Option", 2, 0, 4);

                switch (menuOption)
                {
                    case 1:
                        Console.Write($"Current name: ");
                        PrintBetweenColor($"{person.GetName()}\n");

                        person.SetName(GetString(title, "new name"));
                        break;

                    case 2:
                        Console.WriteLine(person.GetPhones().ToString());
                        if (person.RemovePhoneNumber(GetString(title, "type phone number to update")))
                        {
                            person.AddPhoneNumber(new Phone(GetString(title, "type a new phone number")));
                            PrintBetweenColor("\n\t\tPhone successfully updated!");
                        }
                        else
                            PrintBetweenColor("\n\t\tPhone number not found!");
                        break;

                    case 3:
                        Address aux = person.GetAddress();

                        Console.WriteLine(aux.ToString());

                        addressOption = GetMenu(title, "Option", 3, 0, 8);

                        switch (addressOption)
                        {
                            case 1:
                                aux.SetZipCode(GetString(title, "Type a new zip-code"));
                                PrintBetweenColor("\n\t\tZip-code successfully updated!");
                                break;

                            case 2:
                                aux.SetCity(GetString(title, "Type a new city"));
                                PrintBetweenColor("\n\t\tCity successfully updated!");
                                break;

                            case 3:
                                aux.SetState(GetString(title, "Type a new state"));
                                PrintBetweenColor("\n\t\tState successfully updated!");
                                break;

                            case 4:
                                aux.SetPublicPlace(GetString(title, "Type a new public place"));
                                PrintBetweenColor("\n\t\tPublic place successfully updated!");
                                break;

                            case 5:
                                aux.SetPublicPlaceType(GetString(title, "Type a new public place type"));
                                PrintBetweenColor("\n\t\tPublic place type successfully updated!");
                                break;

                            case 6:
                                aux.SetChildhood(GetString(title, "Type a new childhood"));
                                PrintBetweenColor("\n\t\tChildhood successfully updated!");
                                break;

                            case 7:
                                aux.SetNumber(GetValue(title, "Type a new number", 1, 1));
                                PrintBetweenColor("\n\t\tNumber successfully updated!");
                                break;

                            case 8:
                                aux.SetComplement(GetString(title, "Type a new complement"));
                                PrintBetweenColor("\n\t\tComplement successfully updated!");
                                break;

                            default:
                                PrintBetweenColor("Operation cancelled!");
                                break;
                        }

                        break;

                    case 4:
                        Console.WriteLine($"\n\t\tCurrent email: ");
                        PrintBetweenColor($"{person.GetEmail()}\n");

                        person.SetEmail(GetString(title, "Type new email"));
                        PrintBetweenColor("\n\t\tEmail successfully updated");
                        break;
                }

                Pause();

            } while (menuOption != 0);

            PrintBetweenColor("\n\t\tOperation cancelled!");
        }
        else
            PrintBetweenColor("\n\t\tPerson not found!\n");
    }

    static void RemovePerson(PersonList personList)
    {
        string title = "remove person";

        if (personList.RemoveByName(GetString(title, "Type person name")) != null)
            PrintBetweenColor("\n\t\tPerson successfully removed!\n");
        else
            PrintBetweenColor("\n\t\tPerson not found!\n");
    }

    static void ShowRegisteredPersons(PersonList personList)
    {
        PersonList copiedList = personList.GetCopy();

        if (!copiedList.IsEmpty()) 
        {
            PrintBetweenColor("\n\t\t\t REGISTERED PERSONS\n");

            while (!copiedList.IsEmpty())
                PrintBetweenColor($"\n\t\t{copiedList.Remove()}");
        }

        PrintBetweenColor("\n\t\tYou don't have persons registered!\n");
    }

    private static void Main(string[] args)
    {
        PersonList persons = new PersonList();
        string title = "main page";
        int command;
        Person aux;

        do
        {
            ClearScreen();
            ShowTitle(title);

            command = GetMenu(title, "Option", 1, 1, 4);

            switch (command)
            {
                case 1:
                    RegisterPerson(persons);
                    break;

                case 2:
                    EditPerson(persons.RemoveByName(GetString("edit person", "Type person name")));
                    break;

                case 3:
                    RemovePerson(persons);
                    break;

                case 4:
                    ShowRegisteredPersons(persons);
                    break;
            }

            Pause();

        } while (command != 0);

        PrintBetweenColor("\t\t---------- Exiting ----------\n");
    }
}