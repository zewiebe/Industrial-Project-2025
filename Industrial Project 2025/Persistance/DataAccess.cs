using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Data.SQLite;
using System.Drawing.Text;
using System.Windows.Input;
using System.Data;
using static Industrial_Project_2025.Constants;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Industrial_Project_2025
{
    public static class DataAccess
    {
        private static string dbPath = Path.Combine(AppContext.BaseDirectory, "DataFiles", "HatcheryData.db");
        private static string connectionString = $"Data Source={dbPath};Version=3;";
        public static void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
                SQLiteConnection.CreateFile(dbPath);

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    //create business table
                    string createBusinessTableQuery = @"
                        CREATE TABLE IF NOT EXISTS businesses (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL,
                            address TEXT NOT NULL, 
                            email TEXT NOT NULL, 
                            phoneNumber TEXT NOT NULL 
                        );";

                    string createContractsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS contracts (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            creationDate TEXT NOT NULL,
                            startDate TEXT NOT NULL,
                            endDate TEXT NOT NULL,
                            price REAL NOT NULL,
                            benchmark REAL NOT NULL,
                            quantity REAL,
                            received REAL, 
                            open INTEGER,
                            commodity INTEGER,
                            supplier INTEGER,
                            late INTEGER,
                            FOREIGN KEY (supplier) REFERENCES businesses(id)
                        );";
                    string createLoadsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS loads (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            quantity REAL NOT NULL,
                            date TEXT NOT NULL,
                            contract INTEGER,
                            FOREIGN KEY (contract) REFERENCES contracts(id)
                        );"
                    ;

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createBusinessTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createContractsTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createLoadsTableQuery;
                        command.ExecuteNonQuery();

                        // Seed check: count rows in 'contracts'
                        command.CommandText = "SELECT COUNT(*) FROM contracts;";
                        long contractCount = (long)command.ExecuteScalar();

                        if(contractCount == 0)
                        {
                            int supplierId;
                            // Seed businesses
                            command.CommandText = @"
                                INSERT INTO businesses (name, address, email, phoneNumber) VALUES
                                ('Bunge', ' ', 'placeholder@fake.ca', '2040000000'),
                                ('Natural Proteins Inc', ' ', 'placeholder@fake.ca', '2040000000'),
                                ('Archer Daniels Midland Co', ' ', 'placeholder@fake.ca', '2040000000'),
                                ('Green Bison Soy Processing', ' ', 'placeholder@fake.ca', '2040000000'),
                                ('Rocky Pond Commodities', ' ', 'placeholder@fake.ca', '2040000000'),
                                ('South Dakota Soybean Processors', ' ', 'placeholder@fake.ca', '2040000000');
                            ";
                            command.ExecuteNonQuery();

                            command.CommandText = "SELECT id FROM businesses WHERE name = 'Bunge';";
                            supplierId = Convert.ToInt32(command.ExecuteScalar());
                            // Seed contracts
                            command.CommandText = @"
                                INSERT INTO contracts (creationDate, startDate, endDate, price, benchmark, quantity, received, open, commodity, supplier, late)
                                VALUES 
                                ('2023-09-14', '2023-11-15', '2024-01-04', 0, 0, 0, 0, 0, 3, @supplier, 0),
                                ('2023-09-14', '2024-01-09', '2024-02-02', 0, 0, 0, 0, 0, 3, @supplier, 0),
                                ('2023-09-14', '2024-02-08', '2024-03-18', 0, 0, 0, 0, 0, 3, @supplier, 0),
                                ('2023-09-14', '2024-04-22', '2024-05-29', 239.497, 239.497, 389.00529, 0, 0, 3, @supplier, 0),
                                ('2023-09-14', '2024-02-08', '2024-03-18', 389.00529, 389.00529, 239.497, 0, 0, 3, @supplier, 0);
                            ";
                            command.Parameters.AddWithValue("@supplier", supplierId);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();

                            command.CommandText = "SELECT id FROM businesses WHERE name = 'South Dakota Soybean Processors';";
                            supplierId = Convert.ToInt32(command.ExecuteScalar());
                            // Seed contracts
                            command.CommandText = @"
                                INSERT INTO contracts (creationDate, startDate, endDate, price, benchmark, quantity, received, open, commodity, supplier, late)
                                VALUES 
                                ('2023-09-18', '2024-01-01', '2024-01-31', 615, 615, 250, 0, 0, 2, @supplier, 0),
                                ('2024-01-05', '2024-02-08', '2024-03-18', 631, 631, 100, 0, 0, 2, @supplier, 0);
                            ";
                            command.Parameters.AddWithValue("@supplier", supplierId);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();

                            MessageBox.Show("NO DATA BASE WAS FOUND, \n New Data Base Was Created");
                        }
                    }


                }
            }
        }

        internal static void AddContract(Contract newContract)
        {

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText =
                        @"INSERT INTO contracts (creationDate, startDate, endDate, price, benchmark, quantity, received, open, commodity, supplier, late)
                        VALUES (@creationDate, @startDate, @endDate, @price, @benchmark, @quantity, @received, @open, @commodity, @supplier, @late);";
                    command.Parameters.AddWithValue("@creationDate", newContract.GetCreationDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@startDate", newContract.GetStartDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@endDate", newContract.GetEndDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@price", newContract.GetPrice());
                    command.Parameters.AddWithValue("@benchmark", newContract.GetPriceBenchmark());
                    command.Parameters.AddWithValue("@quantity", newContract.GetQuantity());
                    command.Parameters.AddWithValue("@received", newContract.GetReceived());
                    command.Parameters.AddWithValue("@open", newContract.IsOpen());
                    command.Parameters.AddWithValue("@commodity", newContract.GetCommodity());
                    command.Parameters.AddWithValue("@supplier", newContract.GetSupplier().GetId());
                    command.Parameters.AddWithValue("@late", newContract.IsLate());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }

            }

        }
        internal static void AddBusiness(Business newBusiness)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"INSERT INTO businesses (name, address, email, phoneNumber) VALUES (@name, @address, @email, @phoneNumber);";
                    command.Parameters.AddWithValue("@name", newBusiness.GetName());
                    command.Parameters.AddWithValue("@address", newBusiness.GetAddress());
                    command.Parameters.AddWithValue("@email", newBusiness.GetEmail());
                    command.Parameters.AddWithValue("@phoneNumber", newBusiness.GetPhoneNumber());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        internal static void AddLoad(Load newload)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"INSERT INTO loads (quantity, date, contract) VALUES (@quantity, @date, @contract);";
                    command.Parameters.AddWithValue("@quantity", newload.GetQuantity());
                    command.Parameters.AddWithValue("@date", newload.GetDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@contract", newload.GetContract().GetContractId());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        internal static Business GetBusiness(int toGet)
        {
            Business newBiz = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = string.Format("SELECT * FROM businesses WHERE id = {0}", toGet);

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            string address = reader.GetString(reader.GetOrdinal("address"));
                            string email = reader.GetString(reader.GetOrdinal("email"));
                            string phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                            newBiz = new Business(id, name, address, email, phoneNumber);
                        }
                    }
                }
            }
            return newBiz;
        }

        //zack
        internal static Business GetBusinessByName(string name)
        {
            Business newBiz = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = string.Format("SELECT * FROM businesses WHERE name = '{0}'", name);
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string address = reader.GetString(reader.GetOrdinal("address"));
                            string email = reader.GetString(reader.GetOrdinal("email"));
                            string phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                            newBiz = new Business(id, name, address, email, phoneNumber);
                        }
                    }
                }
            }
            return newBiz;
        }

        //zack
        internal static List<string> GetBusinessNames()
        {
            List<string> businessNames = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT name FROM businesses";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            businessNames.Add(name);
                        }
                    }
                }
            }
            return businessNames;
        }

        internal static Contract GetContract(int toGet)
        {
            Contract newContract = null;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = string.Format("SELECT * FROM contracts WHERE id = {0}", toGet);

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = toGet;
                            DateTime creationDate = reader.GetDateTime(reader.GetOrdinal("creationDate"));
                            DateTime startDate = reader.GetDateTime(reader.GetOrdinal("startDate"));
                            DateTime endDate = reader.GetDateTime(reader.GetOrdinal("endDate"));
                            float price = reader.GetFloat(reader.GetOrdinal("price"));
                            float priceBenchmark = reader.GetFloat(reader.GetOrdinal("benchmark"));
                            float quantity = reader.GetFloat(reader.GetOrdinal("quantity"));
                            float received = reader.GetFloat(reader.GetOrdinal("received"));
                            bool open = reader.GetInt32(reader.GetOrdinal("open")) != 0;
                            Constants.Commodity commodity = (Constants.Commodity)reader.GetInt32(reader.GetOrdinal("commodity"));
                            Business newBiz = GetBusiness(reader.GetInt32(reader.GetOrdinal("supplier")));
                            bool late = reader.GetInt32(reader.GetOrdinal("late")) != 0; //added by zack
                            newContract = new Contract(id, creationDate, startDate, endDate, price, priceBenchmark, quantity, received, newBiz, commodity, open, late);
                        }
                    }
                }
            }
            return newContract;
        }

        internal static List<Business> GetAllBusinesses()
        {

            List<Business> businesses = new List<Business>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM businesses";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            string address = reader.GetString(reader.GetOrdinal("address"));
                            string email = reader.GetString(reader.GetOrdinal("email"));
                            string phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                            businesses.Add(new Business(id, name, address, email, phoneNumber));
                        }
                    }
                }
            }
            return businesses;
        }

        internal static List<Contract> GetAllContracts()
        {
            List<Contract> contracts = new List<Contract>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM contracts";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            DateTime creationDate = reader.GetDateTime(reader.GetOrdinal("creationDate"));
                            DateTime startDate = reader.GetDateTime(reader.GetOrdinal("startDate"));
                            DateTime endDate = reader.GetDateTime(reader.GetOrdinal("endDate"));
                            float price = reader.GetFloat(reader.GetOrdinal("price"));
                            float priceBenchmark = reader.GetFloat(reader.GetOrdinal("benchmark"));
                            float quantity = reader.GetFloat(reader.GetOrdinal("quantity"));
                            float received = reader.GetFloat(reader.GetOrdinal("received"));
                            bool open = reader.GetInt32(reader.GetOrdinal("open")) != 0;
                            Constants.Commodity commodity = (Constants.Commodity)reader.GetInt32(reader.GetOrdinal("commodity"));
                            Business newBiz = GetBusiness(reader.GetInt32(reader.GetOrdinal("supplier")));
                            bool late = reader.GetInt32(reader.GetOrdinal("late")) != 0; //added by zack
                            contracts.Add(new Contract(id, creationDate, startDate, endDate, price, priceBenchmark, quantity, received, newBiz, commodity, open, late));
                        }
                    }
                }
            }
            return contracts;
        }
        internal static List<Load> GetAllLoads()
        {
            List<Load> loads = new List<Load>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM loads";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            float quantity = reader.GetFloat(reader.GetOrdinal("quantity"));
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("date"));
                            Contract contract = GetContract(reader.GetInt32(reader.GetOrdinal("contract")));
                            loads.Add(new Load(id, quantity, date, contract));
                        }
                    }
                }
            }
            return loads;
        }

        internal static ChartData GetPriceChartData(Constants.Commodity commodity, int year)
        {
            List<DateTime> dates = new();
            List<double> contractPrices = new();
            List<double> benchmarkPrices = new();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                        SELECT endDate, price, benchmark
                        FROM contracts
                        WHERE open = 0
                          AND commodity = @commodityId
                          AND strftime('%Y', endDate) = @year;
                    ";

                    command.Parameters.AddWithValue("@commodityId", (int)commodity);
                    command.Parameters.AddWithValue("@year", year.ToString());

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dates.Add(reader.GetDateTime(0));
                            contractPrices.Add(reader.GetDouble(1));
                            benchmarkPrices.Add(reader.GetDouble(2));
                        }
                    }
                }
            }

            // Wrap the arrays into a single object array
            return new ChartData(dates.ToArray(), contractPrices.ToArray(), benchmarkPrices.ToArray());
        }

        internal static double GetMonthlyContractQuantity(Constants.Commodity commodity, int year, int month)
        {
            double totalQuantity = 0;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                        SELECT SUM(quantity)
                        FROM contracts
                        WHERE commodity = @commodity
                          AND strftime('%Y', startDate) = @year
                          AND strftime('%m', startDate) = @month;
                    ";

                    command.Parameters.AddWithValue("@commodity", (int)commodity);
                    command.Parameters.AddWithValue("@year", year.ToString());
                    command.Parameters.AddWithValue("@month", (month + 1).ToString("D2")); // Add 1 because months are 0–11 in C#, but 01–12 in SQL

                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        totalQuantity = Convert.ToDouble(result);
                    }
                }
            }

            return totalQuantity;
        }
        internal static void UpdateBusiness(Business toUpdate)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE businesses SET name = @name, address = @address, email = @email, phoneNumber = @phoneNumber WHERE id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", toUpdate.GetName());
                    command.Parameters.AddWithValue("@address", toUpdate.GetAddress());
                    command.Parameters.AddWithValue("@email", toUpdate.GetEmail());
                    command.Parameters.AddWithValue("@phoneNumber", toUpdate.GetPhoneNumber());
                    command.Parameters.AddWithValue("@id", toUpdate.GetId());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        internal static void UpdateLoads(Load toUpdate)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE loads SET quantity = @quantity, date = @date, contract = @contract WHERE id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quantity", toUpdate.GetQuantity());
                    command.Parameters.AddWithValue("@date", toUpdate.GetDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@contract", toUpdate.GetContract().GetContractId());
                    command.Parameters.AddWithValue("@id", toUpdate.GetId());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        internal static void UpdateContracts(Contract toUpdate)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE contracts SET creationDate = @creationDate, startDate = @startDate, endDate = @endDate, " +
                    "price = @price, benchmark = @benchmark, quantity = @quantity, received = @received, open = @open, commodity = @commodity, " +
                    "supplier = @supplier, late = @late WHERE id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@creationDate", toUpdate.GetCreationDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@startDate", toUpdate.GetStartDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@endDate", toUpdate.GetEndDate().ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@price", toUpdate.GetPrice());
                    command.Parameters.AddWithValue("@benchmark", toUpdate.GetPriceBenchmark());
                    command.Parameters.AddWithValue("@quantity", toUpdate.GetQuantity());
                    command.Parameters.AddWithValue("@received", toUpdate.GetReceived());
                    command.Parameters.AddWithValue("@open", toUpdate.IsOpen());
                    command.Parameters.AddWithValue("@commodity", toUpdate.GetCommodity());
                    command.Parameters.AddWithValue("@supplier", toUpdate.GetSupplier().GetId());
                    command.Parameters.AddWithValue("@late", toUpdate.IsLate());
                    command.Parameters.AddWithValue("@id", toUpdate.GetContractId());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }

        internal static void DeleteLoad(int id) {
            using (var connection = new SQLiteConnection(connectionString)) { 
                connection.Open();
                string query = "DELETE FROM loads WHERE id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        internal static void DeleteBusiness(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM businesses WHERE id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        internal static void DeleteContracts(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM contracts WHERE id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
    }
}
