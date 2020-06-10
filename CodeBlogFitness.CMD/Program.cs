using System;
using System.Globalization;
using System.Resources;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.CMD

{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");

            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);


            Console.WriteLine(resourceManager.GetString("Hello",culture)); 

            Console.WriteLine(resourceManager.GetString("EnterName",culture));
            var name = Console.ReadLine();            


            var userController = new UserController(name);
            var eatingConttroller = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            Console.WriteLine(userController.CurrentUser);
            
            

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - Ввести прием пищи ");
                Console.WriteLine("A- Ввести упражненеия");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();


                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingConttroller.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingConttroller.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        // var exercise = new Exercise(exe.Begin, exe.End, exe.Activity, userController.CurrentUser);
                        exerciseController.Add(exe.Activity,exe.Begin,exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }
            }

            if (userController.IsnewUser)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();                
                DateTime birtDate =  ParseDateTime("Дата Рождения");
                double weight = ParseDouble("Вес");
                double height = ParseDouble("рост");
                //                while (DateTime.TryParse(Console.ReadLine(), out DateTime birtDate));

                var birthdate = DateTime.Parse(Console.ReadLine());

                userController.SetNewUserData(gender, birtDate, weight, height);

            }
            Console.ReadLine();
            
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения:");
            var name = Console.ReadLine();

            var energy = ParseDouble("Расход Энергии в минуту");
            var begin = ParseDateTime("начало упражненеия");
            var end = ParseDateTime("Окончание упражненения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
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

        private static DateTime ParseDateTime( string value)
        {
            DateTime birtDate;
            while (true)
            {
                Console.Write($"Введите {value}(dd.MM.yyyy):");

                if (DateTime.TryParse(Console.ReadLine(), out birtDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value }");
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
