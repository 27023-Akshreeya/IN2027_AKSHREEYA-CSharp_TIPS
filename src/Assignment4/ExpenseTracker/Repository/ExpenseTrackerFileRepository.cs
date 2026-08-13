using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Provides file-based storage and retrieval for transactions using JSON serialization.
    /// </summary>
    /// <typeparam name="T">The type of the transaction.</typeparam>
    public class ExpenseTrackerFileRepository<T>
        where T : class
    {
        private readonly string _fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerFileRepository{T}"/> class and creates the file if it does not exist.
        /// </summary>
        /// <param name="filePath">The path to the file used for storing expense data.</param>
        public ExpenseTrackerFileRepository(string filePath)
        {
            this._fileName = filePath;
            if (!File.Exists(this._fileName))
            {
                File.WriteAllText(this._fileName, "[]");
            }
        }

        /// <summary>
        /// Loads all transactions from the specified file and deserializes them into a list of objects.
        /// </summary>
        /// <returns>A list containing all deserialized transactions, or an empty list if the file is empty.</returns>
        public List<T> LoadAllTransactions()
        {
            try
            {
                string readTransactions = File.ReadAllText(this._fileName);
                var serializeTransaction = JsonSerializer.Deserialize<List<T>>(readTransactions) ?? new List<T>();
                return serializeTransaction;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Saves the specified list of transactions to a file in JSON format.
        /// </summary>
        /// <param name="transactions">The transactions to serialize and save.</param>
        public void SaveAllTransactions(List<T> transactions)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string writeTransactions = JsonSerializer.Serialize(transactions, options);
            File.WriteAllText(this._fileName, writeTransactions);
        }
    }
}
