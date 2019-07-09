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
    public class AdjectiveService
    {

        public bool CreateAdjective(AdjectiveCreate model)
        {
            var entity = new Adjective()
            {
                AdjectiveID = model.AdjectiveID,
                AdjectiveWord = model.AdjectiveWord
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Adjectives.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AdjectiveDetail> GetAdjectives()
        {
            using (var ctx = new ApplicationDbContext())
            {
                IQueryable<AdjectiveDetail> query = ctx
                    .Adjectives
                   // .Where(e=>e.OwnerId == _userID)
                   .Select(e => new AdjectiveDetail
                   {
                       AdjectiveID = e.AdjectiveID,
                       AdjectiveWord = e.AdjectiveWord
                   });
                return query.ToArray();
            }
        }

        public AdjectiveEdit GetAdjectiveByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Adjectives
                    .Single(e => e.AdjectiveID == id);
                return new AdjectiveEdit
                {
                    AdjectiveID = entity.AdjectiveID,
                    AdjectiveWord = entity.AdjectiveWord
                };
            }
        }
        public bool UpdateAdjective(AdjectiveEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx
                    .Adjectives
                    .Single(e => e.AdjectiveID == model.AdjectiveID);

                entity.AdjectiveWord = model.AdjectiveWord;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdjective(int adjectiveID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Adjectives
                    .Single(e => e.AdjectiveID == adjectiveID);

                ctx.Adjectives.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public int GetNumberOfEntries(object t)
        {
            //get number of entries in a table, get a random one
            string PartOfSpeech = "Adjective";

            //using (var ctx = new ApplicationDbContext())

            //{

            string sqlquery = $"Select Count(*) from {PartOfSpeech};";
            //DbSqlQuery<Adjective> queryresults = ctx.Adjectives.SqlQuery($"Select Count({PartOfSpeech}ID) itemcount from {PartOfSpeech};");
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-SillyInsultsMVCWeb-20190703094431.mdf;Initial Catalog=SillyInsults;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlquery;
            cmd.Connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-SillyInsultsMVCWeb-20190703094431.mdf;Initial Catalog=SillyInsults;Integrated Security=True");
            cmd.Connection.Open();
            //cmd.Connection = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-SillyInsultsMVCWeb-20190703094431.mdf;Initial Catalog=SillyInsults;Integrated Security=True";
            int count = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            return count;



            // return queryresults.Single();

            //}


        }

    }
}

