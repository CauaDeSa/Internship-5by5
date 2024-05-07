using Ex27_PhoneBookPersistence;

internal class Program
{
    static int theme = (new Random()).Next(-1, 3);

    static readonly string absolutePath = @"C:\Data\Week-04\Ex27\";

    static readonly string personFilePath = "persons.txt";
    static readonly string phoneFilePath = "phones.txt";
    static readonly string addressFilePath = "addresses.txt";

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
                PrintBetweenColor("\t\t[5] ", "Find a person by its name\n");
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
        PrintBetweenColor("\n\t\t\t  Press any key to continue...");
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
                ShowTitle(title);
                Console.Write($"\n\t\t{message}: ");
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

    static bool CheckPathing(string specificFilePath)
    {
        bool check = false;

        if (!Directory.Exists(absolutePath))
            Directory.CreateDirectory(absolutePath);

        if (!File.Exists(absolutePath + specificFilePath))
            File.Create(absolutePath + specificFilePath);
        else
            check = true;

        return check;
    }

    static void SavePersons(List<Person> persons)
    {
        if (CheckPathing(personFilePath))
        {
            StreamWriter writer = new(absolutePath + personFilePath);

            foreach (var person in persons)
                writer.WriteLine(person);

            writer.Close();
        }
    }

    static void SavePhones(List<Person> phones)
    {
        if (CheckPathing(phoneFilePath))
        {
            StreamWriter writer = new(absolutePath + phoneFilePath);

            foreach (var phone in phones)
                writer.WriteLine(phone);

            writer.Close();
        }
    }

    static void SaveAddresses(List<Person> addresses)
    {
        if (CheckPathing(addressFilePath))
        {
            StreamWriter writer = new(absolutePath + addressFilePath);

            foreach (var address in addresses)
                writer.WriteLine(address);

            writer.Close();
        }
    }

    static List<Person> LoadPersons()
    {
        List<Person> persons = new();

        if (CheckPathing(personFilePath))
        {
            string[] person;

            foreach (var line in File.ReadAllLines(absolutePath + personFilePath))
            {
                person = line.Split(";");
                persons.Add(new Person(int.Parse(person[0]), person[1], person[2]));
            }
        }

        return persons;
    }

    static List<Phone> LoadPhones()
    {
        List<Phone> phones = new();

        if (CheckPathing(phoneFilePath))
        {
            string[] person;

            foreach (var line in File.ReadAllLines(absolutePath + phoneFilePath))
            {
                person = line.Split(";");
                phones.Add(new Phone(int.Parse(person[0]), person[1]));
            }
        }

        return phones;
    }

    static List<Address> LoadAddresses()
    {
        List<Address> Addresses = new();

        if (CheckPathing(addressFilePath))
        {
            string[] address;

            foreach (var line in File.ReadAllLines(absolutePath + addressFilePath))
            {
                address = line.Split(";");
                Addresses.Add(new Address(int.Parse(address[0]), address[1], address[2], address[3], address[4], address[5], address[6], int.Parse(address[7]), address[8]));
            }
        }

        return Addresses;
    }

    static int LoadIdCounter(List<Phone> phones)
    {
        int id = 0;

        foreach (Phone phone in phones)
            if (id < phone.PersonId)
                id = phone.PersonId;

        return id + 1;
    }

    static PhoneList PhonesRegister(int personId)
    {
        PhoneList phones = new();
        string title = "phone register";

        do
        {
            phones.Add(new Phone(personId, GetString(title, "type phone number")));

            Console.Write("\n\t\t\tPress 'y' to register another phone number");

        } while (Console.ReadLine() == "y");

        return phones;
    }

    static Address AddressRegister(int personId)
    {
        string title = "address register";

        Address address = new()
        {
            PersonId = personId,
            ZipCode = GetString(title, "Type your zip-code"),
            City = GetString(title, "Type your city"),
            State = GetString(title, "Type your state"),
            PublicPlace = (GetString(title, "Type your public place")),
            PublicPlaceType = GetString(title, "Type your public place type"),
            Childhood = GetString(title, "Type your childhood"),
            PlaceNumber = GetValue(title, "Type your address number", 1, 1),
            Complement = string.Empty
        };

        Console.Write("\n\t\t\tPress 'y' to register complement");
        if (Console.ReadLine() == "y")
            address.Complement = GetString(title, "Type your complement");

        return address;
    }

    static Person RegisterPerson(int personId)
    {
        string title = "person register";
        
        return new(personId, GetString(title, "Type name"), GetString(title, "Type email"), PhonesRegister(personId), AddressRegister(personId));
    }

    static Person? EditPerson(Person person)
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
                        Console.Write($"\n\t\tCurrent name: ");
                        PrintBetweenColor($"{person.Name}\n");
                        Pause();

                        person.Name = GetString(title, "new name");
                        break;

                    case 2:
                        Console.WriteLine(person.Phones.ToString());
                        Pause();

                        if (person.RemovePhoneNumber(GetString(title, "type phone number to update")))
                        {
                            person.AddPhoneNumber(new Phone(person.Id, GetString(title, "type a new phone number")));
                            PrintBetweenColor("\n\t\t\tPhone successfully updated!\n");
                        }
                        else
                            PrintBetweenColor("\n\t\t\tPhone number not found!\n");
                        break;

                    case 3:
                        Address aux = person.Address;

                        Console.WriteLine(aux.ToString());
                        Pause();

