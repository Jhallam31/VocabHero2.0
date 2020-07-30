using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero3.Data;
using VocabHero3.Data.Tables;
using VocabHero3.Models.UserFlashCardModels;
using VocabHero3.Models.WordModels;
using static VocabHero3.Data.ApplicationUser;

namespace VocabHero3.Services
{
    public class WordService
    {
        
        public bool CreateWord(WordCreate model)
        {
            var entity =
                new Word()

                {
                    WordId = model.WordId,
                    WordName = model.WordName,
                    Definition = model.Definition,
                    PartOfSpeech = model.PartOfSpeech
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Words.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WordListItem> GetWords()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Words
                        .Select(
                            e =>
                                new WordListItem
                                {
                                    WordId = e.WordId,
                                    WordName = e.WordName,
                                    Definition = e.Definition,
                                    PartOfSpeech = e.PartOfSpeech,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateWord(WordEdit model, string word)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Words
                        .Single(e => word == (e.WordName));
                entity.WordName = model.WordName;
                entity.Definition = model.Definition;
                entity.PartOfSpeech = model.PartOfSpeech;

                return ctx.SaveChanges() == 1;
            }
        }






        public WordDetail GetWordById(int id)
        {
            // we need to transform our collection of data objects into a collection data object models ie. UserFlashCardListItems
            //instantiate an empty list of our models
            List<UserFlashCardListItem> userFlashCardListItems = new List<UserFlashCardListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Words
                        .Single(e => e.WordId == id);
                //// iterate through the list, transform each data object into a data object model
                //// add each model to our list above

                if (entity.UserFlashCards == null)
                {
                    return
                    new WordDetail
                    {
                        WordId = entity.WordId,
                        WordName = entity.WordName,
                        Definition = entity.Definition,
                        PartOfSpeech = entity.PartOfSpeech,


                    };
                }
                else
                {


                    foreach (var item in entity.UserFlashCards)
                    {

                        var model = new UserFlashCardListItem()
                        {
                            UserFlashCardId = item.UserFlashCardId,
                            Definition = item.Word.Definition,
                            // SuccessfulAttempts = // calculate the successful attempts for the word
                        };

                        userFlashCardListItems.Add(model);
                    }

                    return
                        new WordDetail
                        {
                            WordId = entity.WordId,
                            WordName = entity.WordName,
                            Definition = entity.Definition,
                            PartOfSpeech = entity.PartOfSpeech,
                            UserFlashCards = userFlashCardListItems // assign to the property of our new data object model the value of the list we created above

                        };
                }
            }
        }

        public bool DeleteWord(string word)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Words
                        .Single(e => e.WordName == word);

                ctx.Words.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
