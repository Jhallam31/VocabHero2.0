using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero3.Data.Tables;

namespace VocabHero3.Models.FlashCardUserAttemptModels
{
    public class FlashCardUserAttemptDetail
    {
        public string WordName { get; set; }
        public string Definition { get; set; }
        public string Guess { get; set; }

        [Display(Name = "XP gained")]
        public int XPGained { get; set; }

        [Display(Name = "Part of Speech")]
        public PartOfSpeech PartOfSpeech { get; set; }

        [Display(Name = "Correct?")]
        public bool IsSuccessful { get; set; }
    }
}
