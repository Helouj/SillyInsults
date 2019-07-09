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
    public class SillyInsultService
    {

        public bool CreateSillyInsult(SillyInsultCR model)
        {
            var entity = new SillyInsultHistory()
            {
                SillyInsultHistoryID = model.SillyInsultHistoryID,
                AdjectiveWord = model.AdjectiveWord,
                NounWord = model.NounWord,
                TitleWord = model.TitleWord

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SillyInsults.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SillyInsultCR> GetSillyInsults()
        {
            using (var ctx = new ApplicationDbContext())
            {
                IQueryable<SillyInsultCR> query = ctx
                    .SillyInsults
                   // .Where(e=>e.OwnerId == _userID)
                   .Select(e => new SillyInsultCR
                   {
                       SillyInsultHistoryID = e.SillyInsultHistoryID,
                       AdjectiveWord = e.AdjectiveWord,
                       NounWord = e.NounWord,
                       TitleWord = e.TitleWord
                   }) ;
                return query.ToArray();
            }
        }

        public SillyInsultCR GetSillyInsultByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SillyInsults
                    .Single(e => e.SillyInsultHistoryID == id);
                return new SillyInsultCR
                {
                    SillyInsultHistoryID = entity.SillyInsultHistoryID,
                    AdjectiveWord = entity.AdjectiveWord,
                    NounWord = entity.NounWord,
                    TitleWord = entity.TitleWord
                };
            }
        }
        

        public bool DeleteSillyInsult(int sillyinsultHistoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SillyInsults
                    .Single(e => e.SillyInsultHistoryID == sillyinsultHistoryID);

                ctx.SillyInsults.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //public int GetNumberOfEntries(object t)
        //{

        //    string PartOfSpeech = "SillyInsult";

        //    string sqlquery = $"Select Count(*) from {PartOfSpeech};";

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = sqlquery;
        //    cmd.Connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-SillyInsultsMVCWeb-20190703094431.mdf;Initial Catalog=SillyInsults;Integrated Security=True");
        //    cmd.Connection.Open();

        //    int count = (int)cmd.ExecuteScalar();
        //    cmd.Connection.Close();
        //    return count;

        //}

    }
}
