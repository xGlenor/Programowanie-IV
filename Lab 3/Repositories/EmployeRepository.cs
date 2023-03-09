using Lab_3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Repositories
{
    public class EmployeRepository : IRepository<Employe>
    {
        private Database database; 

        public EmployeRepository()
        {
            this.database = Database.GetDatabase();

            if (!database.IsOpen())
            {
                throw new Exception("Nie można połączyć z bazą danych");
            }

        }

        public void Create(Employe employe)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Employe employe)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employe> GetAll()
        {
            SqlDataReader reader = database.CreateCommand("SELECT EmployeeID, FirstName, LastName, Address FROM Employees");


            List<Employe> employs = new List<Employe>();
            while (reader.Read())
            {
                var employ = new Employe()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Address = reader.GetString(3)
                };

                employs.Add(employ);
            }

            reader.Close();

            return employs;
        }

        public Employe GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
