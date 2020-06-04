using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User user;
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        
        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользвоатель не может быть пустым", nameof(user));

            Foods = GetAllFoods();

            Eating = GetEating();
        }


        public void Add( Food food , double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);  
            if( product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();

            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
            //var formatter = new BinaryFormatter();

            //using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
            //{
            //    //   fs.Length;

            //    if (fs.Length > 0 && formatter.Deserialize(fs) is List<Food> foods)
            //    {
            //        return foods;
            //    }
            //    else
            //    {
            //        return new List<Food>();
            //    }
            //    // TODO: Что делать, если пользователя не прочитали? 
            //}
        }

        private  void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
            //var formatter = new BinaryFormatter();

            //using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, Foods);
            //}
        }
    }
}
