using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.MenuModels
{
    public class MealTime
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public ICollection<MenuFood> MenuFoods { get; set; }
    } 
}
