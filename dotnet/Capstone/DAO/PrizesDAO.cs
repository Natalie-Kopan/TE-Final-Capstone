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
            "VALUES(@family_id, @description, @prize_title, @milestone, @max_prize, @start_date, @end_date) ";
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

        
        const string GetPrizesByFamilyIDsql = "SELECT family_id, description, prize_title, milestone, max_prize, start_date, end_date FROM prizes WHERE family_id = @family_id";

        public List<Prizes> GetPrizes(int family_id)
        {
            List<Prizes> prizes = new List<Prizes>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(GetPrizesByFamilyIDsql, conn))
                {
                    command.Parameters.AddWithValue("@family_id", family_id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Prizes prize = new Prizes();
                            prize.decription = Convert.ToString(reader["description"]);
                            prize.prizeTitle = Convert.ToString(reader["prize_title"]);
                            prize.mileStone = Convert.ToInt32(reader["milestone"]);
                            prize.maxPrize = Convert.ToInt32(reader["max_prize"]);
                            prize.startDate = Convert.ToDateTime(reader["start_date"]);
                            prize.endDate = Convert.ToDateTime(reader["end_date"]);
                            prizes.Add(prize);
                        }
                    }
                }
            }
            return prizes;
        }


    }
}
