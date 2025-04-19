using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.MenuModels
{
    public class MenuFood
    {
        public int Id { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество за единициу
        /// </summary>
        public double CountPerUnit { get; set; }

        /// <summary>
        /// MenuFood.CountPerUnit * Memu.ChildCount
        /// </summary>
        public double Count { get; set; }

        public int? Code { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }

        public int MealTimeId { get; set; }
        public MealTime MealTime { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
