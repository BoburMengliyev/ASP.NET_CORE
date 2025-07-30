using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Infrastructure.Data
{
    public class ApplicationDbContext
    {
        private readonly NpgsqlConnection npgsqlConnection;
        public ApplicationDbContext(IConfiguration configuration) 
        {
            string connectionString = 
                configuration.GetConnectionString("DefaultConnection");

            this.npgsqlConnection = new NpgsqlConnection(connectionString);
        }
        public NpgsqlConnection Connection => this.npgsqlConnection;
    }
}
