using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero3.Data.Tables
{
    public enum PartOfSpeech { Verb = 1, adverb, adjective, noun, pronoun, preposition, conjunction, interjection }
    public class Word
    {
        [Key]
        public int WordId { get; set; }

        [Required]
        public string WordName { get; set; }

        [Required]
        public string Definition { get; set; }

        [Display(Name = "Part of Speech")]
        public PartOfSpeech PartOfSpeech { get; set; }
        public List<UserFlashCard> UserFlashCards { get; set; }
    }
}
