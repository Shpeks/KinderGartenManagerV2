namespace KinderGartenManagerV2.Models.MenuModels
{
    public class MenuViewModel
    {
        public int? Id { get; set; }
        public int CountChild { get; set; }

        public string TypeChild { get; set; }
        public DateTime DateCreate { get; set; }

        public string FullName { get; set; }
    }
}
