using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApplication.Context
{
    public class TournamentDAL 
    {
        readonly string connectionString = "Data Source = HTRI1574048L\\SQLEXPRESS; Initial Catalog = HollywoodTestDB; Integrated Security = SSPI; User ID = sa; Password = 123456789;";


        public void CreateTournament(Tournamet tournamet)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_Tournament", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@TournamentName", tournamet.TournamentName);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
