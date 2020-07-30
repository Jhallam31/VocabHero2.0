using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero3.Data;
using VocabHero3.Data.Tables;
using VocabHero3.Models.FlashCardUserAttemptModels;

namespace VocabHero3.Services
{
    public class FlashCardUserAttemptService
    {
        private readonly string _userId;
        public FlashCardUserAttemptService() { }
        public bool CreateFlashCardUserAttempt(FlashCardUserAttemptCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (model.Guess != model.UserFlashCard.WordName)
                {
                    var entity =
                    new FlashCardUserAttempt()

                    {
                        Guess = model.Guess,
                        UserFlashCardId = model.UserFlashCard.UserFlashCardId,
                        XPGained = 0,
                        IsSuccessful = false,

                    };

                    ctx.FlashCardUserAttempts.Add(entity);
                    return ctx.SaveChanges() == 1;

                }
                else
                {
                    var entity =
                    new FlashCardUserAttempt()

                    {
                        Guess = model.Guess,
                        UserFlashCardId = model.UserFlashCard.UserFlashCardId,
                    //Sets the value of XPGained as equal to 2 times the character length of the assigned word.
                    XPGained = 2 * ((model.UserFlashCard.WordName).Length),
                        IsSuccessful = true,

                    };

                    ctx.FlashCardUserAttempts.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }


        public IEnumerable<FlashCardUserAttemptListItem> GetFlashCardUserAttempts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FlashCardUserAttempts
                        .Where(e => e.UserFlashCardId == e.UserFlashCardId && e.UserFlashCard.ApplicationUser.Id == _userId)
                        .Select(
                            e =>
                                new FlashCardUserAttemptListItem
                                {
                                    WordName = e.UserFlashCard.Word.WordName,
                                    IsSuccessful = e.IsSuccessful,
                                    XPGained = e.XPGained,
                                }
                        );

                return query.ToArray();
            }
        }

        //Update not needed. I do not want the ability to update an attempt.

        //public bool UpdateFlashCardUserAttempt(FlashCardUserAttemptEdit model, int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .UserFlashCards
        //                .Single(e => e.UserCardId == id && e.AppUser.Id == _userId);
        //        entity.FlashCard.FlashCardId = model.FlashCardId;


        //        return ctx.SaveChanges() == 1;
        //    }
        //}




        public FlashCardUserAttemptDetail GetFlashCardUserAttemptById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FlashCardUserAttempts
                        .Single(e => e.FlashCardUserAttemptId == id);
                return
                    new FlashCardUserAttemptDetail
                    {
                        WordName = entity.UserFlashCard.Word.WordName,
                        Definition = entity.UserFlashCard.Word.Definition,
                        PartOfSpeech = entity.UserFlashCard.Word.PartOfSpeech,
                        IsSuccessful = entity.IsSuccessful,
                        XPGained = entity.XPGained

                    };
            }
        }
        //Delete not needed. I do not want the ability to delete attempts.


        //public bool DeleteUserFlashCard(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .UserFlashCards
        //                .Single(e => e.UserCardId == id && e.AppUser.Id == _userId);

        //        ctx.UserFlashCards.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
        //public string GetUserID()
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    string userId = user.Id;
        //    return userId;

        //}
    }
}
