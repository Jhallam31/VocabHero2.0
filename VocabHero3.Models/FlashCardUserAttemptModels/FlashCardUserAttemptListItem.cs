using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero3.Models.FlashCardUserAttemptModels
{
    public class FlashCardUserAttemptListItem
    {
        public string WordName { get; set; }

        [Display(Name = "Correct?")]
        public bool IsSuccessful { get; set; }

        [Display(Name = "XP gained")]
        public int XPGained { get; set; }
    }
}
