using System;
using MySql.Data.MySqlClient;

namespace ConnectToMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = "ja-cdbr-azure-west-a.cloudapp.net";
            var database = "test_db_free";
            var user = "b2baa25199d131";
            var pass = "0a1078fc";

            var myConnectionString = string.Format(
                "Server={0};Database={1};Uid={2};Pwd={3}",
                server,
                database,
                user,
                pass);

            var selectCommand = "SELECT col_int, col_varchar FROM test;";
            var insertCommand = "INSERT INTO test (col_int, col_varchar) VALUES (4, '田中');";
            var updateCommand = "UPDATE test SET col_varchar = 'TANAKA' WHERE col_int = 4;";
            var deleteCommand = "DELETE FROM test WHERE col_int = 4;";

            select(myConnectionString, selectCommand);
            insert(myConnectionString, insertCommand);
            select(myConnectionString, selectCommand);
            update(myConnectionString, updateCommand);
            select(myConnectionString, selectCommand);
            delete(myConnectionString, deleteCommand);
            select(myConnectionString, selectCommand);

            Console.ReadLine();
        }

        private static void select(string connectionString, string sql)
        {
            Console.WriteLine("Execute sql : {0} ", sql);
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var command = new MySqlCommand(sql, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("| {0} | {1} |", reader[0], reader[1]);
                }
            }
        }

        private static void insert(string connectionString, string sql)
        {
            Console.WriteLine("Execute sql : {0} ", sql);
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var command = new MySqlCommand(sql, con);
                var resultCount = command.ExecuteNonQuery();
                Console.WriteLine("Insert number : {0} ", resultCount.ToString());
            }
        }

        private static void update(string connectionString, string sql)
        {
            Console.WriteLine("Execute sql : {0} ", sql);
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var command = new MySqlCommand(sql, con);
                var resultCount = command.ExecuteNonQuery();
                Console.WriteLine("Update number : {0} ", resultCount.ToString());
            }
        }

        private static void delete(string connectionString, string sql)
        {
            Console.WriteLine("Execute sql : {0} ", sql);
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var command = new MySqlCommand(sql, con);
                var resultCount = command.ExecuteNonQuery();
                Console.WriteLine("Delete number : {0} ", resultCount.ToString());
            }
        }
    }
}
