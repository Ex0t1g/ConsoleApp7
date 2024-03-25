using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {

        public class Passport
        {
            private string number;
            private string ownerName;
            private DateTime issueDate;

            public string Number
            {
                get { return number; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Номер паспорта не может быть пустым.");
                    number = value;
                }
            }

            public string OwnerName
            {
                get { return ownerName; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("ФИО владельца не может быть пустым.");
                    ownerName = value;
                }
            }

            public DateTime IssueDate
            {
                get { return issueDate; }
                set
                {
                    if (value > DateTime.Now)
                        throw new ArgumentException("Дата выдачи не может быть в будущем.");
                    issueDate = value;
                }
            }

            public Passport(string number, string ownerName, DateTime issueDate)
            {
                Number = number;
                OwnerName = ownerName;
                IssueDate = issueDate;
            }
        }
        static void Main(string[] args)
        {
            int selection;
            do
            {
                Console.WriteLine("Выберите направление перевода: ");
                Console.WriteLine("1. Из десятичной в двоичную");
                Console.WriteLine("2. Из двоичной в десятичную");
                Console.WriteLine("0. Выход");
                selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        DecimalToBinary();
                        break;
                    case 2:
                        BinaryToDecimal();
                        break;
                    case 0:
                        Console.WriteLine("Выход");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }
            } while (selection != 0);
            Console.WriteLine("Введите слово от 0 до 9: ");
            string word = Console.ReadLine();

            int number;
            switch (word.ToLower())
            {
                case "zero":
                    number = 0;
                    break;
                case "one":
                    number = 1;
                    break;
                case "two":
                    number = 2;
                    break;
                case "three":
                    number = 3;
                    break;
                case "four":
                    number = 4;
                    break;
                case "five":
                    number = 5;
                    break;
                case "six":
                    number = 6;
                    break;
                case "seven":
                    number = 7;
                    break;
                case "eight":
                    number = 8;
                    break;
                case "nine":
                    number = 9;
                    break;
                default:
                    number = -1;
                    break;
            }

            if (number != -1)
            {
                Console.WriteLine("Результат: " + number);
            }
            else
            {
                Console.WriteLine("Неверный ввод.");
            }


            try
            {
                Passport passport = new Passport("123456789", "Иванов Иван Иванович", new DateTime(2022, 10, 15));
                Console.WriteLine("Паспорт успешно создан.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка создания паспорта: {ex.Message}");
            }
            try
            {
                Console.WriteLine("Введите логическое выражение: ");
                string expression = Console.ReadLine();

                bool result = CalculateExpression(expression);
                Console.WriteLine($"Результат: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка ввода выражения: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static bool CalculateExpression(string expression)
        {
            string[] operators = { "<", ">", "<=", ">=", "==", "!=" };

            foreach (string op in operators)
            {
                if (expression.Contains(op))
                {
                    string[] parts = expression.Split(new string[] { op }, StringSplitOptions.None);

                    if (parts.Length != 2)
                        throw new ArgumentException("Некорректное выражение.");

                    int leftOperand = int.Parse(parts[0]);
                    int rightOperand = int.Parse(parts[1]);

                    switch (op)
                    {
                        case "<":
                            return leftOperand < rightOperand;

                        case ">":
                            return leftOperand > rightOperand;

                        case "<=":
                            return leftOperand <= rightOperand;

                        case ">=":
                            return leftOperand >= rightOperand;

                        case "==":
                            return leftOperand == rightOperand;

                        case "!=":
                            return leftOperand != rightOperand;
                    }
                }
            }

            throw new ArgumentException("Некорректное выражение.");
        }

        static void DecimalToBinary()
        {
            Console.WriteLine("Введите десятичное число: ");
            int decimalNumber = Convert.ToInt32(Console.ReadLine());
            string binaryNumber = Convert.ToString(decimalNumber, 2);

            Console.WriteLine("Результат: " + binaryNumber);
        }

        static void BinaryToDecimal()
        {
            Console.WriteLine("Введите двоичное число: ");
            string binaryNumber = Console.ReadLine();

            try
            {
                int decimalNumber = Convert.ToInt32(binaryNumber, 2);
                Console.WriteLine("Результат: " + decimalNumber);
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
            }

        }


    }
}
