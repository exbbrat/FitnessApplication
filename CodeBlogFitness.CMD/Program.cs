using System;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.CMD

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();


            //Console.WriteLine("Введите пол");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Введите дату рождения");
            //var birthdate = DateTime.Parse(Console.ReadLine()); //TODO переписать

            //Console.WriteLine("Введите вес");
            //var weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Введите рост");
            //var height = double.Parse(Console.ReadLine());



            var userController = new UserController(name);
            var eatingConttroller = new EatingController(userController.CurrentUser);

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - Ввести прием пищи ");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
              var foods =   EnterEating();
                eatingConttroller.Add(foods.Food, foods.Weight);
                
                foreach(var item in eatingConttroller.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
             
            }

            if (userController.IsnewUser)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();

                DateTime birtDate =  ParseDateTime();
                double weight = ParseDouble("Вес");
                double height = ParseDouble("рост");
                //                while (DateTime.TryParse(Console.ReadLine(), out DateTime birtDate));

                var birthdate = DateTime.Parse(Console.ReadLine());

                userController.SetNewUserData(gender, birtDate, weight, height);

            }
            Console.ReadLine();

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();
            var calories = ParseDouble("калорийность");
            var prots= ParseDouble("белки");
            var fats = ParseDouble("жиры"); 
            var carbs =  ParseDouble("углеводы");


            var product = new Food(food,calories,prots,fats,carbs);
           
            var weight = ParseDouble("Вес порции ");

            return (Food: product, Weight: weight);

        }

        private static DateTime ParseDateTime()
        {
            DateTime birtDate;
            while (true)
            {
                Console.Write("Введите дату рождения(dd.MM.yyyy):");

                if (DateTime.TryParse(Console.ReadLine(), out birtDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }

            }

            return birtDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите{name}:");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                   return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат поля");
                }

            }

        }

    }
}   
