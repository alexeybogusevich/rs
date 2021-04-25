using System.ComponentModel;

namespace KNU.RS.Data.Enums
{
    public enum Occupation
    {
        [Description("Інформація відсутня")]
        NoInformation = 0,
        [Description("Працевлаштований")]
        Employed = 1, 
        [Description("Пенсіонер")]
        Pensioner = 2,
        [Description("Студент")]
        Student = 3,
        [Description("Непрацевлаштований")]
        Unemployed = 4,
        [Description("Інше")]
        Other = 5
    }
}
