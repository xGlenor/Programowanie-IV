using Lab_3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private Database database;

        public CategoryRepository()
        {
            this.database = Database.GetDatabase();

            if (!database.IsOpen())
            {
                throw new Exception("Nie można połączyć z bazą danych");
            }
        }

        public void Create(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            SqlDataReader reader = database.CreateCommand("SELECT CategoryID, CategoryName, Description FROM Categories");


            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                var category = new Category()
                {
                    Id = reader.GetInt32(0),
                    CategoryName = reader.GetString(1),
                    Description = reader.GetString(2)
                };

                categories.Add(category);
            }

            reader.Close();
            return categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
