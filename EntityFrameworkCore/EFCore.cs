using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBaseMapping
{
    public class EFCore
    {
        /*
        public static void Main(string[] args)
        {
            using var context = new AppDbContext();
            var accounts = context.Accounts.ToList();
            foreach (var account in accounts)
            {
                Console.WriteLine($"Id: {account.Id}, Name: {account.Name}, Balance: {account.Balance}");
                Console.WriteLine("---------------------------------------");
            }

        }  */

        public static void Main(string[] args)
        {
            using var context = new AppDbContext();
            CreateAccount(context, "John Doe", 10000);
            ReadAccounts(context);
            UpdateAccount(context, 1, "Jane Doe", 20075);
            DeleteAccount(context, 1);
        }


        /// <summary>
        /// Creates a new account in the database.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>

        public static void CreateAccount(AppDbContext context, string name, int balance)
        {
            var account = new Account { Name = name, Balance = balance };
            context.Accounts.Add(account);
            context.SaveChanges();
            Console.WriteLine("Account created successfully.");
        }


        /// <summary>
        /// Reads all accounts from the database and prints them to the console.
        /// </summary>
        /// <param name="context"></param>
        public static void ReadAccounts(AppDbContext context)
        {
            var accounts = context.Accounts.ToList();
            foreach (var account in accounts)
            {
                Console.WriteLine($"Id: {account.Id}, Name: {account.Name}, Balance: {account.Balance}");
                
            }
        }

        /// <summary>
        /// Updates an existing account in the database by its ID.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>

        public static void UpdateAccount(AppDbContext context, int id, string name, int balance)
        {
            var account = context.Accounts.Find(id);
            if (account != null)
            {
                account.Name = name;
                account.Balance = balance;
                context.SaveChanges();
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
        /// <param name="context"></param>
        /// <param name="id"></param>
        public static void DeleteAccount(AppDbContext context, int id)
        {
            var account = context.Accounts.Find(id);
            if (account != null)
            {
                context.Accounts.Remove(account);
                context.SaveChanges();
                Console.WriteLine("Account deleted successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

    }


    public class AppDbContext: DbContext
    {
        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=epam;Database=my_db";

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
    


   
}
