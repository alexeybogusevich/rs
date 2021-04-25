using System.ComponentModel;

namespace KNU.RS.Data.Enums
{
    public enum EducationStatus
    {
        [Description("Інформація відсутня")]
        NoInformation = 0,
        [Description("Початкова освіта")]
        Primary = 1,
        [Description("Середня освіта")]
        Secondary = 2,
        [Description("Вища освіта")]
        Higher = 3
    }
}
