using Dapper;
using QuantamLeap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuantamLeap.Data
{
    public class LeapeeRepository
    {
        const string ConnectionString = "Server = localhost; Database = QuantamLeap; Trusted_Connection = True;";

        public Leapee AddLeapee(string firstName, string lastName, string Event)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newLeapee = db.QueryFirstOrDefault<Leapee>(@"
                    Insert into Leapee (firstName,lastName,event) 
                    Output inserted.*
                    Values(@firstName,@lastName,@event)",
                    new { firstName, lastName, Event });

                if (newLeapee != null)
                {
                    return newLeapee;
                }
            }

            throw new Exception("No leapee created");
        }
    }
}
