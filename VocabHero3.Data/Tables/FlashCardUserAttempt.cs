using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero3.Data.Tables
{
    public class FlashCardUserAttempt
    {
        [Key]
        public int FlashCardUserAttemptId { get; set; }

        [Display(Name = "Correct?")]
        public bool IsSuccessful { get; set; }

        //UserFlashCard FK --> FCUA has a many(attempts) to one(flashcard) relationship with UserFlashCard
        [ForeignKey("UserFlashCard")]
        public int UserFlashCardId { get; set; }
        public virtual UserFlashCard UserFlashCard { get; set; }

        //STRETCH GOAL: Add logic in service layer to calculate RankAdd instead of initializing a static value
        [Display(Name = "XP Gained")]
        public int XPGained { get; set; }


        public string Guess { get; set; }
    }
}
