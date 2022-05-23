using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using RPECal.Models;
using SQLite;

namespace RPECal.Data
{
    public class RPEDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RPEDatabase(string dbPath)
        {
            //get data from file db
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embeddedDatabaseStream = assembly.GetManifestResourceStream("RPECal.RPE.db");
            if (!File.Exists(dbPath))
            {
                FileStream fileStreamToWrite = File.Create(dbPath);
                embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
                embeddedDatabaseStream.CopyTo(fileStreamToWrite);
                fileStreamToWrite.Close();
            }
            //
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<RPE>().Wait();
        }

        public Task<List<RPE>> GetRPEsAsync()
        {
            //Get all notes.
            return database.Table<RPE>().ToListAsync();
        }
        public Task<RPE> GetRPEAsync(int id)
        {
            // Get a specific note.
            return database.Table<RPE>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }
        public Task<RPE> GetRPEValueAsync(double rpe, int reps)
        {
            // Get a specific note.
            return database.Table<RPE>()
                            .Where(i => i.Rpe == rpe && i.Reps == reps)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveRPEAsync(RPE rpe)
        {
            if (rpe.id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(rpe);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(rpe);
            }
        }

        public Task<int> DeleteRPEAsync(RPE rpe)
        {
            // Delete a note.
            return database.DeleteAsync(rpe);
        }
    }
}
