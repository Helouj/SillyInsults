﻿using Data;
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
    public class NounService
    {

        public bool CreateNoun(NounCreate model)
        {
            var entity = new Noun()
            {
                NounID = model.NounID,
                NounWord = model.NounWord
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nouns.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NounDetail> GetNouns()
        {
            using (var ctx = new ApplicationDbContext())
            {
                IQueryable<NounDetail> query = ctx
                    .Nouns
                   // .Where(e=>e.OwnerId == _userID)
                   .Select(e => new NounDetail
                   {
                       NounID = e.NounID,
                       NounWord = e.NounWord
                   });
                return query.ToArray();
            }
        }

        public NounEdit GetNounByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Nouns
                    .Single(e => e.NounID == id);
                return new NounEdit
                {
                    NounID = entity.NounID,
                    NounWord = entity.NounWord
                };
            }
        }
        public bool UpdateNoun(NounEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx
                    .Nouns
                    .Single(e => e.NounID == model.NounID);

                entity.NounWord = model.NounWord;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNoun(int nounID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Nouns
                    .Single(e => e.NounID == nounID);

                ctx.Nouns.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
       

    }
}
