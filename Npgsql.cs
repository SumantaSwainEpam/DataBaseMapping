using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;

namespace DataBaseMapping
{
    public class Npgsql
    {
        /* public static void Main(string[] args)
         {
             string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=epam;Database=my_db";
             using (var connection = new NpgsqlConnection(connectionString))
             {
                 connection.Open();
                 var sql = "SELECT * FROM account";
                 using (var command = new NpgsqlCommand(sql, connection))
                 using (var reader = command.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         Console.WriteLine($"Id: {reader["id"]}, Name: {reader["name"]}, Balance: {reader["balance"]}");
                     }
                 }
             }
         }  */


        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=epam;Database=my_db";


        public static void Main(string[] args)
        {
            
            CreateAccount("John Doe", 10000);
            ReadAccounts();
            UpdateAccount(1, "Jane Doe", 20075);
            DeleteAccount(1);
        }

        //CRUD Operations


        /// <summary>
        /// Creates a new account in the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="balance"></param>

        public static void CreateAccount(string name, int balance)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO account (name, balance) VALUES (@name, @balance)";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("balance", balance);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Account created successfully.");

                }
            }
        }

        /// <summary>
        /// Fetches and displays all accounts from the database.
        /// </summary>
        public static void ReadAccounts()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM account";
                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["id"]}, Name: {reader["name"]}, Balance: {reader["balance"]}");
                    }
                }
            }
        }

        /// <summary>
        /// Updates an existing account in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>

        public static void UpdateAccount(int id, string name, decimal balance)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var sql = "UPDATE account SET name = @name, balance = @balance WHERE id = @id";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("balance", balance);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Account updated successfully.");
                }
            }
        }


        /// <summary>
        /// Deletes an account from the database.
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteAccount(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var sql = "DELETE FROM account WHERE id = @id";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Account deleted successfully.");
                }
            }
        }

        
    }

}

