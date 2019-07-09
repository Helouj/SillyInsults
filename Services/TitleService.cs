using Data;
using Models;
using SillyInsultsMVCWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TitleService
    {

        public bool CreateTitle(TitleCreate model)
        {
            var entity = new Title()
            {
                TitleID = model.TitleID,
                TitleWord = model.TitleWord
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Titles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TitleDetail> GetTitles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                IQueryable<TitleDetail> query = ctx
                    .Titles
                   // .Where(e=>e.OwnerId == _userID)
                   .Select(e => new TitleDetail
                   {
                       TitleID = e.TitleID,
                       TitleWord = e.TitleWord
                   });
                return query.ToArray();
            }
        }

        public TitleEdit GetTitleByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                 var entity = ctx
                    .Titles
                    .Single(e => e.TitleID == id);
                return new TitleEdit
                {
                    TitleID = entity.TitleID,
                    TitleWord = entity.TitleWord
                };
            }
        }
        public bool UpdateTitle(TitleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx
                    .Titles
                    .Single(e => e.TitleID == model.TitleID);

                entity.TitleWord = model.TitleWord;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTitle(int titleID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Titles
                    .Single(e => e.TitleID == titleID);

                ctx.Titles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        

    }
}
