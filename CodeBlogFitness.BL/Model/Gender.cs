using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    /// 
    [Serializable]
    public class Gender
    {       /// <summary>
            ///  Название   
            /// </summary>

        public int Id { get; set; }


        public string Name { get; set; }
        /// <summary>
        /// Cоздать новый пол.
        /// </summary>
        /// <param name="name"> Имя пола</param>


        public virtual ICollection<User> Users { get; set; }

        public Gender() { }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null ", nameof(name));
            }

            Name = name;

        }
        public override string ToString()
        {
            return Name  ;
        }
    }
}
