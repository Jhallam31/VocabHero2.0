using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero3.Models.UserFlashCardModels;

namespace VocabHero3.Models.FlashCardUserAttemptModels
{
    public class FlashCardUserAttemptCreate
    {
        public int UserAttemptId { get; set; }

        [Display(Name = "Correct?")]
        public bool IsSuccessful { get; set; }
        public string Guess { get; set; }

        [Display(Name = "XP gained")]
        public int XPGained { get; set; }
        public UserFlashCardDetail UserFlashCard { get; set; }
    }
}
