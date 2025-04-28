namespace Core.DTOs.MenuModels
{
    public class MenuDTO
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Ясли/Сад
        /// </summary>
        public string TypeChild { get; set; }

        public int CountChild { get; set; }

        public int UserId { get; set; }
    }
}
