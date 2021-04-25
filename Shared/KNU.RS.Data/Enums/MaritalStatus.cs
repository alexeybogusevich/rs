using System.ComponentModel;

namespace KNU.RS.Data.Enums
{
    public enum MaritalStatus
    {
        [Description("Інформація відсутня")]
        NoInformation = 0,
        [Description("Одружений (заміжня)")]
        Married = 1,
        [Description("Неодружений (незаміжня)")]
        NotMarried = 2
    }
}
