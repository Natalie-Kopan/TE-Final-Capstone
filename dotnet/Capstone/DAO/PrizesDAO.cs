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
        private const string GetPrizesByFamilyIDsql = "SELECT prize_id, family_id, description, prize_title, milestone, max_prize, start_date, end_date FROM prizes WHERE family_id = @family_id";
        private const string DeletePrizeSql = "DELETE FROM prizes WHERE prize_id = @prize_id ";
        private const string EditPrizeSql = "UPDATE prizes SET description = @description, prize_title = @prize_title, max_prize = @max_prize, " +
            "milestone = @milestone, start_date = @start_date, end_date = @end_date WHERE prize_id = 2 ";

        public Prizes AddPrize(Prizes prizeToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(AddPrizeSql, conn))
                {

                    command.Parameters.AddWithValue("@family_id", prizeToAdd.familyId);
                    command.Parameters.AddWithValue("@description", prizeToAdd.description);
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
                            prize.prizeId = Convert.ToInt32(reader["prize_id"]);
                            prize.description = Convert.ToString(reader["description"]);
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
        public int DeletePrize(int prizeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(DeletePrizeSql, conn))
                {
                    command.Parameters.AddWithValue("@prize_id", prizeId);
                    command.ExecuteNonQuery();
                }
            }
            return prizeId;
        }

        public Prizes EditPrize(Prizes prize)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(EditPrizeSql, conn);
                cmd.Parameters.AddWithValue("@prize_id", prize.prizeId);
                cmd.Parameters.AddWithValue("@description", prize.description);
                cmd.Parameters.AddWithValue("@prize_title", prize.prizeTitle);
                cmd.Parameters.AddWithValue("@milestone", prize.mileStone);
                cmd.Parameters.AddWithValue("@max_prize", prize.maxPrize);
                cmd.Parameters.AddWithValue("@start_date", prize.startDate);
                cmd.Parameters.AddWithValue("@end_date", prize.endDate);
                cmd.ExecuteScalar();
            }
            return prize;
        }
    }
}
