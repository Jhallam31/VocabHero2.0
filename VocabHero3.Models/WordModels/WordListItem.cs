﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero3.Data.Tables;

namespace VocabHero3.Models.WordModels
{
    public class WordListItem
    {
        public int WordId { get; set; }
        public string WordName { get; set; }
        public string Definition { get; set; }

        [Display(Name = "Part of Speech")]
        public PartOfSpeech PartOfSpeech { get; set; }
    }
}
