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
        public int GetNumberOfEntries(object t)
        {
            //get number of entries in a table, get a random one
            string PartOfSpeech = "Noun";
            
            //using (var ctx = new ApplicationDbContext())

            //{
                
                string sqlquery = $"Select Count(*) from {PartOfSpeech};";
                //DbSqlQuery<Noun> queryresults = ctx.Nouns.SqlQuery($"Select Count({PartOfSpeech}ID) itemcount from {PartOfSpeech};");
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
