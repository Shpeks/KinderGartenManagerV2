namespace DAL.Entities.MenuModels
{
    public class Meal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MenuFood> MenuFoods { get; set; }
    }
}
