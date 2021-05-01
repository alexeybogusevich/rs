using KNU.RS.Logic.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Recovery
{
    public class RecoveryDailyPlanModel
    {
        [Required(ErrorMessage = "Будь-ласка, введіть назву вправи.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Будь-ласка, надайте опис вправи.")]
        public string Description { get; set; }

        [PositiveInt(ErrorMessage = "Будь-ласка, вкажіть валідну кількість повторень.")]
        public int Times { get; set; }

        [NowAndOnDate(ErrorMessage = "Будь-ласка, вкажіть валідну дату для виконаня вправи.")]
        public DateTime Day { get; set; } = DateTime.Today;
    }
}
