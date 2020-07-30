using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero3.Data;
using VocabHero3.Data.Tables;
using VocabHero3.Models.UserFlashCardModels;

namespace VocabHero3.Services
{
    public class UserFlashCardService
    {
        private readonly string _userId;
        public UserFlashCardService(string userId)
        {
            _userId = userId;
        }
        public UserFlashCardService()
        {

        }
        public bool CreateUserFlashCard(UserFlashCardCreate model)
        {

            var entity =
                new UserFlashCard()

                {

                    WordId = model.WordId,
                    UserId = model.UserId
                };
            using (var db = new ApplicationDbContext())
            {
                db.UserFlashCards.Add(entity);
                return db.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserFlashCardListItem> GetUserFlashCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserFlashCards
                        .Where(e => e.UserFlashCardId == e.UserFlashCardId && e.ApplicationUser.Id == _userId)
                        .Select(
                            e =>
                                new UserFlashCardListItem
                                {
                                    UserFlashCardId = e.UserFlashCardId,
                                    Definition = e.Word.Definition,
                                    WordName = e.Word.WordName
                                }
                        );

                return query.ToArray();
            }
        }
        public bool UpdateUserFlashCard(UserFlashCardEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserFlashCards
                        .Single(e => e.UserFlashCardId == id && e.ApplicationUser.Id == _userId);
                entity.Word.WordId = model.WordId;


                return ctx.SaveChanges() == 1;
            }
        }
        public UserFlashCardDetail GetUserFlashCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserFlashCards
                        .Single(e => e.UserFlashCardId == id);
                return
                    new UserFlashCardDetail
                    {
                        UserFlashCardId = entity.UserFlashCardId,

                        WordName = entity.Word.WordName,
                        Definition = entity.Word.Definition,
                        PartOfSpeech = entity.Word.PartOfSpeech

                    };
            }
        }
        public bool DeleteUserFlashCard(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserFlashCards
                        .Single(e => e.UserFlashCardId == id && e.ApplicationUser.Id == _userId);

                ctx.UserFlashCards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
