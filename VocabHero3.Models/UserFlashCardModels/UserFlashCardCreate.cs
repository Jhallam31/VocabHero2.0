using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero3.Models.UserFlashCardModels
{
    public class UserFlashCardCreate
    {
        public int UserFlashCardId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int WordId { get; set; }
    }
}
