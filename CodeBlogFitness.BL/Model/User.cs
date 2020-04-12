using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL;
namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    /// 
    [Serializable]
   public class User
    {
        /// <summary>
     /// Имя.
     /// </summary>
     /// 
        #region Свойства Пользователя
        public string Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public  Gender Gender { get ; }
        /// <summary>
        /// Дата Рождения.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        /// 
        public double Height { get; set; }
        
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender"> Пол.</param>
        /// <param name="birthDate">Дата Рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        /// 



        public User( string name ,
                     Gender gender,
                     DateTime birthDate,
                     double weight,
                     double height)
        {
            #region Проверка Условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или Null.", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null .",nameof(gender));
            }
            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше или равен нулю.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен нулю.", nameof(weight));
            }
            #endregion
                
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
