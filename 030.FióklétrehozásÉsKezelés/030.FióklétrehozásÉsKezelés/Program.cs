using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _030.FióklétrehozásÉsKezelés
{
    class Program
    {
        public static string[][] profileData;

        static void Main(string[] args)
        {
            while (true) MainMenu();
            
        }

        // főmenű
        static void MainMenu()
        {
            Console.Clear();
            Console.Write("Belépés (1)\nFiók létrehozása (2)\nElfelejtett jelszó/felhasználónév (3)\nKilépés (0)\nNyomja meg a kivánt szolgáltatáshoz tartozó számot. ");

            char input = Console.ReadKey(true).KeyChar;
            switch (input)
            {
                case '1':
                    Login();
                    break;
                case '2':
                    Person.Register();
                    break;
                case '3':
                    // TODO elfelejtett jelszó, felhasználónév (emailen megadása + amit nem felejtett el)
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        // bejelentkezés
        static void Login()
        {

            Person personLogin = new Person();

            Console.Clear();
            Console.Write("Név vagy E-mail cím: ");
            string inpText = Console.ReadLine();
            for (int i = 0; i < profileData.Length; i++)
            {
                if (Person.profileData[i][0] == inpText || Person.profileData[i][2] == inpText)
                {
                    Console.Write("\nJelszó: ");
                    if (profileData[i][1] == PasswordEntry())
                    {
                        personLogin.name = profileData[i][0];
                        LoggedInMenu(personLogin);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Nincs ilyen nevű felhasználó regisztrálva vagy rossz jelszót adtál meg.");
        }

        // bejelentkezés menű
        static void LoggedInMenu(Person personLogin)
        {
            Console.Clear();
            Console.WriteLine("Üdvözöllek, {0}!\nJó látni téged.\n", personLogin.name);
            Console.WriteLine("Játék[1]\nProfil megtekintése[2]\nJelszó módosítás[3]\nKijelentkezés[0]");
            do
            {
                char keyChar;
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        //Game();
                        break;
                    case '2':
                        //ProfileShow();
                        break;
                    case '3':
                        //PasswordChange();
                        break;
                    case '0':
                        Console.WriteLine("Biztos ki szeretnél jelentkezni?\nIgen[0] Nem[1]");
                        while (true)
                        {
                            keyChar = Console.ReadKey(true).KeyChar;
                            if (keyChar == '0')
                            {
                                MainMenu();
                            }
                            if (keyChar == '1')
                            {
                                LoggedInMenu(personLogin);
                            }
                        }
                    default:
                        break;
                }
            } while (true);
        }

        // jelszó titkosítás
        public static string PasswordEntry(string prevPassword = "")
        {
            string password = "";
            bool done = false;
            int i = 0;

            do
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    if (password.Length >= 4)
                    {
                        done = true;
                    }
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    if (password.Length != 0)
                    {
                        Console.Write("\b \b");
                        password = password.Remove(password.Length - 1);
                        i--;
                    }
                }
                else
                {
                    password = password.Insert(i, cki.KeyChar.ToString());
                    Console.Write("*");
                    i++;
                }
            } while (!done);

            return password;
        }
    }

    class Person
    {
        public string name;
        public string password;
        public string email;
        public DateTime birthDate;

        private DateTime dateCreate;

        public DateTime DateCreate
        {
            get { return dateCreate; }
        }

        static public string[][] profileData;

        public Person()
        {
            dateCreate = DateTime.Now;

            profileData = new string[File.ReadAllLines("../../profiles.txt").Length][];
            for (int i = 0; i < profileData.Length; i++) profileData[i] = new string[5];
            PersonalDataLoad(ref profileData);
        }

        // profiladatok betöltése
        static void PersonalDataLoad(ref string[][] profileData)
        {
            int j = 0;
            StreamReader streamReader = new StreamReader("../../profiles.txt");
            while (!streamReader.EndOfStream)
            {
                profileData[j++] = streamReader.ReadLine().Split(',');
            }
            streamReader.Close();
            Program.profileData = profileData;
        }

        //// Regisztráció ////

        // regisztráció kezdete
        public static void Register()
        {
            Person personRegister = new Person();

            Console.Clear();

            NameConfirm(ref personRegister);
            PasswordConfirm(ref personRegister);
            Email(ref personRegister);
            BirthDate(ref personRegister);
            Confirm(personRegister);
        }

        // név
        static void NameConfirm(ref Person person)
        {
            bool nameProper = false;
            do
            {
                Console.Write("Név: ");
                person.name = Console.ReadLine();
                if (person.name.Length >= 4 && person.name.Length <= 16) nameProper = true;
                else if (person.name.Length < 4) Console.WriteLine("Túl rövid név (minimum karakterszám: 4)");
                else if (person.name.Length > 16) Console.WriteLine("Túl hosszú név (maximum karakterszám: 16)");
            } while (!nameProper);
        }

        // jelszó
        static void PasswordConfirm(ref Person person)
        {
            string passwordTerm = "";

            do
            {
                Console.Write("\nJelszó: ");
                person.password = Program.PasswordEntry();
                passwordTerm = person.password;
                Console.Write("\nJelszó megerősítése: ");
                person.password = Program.PasswordEntry(person.password);
                if (person.password != passwordTerm) Console.WriteLine("\nA jelszavak nem egyeznek.");
            } while (person.password != passwordTerm);
        }

        // E-mail
        static void Email(ref Person person)
        {
            bool acceptable = false;

            Console.WriteLine();
            do
            {
                Console.Write("\nEmail cím: ");
                person.email = Console.ReadLine().Trim();
                int indexofAt = person.email.IndexOf('@');
                if (
                    person.email.IndexOf(' ') == -1 &&
                    person.email.IndexOf('@') != -1 &&
                    person.email.IndexOf('.', indexofAt, person.email.Length - 1 - indexofAt) != -1)
                    acceptable = true;
                if (!acceptable) Console.WriteLine("Kérlek írj be helyesen az E-mail címet.");
            } while (!acceptable);
        }

        // születési dátum
        static void BirthDate(ref Person person)
        {
            bool parsed = false;
            Console.WriteLine("\nSzületési dátum (pl.: 1970 01 10 )");
            do
            {
                parsed = DateTime.TryParse(Console.ReadLine(), out person.birthDate);
                if (!parsed) Console.WriteLine("Kérlek írd be helyesen a születési dátumod!");
            } while (!parsed);
        }

        // regisztráció jóváhagyása
        static void Confirm(Person person)
        {
            char key;
            bool pressed = false;
            RegisterDataCheck(person);
            Console.WriteLine("\nFiók létrehozása[1]\nVisszalépés a Főmenübe[0]");
            while (!pressed)
            {
                key = Console.ReadKey(true).KeyChar;
                if (key == '1')
                {
                    ProfileCreate(person);
                    pressed = true;
                }
                if (key == '0')
                {
                    pressed = true;
                }
            }
        }

        // regisztrációs adatok ellenőrzése
        static void RegisterDataCheck(Person person)
        {
            bool profileDataError = false;

            if (0 < DateTime.Compare(person.birthDate.AddYears(18), DateTime.Now))
            {
                Console.WriteLine("Túl fiatal vagy a program használatához.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            for (int i = 0; i < profileData.Length; i++)
            {
                if (person.name == profileData[i][0])
                {
                    Console.WriteLine("Név használatban van, kérlek válassz másikat.");
                    profileDataError = true;
                    break;
                }
                if (person.email == profileData[i][2])
                {
                    Console.WriteLine("Az E-mail címet már használják, kérlek válassz másikat.");
                    profileDataError = true;
                    break;
                }
            }
            if (profileDataError)
            {
                Console.ReadKey();
                Register();
            }
        }

        // profil készítése
        static void ProfileCreate(Person p)
        {
            StreamWriter streamWriter = new StreamWriter("../../profiles.txt", true);
            streamWriter.WriteLine("{0},{1},{2},{3:yyyy.MM.dd.},{4:yyyy.MM.dd.}", p.name, p.password, p.email, p.birthDate, p.DateCreate);
            streamWriter.Flush();
            streamWriter.Close();
        }

    }
}
