using Ex27_PhoneBookPersistence;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Reflection;

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

    static void SavePersons(PersonList persons)
    {
        persons.GetAll().Sort(new ObjectByNameComparer());

        if (CheckPathing(personFilePath))
        {
            StreamWriter writer = new(absolutePath + personFilePath);
            AddressList addresses = new();
            PhoneList phones = new();

            foreach (var person in persons.GetAll())
            {
                writer.WriteLine(person.FormatToSave());
                addresses.Add(person.Address);
                
                foreach (var phone in person.Phones.GetAll())
                    phones.Add(phone);
            }

            writer.Close();
            SaveAddresses(addresses);
            SavePhones(phones);
        }

    }

    static void SavePhones(PhoneList phones)
    {
        if (CheckPathing(phoneFilePath))
        {
            StreamWriter writer = new(absolutePath + phoneFilePath);

            foreach (var phone in phones.GetAll())
                writer.WriteLine(phone.FormatToSave());

            writer.Close();
        }
    }

    static void SaveAddresses(AddressList addresses)
    {
        if (CheckPathing(addressFilePath))
        {
            StreamWriter writer = new(absolutePath + addressFilePath);

            foreach (var address in addresses.GetAll())
                writer.WriteLine(address.FormatToSave());

            writer.Close();
        }
    }

    static PersonList LoadPersons()
    {
        PersonList persons = new();

        if (CheckPathing(personFilePath))
        {
            string[] person;

            foreach (var line in File.ReadAllLines(absolutePath + personFilePath))
            {
                person = line.Split(";");
                persons.Add(new Person(int.Parse(person[0]), person[1], person[2]));
            }
            
            foreach (Address address in LoadAddresses().GetAll())
                persons.GetById(address.PersonId).Address = address;

            foreach (Phone phone in LoadPhones().GetAll())
                persons.GetById(phone.PersonId).Phones.Add(phone);
        }

        return persons;
    }

    static PhoneList LoadPhones()
    {
        PhoneList phones = new();

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

    static AddressList LoadAddresses()
    {
        AddressList Addresses = new();

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

    static int LoadIdCounter(List<Person> persons)
    {
        int id = 0;

        foreach (Person person in persons)
            if (id < person.Id)
                id = person.Id;

        return id + 1;
    }

    static PhoneList RegisterPhones(int personId)
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

    static Address RegisterAddress(int personId)
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
        
        return new(personId, GetString(title, "Type name"), GetString(title, "Type email"), RegisterPhones(personId), RegisterAddress(personId));
    }

    static Person? EditPerson(Person person)
    {
        Person? newPerson = null;

        if (person != null)
        {
            newPerson = new(person.Id, person.Name, person.Email, person.Phones, person.Address);

            int menuOption, auxOption;
            string title = "person edit";
            string command;

            do
            {
                menuOption = GetMenu(title, "Option", 2, 0, 4);

                switch (menuOption)
                {
                    case 1:
                        Console.Write($"\n\t\tCurrent name: ");
                        PrintBetweenColor($"{newPerson.Name}\n");
                        Pause();

                        newPerson.Name = GetString(title, "new name");
                        break;

                    case 2:
                        if (!newPerson.Phones.IsEmpty())
                        {
                            int index = 0;

                            do
                            {
                                do
                                {
                                    ClearScreen();
                                    ShowTitle(title);

                                    foreach (var phone in newPerson.Phones.GetAll())
                                        Console.WriteLine($"\t\t[{++index}] {phone}");

                                    Console.Write($"\n\t\tSelect a number by its index: ");
                                    command = Console.ReadLine();

                                } while (!int.TryParse(command, out auxOption));

                            } while (auxOption < 1 || auxOption > person.Phones.GetAll().Count + 1);

                            if (newPerson.Phones.Update(newPerson.Phones.GetPhoneByIndex(auxOption - 1), new Phone(newPerson.Id, GetString(title, "type a new phone number"))))
                                PrintBetweenColor("\n\t\t\tPhone successfully updated!\n");
                            else
                                PrintBetweenColor("\n\t\t\tPhone not found!\n");
                        }
                        else
                            PrintBetweenColor("\n\t\t\tPhone list is empty!\n");
                        break;

                    case 3:
                        do
                        {
                            do
                            {
                                ClearScreen();
                                ShowTitle(title);
                                ShowMenu(3);

                                Console.WriteLine(newPerson.Address.ToString());

                                Console.Write($"\n\t\tOption: ");
                                command = Console.ReadLine();

                            } while (!int.TryParse(command, out auxOption));

                        } while (auxOption < 0 || auxOption > 8);

                        switch (auxOption)
                        {
                            case 1:
                                newPerson.Address.ZipCode = GetString(title, "Type a new zip-code");
                                PrintBetweenColor("\n\t\t\tZip-code successfully updated!\n");
                                break;

                            case 2:
                                newPerson.Address.City = GetString(title, "Type a new city");
                                PrintBetweenColor("\n\t\t\tCity successfully updated!\n");
                                break;

                            case 3:
                                newPerson.Address.State = GetString(title, "Type a new state");
                                PrintBetweenColor("\n\t\t\tState successfully updated!\n");
                                break;

                            case 4:
                                newPerson.Address.PublicPlace = GetString(title, "Type a new public place");
                                PrintBetweenColor("\n\t\t\tPublic place successfully updated!\n");
                                break;

                            case 5:
                                newPerson.Address.PublicPlaceType = GetString(title, "Type a new public place type");
                                PrintBetweenColor("\n\t\t\tPublic place type successfully updated!\n");
                                break;

                            case 6:
                                newPerson.Address.Childhood = GetString(title, "Type a new childhood");
                                PrintBetweenColor("\n\t\t\tChildhood successfully updated!\n");
                                break;

                            case 7:
                                newPerson.Address.PlaceNumber = GetValue(title, "Type a new number", 1, 1);
                                PrintBetweenColor("\n\t\t\tNumber successfully updated!\n");
                                break;

                            case 8:
                                newPerson.Address.Complement = GetString(title, "Type a new complement");
                                PrintBetweenColor("\n\t\t\tComplement successfully updated!\n");
                                break;

                            default:
                                PrintBetweenColor("\n\t\t\tOperation cancelled!");
                                break;
                        }

                        break;

                    case 4:
                        Console.Write($"\n\t\tCurrent email: ");
                        PrintBetweenColor($"{newPerson.Email}\n");
                        Pause();

                        newPerson.Email = GetString(title, "Type new email");
                        PrintBetweenColor("\n\t\tEmail successfully updated");
                        break;
                }

            } while (menuOption != 0);

            PrintBetweenColor("\n\t\t\t     Operation cancelled!\n");
        }
        else
            PrintBetweenColor("\n\t\t\t\tPerson not found!\n");

        return newPerson;
    }

    static bool RemovePerson(PersonList personList)
    {
        if (personList.IsEmpty())
            return false;

        string title = "remove person";

        string command;
        int selectedIndex;

        do
        {
            do
            {
                ClearScreen();
                ShowTitle(title);
                Console.WriteLine();
                int index = 0;

                PrintBetweenColor("\t\t[0]", " Cancel\n");

                foreach (var person in personList.GetAll())
                    PrintBetweenColor($"\t\t[{++index}]", $" {person.Name}\n");

                Console.Write($"\n\t\tSelect a name by a valid index: ");
                command = Console.ReadLine();
            } while (!int.TryParse(command, out selectedIndex));

        } while (selectedIndex < 0 || selectedIndex > personList.GetAll().Count);

        if (selectedIndex == 0)
            return false;

        personList.Remove(personList.GetByIndex(selectedIndex - 1));

        return true;
    }

    static bool ShowRegisteredPersons(PersonList personList)
    {
        if (!personList.IsEmpty()) 
        {
            int index = 0;
            PrintBetweenColor("\n\t\t\t     REGISTERED PERSONS\n");

            while (personList.GetAll().Count != index)
            {
                Person aux = personList.GetByIndex(index++);

                PrintBetweenColor("\n\t\t\t           Info               ");
                Console.WriteLine($"\n\t\t\t   Name..............: {aux.Name}" +
                                  $"\n\t\t\t   Email.............: {aux.Email}");
                PrintBetweenColor("\n\t\t\t           Phones               ");
                foreach (Phone phone in aux.Phones.GetAll())
                    Console.WriteLine(phone.ToString());
                PrintBetweenColor("\n\t\t\t          Address           ");
                Console.WriteLine(aux.Address.ToString());
            }

            return true;
        }

        return false; 
        }

    static bool ShowRegisteredPerson(PersonList persons)
    {
        if (!persons.IsEmpty())
        {
            foreach (Person person in persons.GetAll())
                Console.WriteLine(person.ToString());

            Pause();

            Person? aux = persons.GetByName(GetString("show data", "Type a name to find"));

            if (aux != null) 
            {
                PrintBetweenColor("\n\t\t\t           Info               ");
                Console.WriteLine($"\n\t\t\t   Name..............: {aux.Name}" +
                                  $"\n\t\t\t   Email.............: {aux.Email}");
                PrintBetweenColor("\n\t\t\t           Phones               ");

                foreach (Phone phone in aux.Phones.GetAll())
                    Console.WriteLine(phone.ToString());

                PrintBetweenColor("\n\t\t\t          Address           ");
                Console.WriteLine(aux.Address.ToString());
            
                return true;
            }
        }

        return false;
    }

    private static void Main(string[] args)
    {
        string title = "main page";

        PersonList persons = LoadPersons();

        int personIdCounter = LoadIdCounter(persons.GetAll());
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
                        PrintBetweenColor("\n\t\t\tPerson successfully registered!\n");
                    else
                        PrintBetweenColor("\n\t\t\t   You already have a person with the same name!\n");
                    break;

                case 2:
                    if (!persons.IsEmpty())
                    {
                        Person oldPerson = persons.GetByName(GetString("edit person", "Type person name"));

                        if (oldPerson != null)
                        {
                            Person updatedPerson = EditPerson(oldPerson);

                            persons.Update(oldPerson, updatedPerson);

                            PrintBetweenColor("\n\t\t\tPerson successfully updated!\n");
                        }
                        else
                            PrintBetweenColor("\n\t\t\t\tPerson not found!\n");
                    }
                    else
                        PrintBetweenColor("\n\t\t\tYou don't have persons registered!\n");
                    break;

                case 3:
                    if (RemovePerson(persons))
                        PrintBetweenColor("\n\t\t\t   Person successfully removed!\n");
                    else
                        PrintBetweenColor("\n\t\t\t      Operation cancelled!\n");
                    break;

                case 4:
                    if (!ShowRegisteredPersons(persons))
                        PrintBetweenColor("\n\t\t\tYou don't have persons registered!\n");
                    break;

                case 5:
                    if (!ShowRegisteredPerson(persons))
                       PrintBetweenColor("\n\t\t\t  Failed to show person data!\n");
                    break;
            }

            SavePersons(persons);
            Pause();

        } while (command != 0);

        PrintBetweenColor("\t\t     ------------ Exiting ------------\n");
    }
}