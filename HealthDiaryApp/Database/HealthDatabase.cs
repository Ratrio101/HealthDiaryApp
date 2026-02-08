using HealthDiaryApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthDiaryApp.Database
{
    public class HealthDatabase
    {

        readonly SQLiteAsyncConnection database;

        public HealthDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<HealthEntry>().Wait();
        }

        public Task<List<HealthEntry>> GetEntriesAsync()
        {
            return database.Table<HealthEntry>().ToListAsync();
        }

        public Task<int> SaveEntryAsync(HealthEntry entry)
        {
            if (entry.Id != 0)
                return database.UpdateAsync(entry);
            else
                return database.InsertAsync(entry);
        }

        public Task<int> DeleteEntryAsync(HealthEntry entry)
        {
            return database.DeleteAsync(entry);
        }


    }
}
