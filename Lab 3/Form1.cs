using Lab_3.Models;
using Lab_3.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        private Database database;
        private IRepository<Employe> employeRepository;
        private IRepository<Category> categoryRepository;

        public Form1()
        {
            

            this.database = new Database("LAPTOP-E01VS139", "Northwind");

            try
            {
                database.Open();
            } catch(SqlException e)
            {
                MessageBox.Show(e.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitializeComponent();
        }

        private void btnEmploye_Click(object sender, EventArgs e)
        {
            this.employeRepository = new EmployeRepository();
            dgvList.DataSource = employeRepository.GetAll();
            

            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvList.Columns[dgvList.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.categoryRepository = new CategoryRepository();
            dgvList.DataSource = categoryRepository.GetAll();

            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvList.Columns[dgvList.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

    }
}
