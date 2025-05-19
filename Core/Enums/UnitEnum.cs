using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum UnitEnum
    {
        [Display(Name = "Кг"), Description("Килограмм")]
        Kg = 1,

        [Display(Name = "Г"), Description("Грамм")]
        G = 2,

        [Display(Name = "Л"), Description("Литр")]
        L = 3,

        [Display(Name = "Мл"), Description("Миллилитр")]
        Ml = 4,

        [Display(Name = "Шт"), Description("Штука")]
        Pc = 5
    }
}
