using HealthDiaryApp.Models;
using SQLite; // работа с БД SQLite
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthDiaryApp.Database
{
    public class HealthDatabase // логика работы с БД
    {

        readonly SQLiteAsyncConnection database; // подключение к БД

        public HealthDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath); // путь
            database.CreateTableAsync<HealthEntry>().Wait(); // создание таблицы
        }

        public Task<List<HealthEntry>> GetEntriesAsync() // получение данных
        {
            return database.Table<HealthEntry>().ToListAsync();
        }

        public Task<int> SaveEntryAsync(HealthEntry entry) // сохранение данных
        {
            if (entry.Id != 0)
                return database.UpdateAsync(entry);
            else
                return database.InsertAsync(entry);
        }

        public Task<int> DeleteEntryAsync(HealthEntry entry) // удаление данных
        {
            return database.DeleteAsync(entry);
        }


    }
}
