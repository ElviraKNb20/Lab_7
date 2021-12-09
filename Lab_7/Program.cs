using System;
using System.Collections.Generic;

namespace Lab_7
{
    class City
    {
        public string name { get; set; }

        public City(string name)
        {
            this.name = name;
        }
    }

    class Building : City
    {
        public string street { get; set; }
        public int houseNumber { get; set; }
        public double totalSquare { get; }
        public double payment { get; set; }

        public Building(string name, string street, int houseNumber, double totalSquare, double payment) : base(name)
        {
            this.street = street;
            this.houseNumber = houseNumber;
            this.totalSquare = totalSquare;
            this.payment = payment;
        }
    }

    class Rooms : Building
    {
        public int number { get; set; }
        public double square { get; set; }

        public Rooms(string name, string street, int houseNumber, double totalSquare, double payment, int number, double square) : base(name, street, houseNumber, totalSquare, payment)
        {
            this.number = number;
            this.square = square;
            try
            {
                if (square == 0 || square < 0)
                {
                    throw new PloschaException($"ПОМИЛКА: Неможливо створити примiщення (зазначено некоректне значення площi - {square})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void PaymentApartment()
        {
            try
            {
                if (square == 0 || square < 0)
                {
                    throw new PloschaException($"ПОМИЛКА: Неможливо створити примiщення (зазначено некоректне значення площi - {square})");
                }
                else
                {
                    double res = Math.Round(payment * square, 2);
                    Console.WriteLine($"Цiна за оплату примiщення = {res} грн");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Flat : Rooms
    {
        public List<string> fullName = new List<string>();
        public Flat(string name, string street, int houseNumber, double totalSquare, double payment, int number, double square) : base(name, street, houseNumber, totalSquare, payment, number, square) { }
        string x;

        public void Add()
        {
            try
            {
                Console.WriteLine($"Квартира {number}");
                Console.Write("Щоб додати мешканця у квартиру введiть лiтеру т, в iншому випадку введiть будь-що окрiм лiтери т: ");
                x = Console.ReadLine();
                while (x == "т")
                {
                    int q = -1; q++;
                    Console.WriteLine();
                    Console.Write($"ПIБ мешканця {fullName.Count + q}: ");
                    fullName.Add(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Додати ще мешканця?");
                    x = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Remove()
        {
            try
            {
                if (fullName.Count == 0)
                {
                    throw new KilkistException($"ПОМИЛКА: Вiдсутнiсть мешканцiв у квартирi");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Щоб видалити мешканця з квартири введiть лiтеру т, в iншому випадку введiть будь-що окрiм лiтери т: ");
                    x = Console.ReadLine();
                    while (x == "т")
                    {
                        Console.WriteLine();
                        Console.Write("Введiть номер особи: ");
                        int a = Convert.ToInt16(Console.ReadLine());
                        fullName.RemoveAt(a);
                        Console.WriteLine();
                        Console.WriteLine("Видалити ще мешканця?");
                        x = Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void People()
        {
            try
            {
                if (fullName.Count != 0)
                {
                    Console.WriteLine();
                    Console.Write($"У квартрi {number} мешкає: "); ;
                    for (int i = 0; i < fullName.Count; i++)
                    {
                        Console.Write($"{fullName[i]}, ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
        public string Output()
        {
            try
            {
                Console.WriteLine($"Мiсто: {name}, вулиця: {street} {houseNumber}");
                Console.WriteLine($"Загальна площа будинку: {totalSquare}, базова щомiсячна оплата за кв.м площi {payment}");
                Console.WriteLine($"Номер квартири: {number}, площа квартири: {square}");
                PaymentApartment();
                Console.WriteLine();
                Add();
                Remove();
                People();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Office : Rooms
    {
        public string firm { get; set; }
        public string activity { get; set; }
        public Office(string name, string street, int houseNumber, double totalSquare, double payment, int number, double square, string firm, string activity) : base(name, street, houseNumber, totalSquare, payment, number, square)
        {
            this.firm = firm;
            this.activity = activity;
        }
        public string Output()
        {
            try
            {
                Console.WriteLine($"Назва фiрми: {firm}, вид дiяльностi: {activity}");
                Console.WriteLine($"Мiсто: {name}, вулиця: {street} {houseNumber}");
                Console.WriteLine($"Загальна площа примiщення фiрми: {totalSquare}, базова щомiсячна оплата за кв.м площi {payment}");
                square = totalSquare;
                PaymentApartment();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class KilkistException : Exception
    {
        public KilkistException(string aMessage) : base(aMessage) { }
    }
    class PloschaException : Exception
    {
        public PloschaException(string aMessage) : base(aMessage) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            City[] city = {
            new Flat("Кам'янець-Подiльський", "Драй-Хмари", 8, 728.33, 4.752, 1, 42.5),
            new Flat("Кам'янець-Подiльський", "Драй-Хмари", 8, 728.33, 4.752, 2, 0),
            };

            City[] city2 = {
            new Office("Львiв", "Алмазна", 7, 2967.78, 13.157, 0, 0, "ТОВ ЛьвiвБуд", "будiвництво"),
            new Office("Львiв", "Бузкова", 13, 4971, 18.097, 0, 0, "ТОВ ЛьвiвАвто", "виготовлення автiвок")
            };

            foreach (Flat str in city)
            {
                Console.WriteLine(str.Output());
            }
            foreach (Office str in city2)
            {
                Console.WriteLine(str.Output());
            }
        }
    }
}