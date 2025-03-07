namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();

            //Task2();

            //Task3();

            //Task4();
        }

        //1
        static void Task1()
        {
            try
            {
                Console.WriteLine("Введите число: ");
                string input = Console.ReadLine();
                Console.WriteLine("Введите основание исходной системы счисления: ");
                int fromB = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите основание целевой системы счисления: ");
                int ToB = int.Parse(Console.ReadLine());

                int number = Convert.ToInt32(input, fromB);
                string result = Convert.ToString(number, ToB);

                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        //2
        static void Task2()
        {
            Dictionary<string, int> wordto = new Dictionary<string, int>
        {
            {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
            {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
        };

            Console.WriteLine("(от zero до nine): ");
            string input = Console.ReadLine().ToLower();

            if (wordto.TryGetValue(input, out int digit))
            {
                Console.WriteLine($"Цифра: {digit}");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        //3
        static void Task3()
        {
            try
            {
                Console.WriteLine("Введите номер паспорта:");
                string passportNum = Console.ReadLine();
                Console.WriteLine("Введите ФИО:");
                string Name = Console.ReadLine();
                Console.WriteLine("Введите дату выдачи (гггг-мм-дд):");
                DateTime Date = DateTime.Parse(Console.ReadLine());

                Passport passport = new Passport(passportNum, Name, Date);
                Console.WriteLine("Паспорт успешно создан!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        class Passport
        {
            public string PassportNum { get; }
            public string Nume { get; }
            public DateTime Date { get; }

            public Passport(string passportNum, string Name, DateTime Date)
            {
                if (string.IsNullOrWhiteSpace(passportNum))
                    throw new ArgumentException("Номер паспорта не может быть пустым");
                if (string.IsNullOrWhiteSpace(Name))
                    throw new ArgumentException("ФИО не может быть пустым");
                if (Date > DateTime.Now)
                    throw new ArgumentException("Дата выдачи не может быть в будущем");

                PassportNum = passportNum;
                Nume = Name;
                this.Date = Date;
            }
        }

        //4
        static bool Task4(string Task)
        {
            string[] operatrs = { ">=", "<=", "!=", "==", ">", "<" };
            foreach (string op in operatrs)
            {
                if (Task.Contains(op))
                {
                    string[] parts = Task.Split(new string[] { op }, StringSplitOptions.None);
                    if (parts.Length == 2 && int.TryParse(parts[0], out int left) && int.TryParse(parts[1], out int right))
                    {
                        return op switch
                        {
                            ">" => left > right,
                            "<" => left < right,
                            ">=" => left >= right,
                            "<=" => left <= right,
                            "==" => left == right,
                            "!=" => left != right,
                            _ => throw new Exception("Неизвестный оператор")
                        };
                    }
                }
            }
            throw new Exception("Error");
        }
    }
}

