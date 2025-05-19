using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum MealTimeEnum
    {
        [Display(Name = "Завтрак")]
        Breakfast = 1,

        [Display(Name = "Второй завтрак")]
        SecondBreakfast = 2,

        [Display(Name = "Обед")]
        Lunch = 3,

        [Display(Name = "Полдник")]
        AfternoonSnack = 4,

        [Display(Name = "Ужин")]
        Dinner = 5
    }
}
