using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero3.Data.Tables
{
    public class UserFlashCard
    {
        [Key]
        public int UserFlashCardId { get; set; }
        //FlashCard FK
        [ForeignKey("Word")]
        public int WordId { get; set; }
        public virtual Word Word { get; set; }

        //User FK
        [ForeignKey("ApplicationUser")]

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //Attempts collection--> UserFlashCard has a one(card) to many(attempts) relationship with UserCardAttempt.cs
        public ICollection<FlashCardUserAttempt> UserAttempts { get; set; }
        public ICollection<UserFlashCard> UserFlashCards { get; set; }
    }
}
