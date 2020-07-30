using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero3.Models.UserFlashCardModels
{
    public class UserFlashCardListItem
    {
        public int UserFlashCardId { get; set; }
        public string WordName { get; set; }
        public string Definition { get; set; }
        public int SuccessfulAttempts { get; set; }
        
    }
}
