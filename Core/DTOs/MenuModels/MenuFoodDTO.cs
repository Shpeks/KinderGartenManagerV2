namespace Core.DTOs.MenuModels
{
    public class MenuFoodDTO
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

        public int MealTimeId { get; set; }

        public int UnitId { get; set; }

        public int MenuId { get; set; }
    }
}
