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
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController: ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users  { get; }

        public User CurrentUser { get; }

        public bool IsnewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name user is Empty", nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);

                Users.Add(CurrentUser);
                IsnewUser = true;
                Save(); 

            }

        }
        /// <summary>
        /// Получить сохранненій список пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
             return Load<List<User>>(USERS_FILE_NAME)?? new List<User>();

            //var formatter = new BinaryFormatter();

            //using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            //{
            // //   fs.Length;

            //    if ( fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
            //    {
            //       return users;
            //    }
            //    else
            //    {
            //        return new List<User>();
            //    }
            //    // TODO: Что делать, если пользователя не прочитали? 
            //}
        }


        public void SetNewUserData(string genderName,DateTime birtDate,double weight = 1, double height = 1)
        {
            // Проверка 

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birtDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
            //var formatter = new BinaryFormatter();

            //using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, Users);
            //}
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>

    }
}
