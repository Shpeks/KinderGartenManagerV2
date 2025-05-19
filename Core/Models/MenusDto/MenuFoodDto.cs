namespace Core.Models.MenusDto
{
    public class MenuFoodDto
    {
        public int? Id { get; set; }

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

        public string MealName { get; set; }

        public int MealTimeId { get; set; }

        public string MealTimeName { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public int MenuId { get; set; }
    }
}
