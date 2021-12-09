using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PrizesDAO: IPrizesDAO
    {
        private readonly string connectionString;

        public PrizesDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private const string AddPrizeSql = "INSERT INTO prizes(family_id, description, prize_title, milestone, max_prize, start_date, end_date) " +
            "VALUES(@family_id, @description, @prize_title', @milestone, @max_prize, @start_date, @end_date) ";
        public Prizes AddPrize(Prizes prizeToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(AddPrizeSql, conn))
                {

                    command.Parameters.AddWithValue("@family_id", prizeToAdd.familyId);
                    command.Parameters.AddWithValue("@description", prizeToAdd.decription);
                    command.Parameters.AddWithValue("@prize_title", prizeToAdd.prizeTitle);
                    command.Parameters.AddWithValue("@milestone", prizeToAdd.mileStone);
                    command.Parameters.AddWithValue("@max_prize", prizeToAdd.maxPrize);
                    command.Parameters.AddWithValue("@start_date", prizeToAdd.startDate);
                    command.Parameters.AddWithValue("@end_date", prizeToAdd.endDate);
                    command.ExecuteNonQuery();
                }

            }
            return prizeToAdd;
        }


    }
}
