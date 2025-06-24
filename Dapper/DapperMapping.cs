using Dapper;
using System.Data;
using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataBaseMapping
{
    public class DapperMapping
    {
        /* static void Main(string[] args)
         {
             string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=epam;Database=my_db";
             using(IDbConnection db = new NpgsqlConnection(connectionString))
             {
                 db.Open();
                 var sql = "SELECT * FROM account";
                 var users = db.Query<Account>(sql).ToList();
                 foreach (var user in users)
                 {
                     Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Balance: {user.Balance}");
                 }
             }
         } */


        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=epam;Database=my_db";

        public static void Main(string[] args)
        {


            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {

                db.Open();
                CreateAccount(db, "John Doe", 1000);
                ReadAccounts(db);
                UpdateAccount(db, 1, "Jane Doe", 2000);
                DeleteAccount(db, 1);
                ReadAccounts(db);


            }

        }

        /// <summary>
        /// Creates a new account in the database.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        public static void CreateAccount(IDbConnection db, string name, int balance)
        {
            var sql = "INSERT INTO account (name, balance) VALUES (@Name, @Balance)";
            db.Execute(sql, new { Name = name, Balance = balance });
            Console.WriteLine("Account created successfully.");
        }

        /// <summary>
        /// Reads all accounts from the database and prints them to the console.
        /// </summary>
        /// <param name="db"></param>
        public static void ReadAccounts(IDbConnection db)
        {
            var sql = "SELECT * FROM account";
            var users = db.Query<Account>(sql).ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Balance: {user.Balance}");
                
            }
        }

        /// <summary>
        /// Updates an existing account in the database.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        public static void UpdateAccount(IDbConnection db, int id, string name, int balance)
        {
            var sql = "UPDATE account SET name = @Name, balance = @Balance WHERE id = @Id";
            var rowsAffected = db.Execute(sql, new { Id = id, Name = name, Balance = balance });
            if (rowsAffected > 0)
            {
                Console.WriteLine("Account updated successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        /// <summary>
        /// Deletes an account from the database by its ID.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>

        public static void DeleteAccount(IDbConnection db, int id)
        {
            var sql = "DELETE FROM account WHERE id = @Id";
            var rowsAffected = db.Execute(sql, new { Id = id });
            if (rowsAffected > 0)
            {
                Console.WriteLine("Account deleted successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }







    [Table("account")]
    public class Account
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("balance")]
        public int Balance { get; set; }
    }

}