                        addressOption = GetMenu(title, "Option", 3, 0, 8);

                        switch (addressOption)
                        {
                            case 1:
                                aux.ZipCode = GetString(title, "Type a new zip-code"));
                                PrintBetweenColor("\n\t\t\tZip-code successfully updated!\n");
                                break;

                            case 2:
                                aux.City = GetString(title, "Type a new city"));
                                PrintBetweenColor("\n\t\t\tCity successfully updated!\n");
                                break;

                            case 3:
                                aux.State = GetString(title, "Type a new state"));
                                PrintBetweenColor("\n\t\t\tState successfully updated!\n");
                                break;

                            case 4:
                                aux.PublicPlace = GetString(title, "Type a new public place"));
                                PrintBetweenColor("\n\t\t\tPublic place successfully updated!\n");
                                break;

                            case 5:
                                aux.PublicPlaceType = GetString(title, "Type a new public place type"));
                                PrintBetweenColor("\n\t\t\tPublic place type successfully updated!\n");
                                break;

                            case 6:
                                aux.Childhood = GetString(title, "Type a new childhood"));
                                PrintBetweenColor("\n\t\t\tChildhood successfully updated!\n");
                                break;

                            case 7:
                                aux.PlaceNumber = GetValue(title, "Type a new number", 1, 1));
                                PrintBetweenColor("\n\t\t\tNumber successfully updated!\n");
                                break;

                            case 8:
                                aux.Complement = GetString(title, "Type a new complement"));
                                PrintBetweenColor("\n\t\t\tComplement successfully updated!\n");
                                break;

                            default:
                                PrintBetweenColor("\n\t\t\tOperation cancelled!");
                                break;
                        }

                        break;

                    case 4:
                        Console.Write($"\n\t\tCurrent email: ");
                        PrintBetweenColor($"{person.Email}\n");
                        Pause();

                        person.Email = GetString(title, "Type new email"));
                        PrintBetweenColor("\n\t\tEmail successfully updated");
                        break;
                }

            } while (menuOption != 0);

            PrintBetweenColor("\n\t\t\t     Operation cancelled!\n");
        }
        else
            PrintBetweenColor("\n\t\t\t\tPerson not found!\n");

        return person;
    }

    static void RemovePerson(PersonList personList)
    {
        string title = "remove person";

        if (personList.RemoveByName(GetString(title, "Type person name")) != null)
            PrintBetweenColor("\n\t\t\tPerson successfully removed!\n");
        else
            PrintBetweenColor("\n\t\t\t       Person not found!\n");
    }

    static void ShowRegisteredPersons(PersonList personList)
    {
        PersonList copiedList = personList.GetCopy();

        if (!copiedList.IsEmpty()) 
        {
            PrintBetweenColor("\n\t\t\t     REGISTERED PERSONS\n");

            while (!copiedList.IsEmpty())
            {
                Person aux = copiedList.Remove();

                PrintBetweenColor("\n\t\t\t           Info               ");
                Console.WriteLine($"\n\t\t\t   Name..............: {aux.Name}" +
                                  $"\n\t\t\t   Email.............: {aux.Email}");
                PrintBetweenColor("\n\t\t\t           Phones               ");
                Console.WriteLine(aux.Phones.ToString());
                PrintBetweenColor("\t\t\t          Address           ");
                Console.WriteLine(aux.Address.ToString());


            }
                Console.Write($"\n\t\t{copiedList.Remove()}");
        }
        else 
            PrintBetweenColor("\n\t\t     You don't have persons registered!\n");
        }

    static void ShowRegisteredPerson(PersonList persons)
    {
        Person? aux = persons.GetCopy().GetByName(GetString("show data", "Type a name to find"));

        if (aux != null) 
        {
            PrintBetweenColor("\n\t\t\t           Info               ");
            Console.WriteLine($"\n\t\t\t   Name..............: {aux.Name}" +
                              $"\n\t\t\t   Email.............: {aux.Email}");
            PrintBetweenColor("\n\t\t\t           Phones               ");
            Console.WriteLine(aux.Phones.ToString());
            PrintBetweenColor("\t\t\t          Address           ");
            Console.WriteLine(aux.Address.ToString());
        }
        else
            PrintBetweenColor("\n\t\t You don't have this person in your phone book!\n");
    }

    private static void Main(string[] args)
    {
        string title = "main page";

        List<Person> persons = LoadPersons();
        List<Phone> phones = LoadPhones();
        List<Address> addresses = LoadAddresses();

        int personIdCounter = LoadIdCounter(phones);
        int command;

        do
        {
            ClearScreen();
            ShowTitle(title);

            command = GetMenu(title, "Option", 1, 0, 5);

            switch (command)
            {
                case 1:
                    Person newPerson = RegisterPerson(personIdCounter);

                    if (persons.Add(newPerson))
                    {
                        PrintBetweenColor("\n\t\t\tPerson successfully registered!\n");

                    }
                    else
                        PrintBetweenColor("\n\t\t   You already have a person with the same name!\n");
                    break;

                case 2:
                    EditPerson(persons.GetByName(GetString("edit person", "Type person name")));
                    break;

                case 3:
                    RemovePerson(persons);
                    break;

                case 4:
                    ShowRegisteredPersons(persons);
                    break;

                case 5:
                    ShowRegisteredPerson(persons);
                    break;
            }

            Pause();

        } while (command != 0);

        PrintBetweenColor("\t\t     ------------ Exiting ------------\n");
    }
}