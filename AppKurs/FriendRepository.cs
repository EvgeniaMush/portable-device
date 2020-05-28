using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace AppKurs
{
   public class FriendRepository
    {
        SQLiteAsyncConnection database;
        public FriendRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Friend>();
        }
        public async Task<List<Friend>> GetItemsAsync()
        {
            return await database.Table<Friend>().ToListAsync();

        }
        public async Task<Friend> GetItemAsync(int id)
        {
            return await database.GetAsync<Friend>(id);
        }
        public async Task<int> DeleteItemAsync(int id)
        {
            return await database.DeleteAsync<Friend>(id);
        }
        public async Task<int> SaveItemAsync(Friend item)
        {
         
              return await database.InsertAsync(item);
       
        }
       
    }
}

