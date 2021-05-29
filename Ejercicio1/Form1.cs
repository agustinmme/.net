using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            reload();
            dgwEmpleados.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 addEmp = new Form2();
            addEmp.ShowDialog();
            reload();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmpleadoSql connection = new EmpleadoSql();
            if (txtBoxSearch.Text == "") reload();
            else dgwEmpleados.DataSource = connection.Search((txtBoxSearch.Text));
            
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            Empleado empAux = (Empleado)dgwEmpleados.CurrentRow.DataBoundItem;
            Form2 addEmp = new Form2(empAux);
            addEmp.Text = "Modificar Empleado";
            addEmp.ShowDialog();
            reload();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            Empleado empAux = (Empleado)dgwEmpleados.CurrentRow.DataBoundItem;
            EmpleadoSql empQuerry = new EmpleadoSql();
            empQuerry.Delete(empAux);
            reload();
        }

        private void reload()
        {
            EmpleadoSql connection = new EmpleadoSql();
            dgwEmpleados.DataSource = connection.list();
        }

 

    }
}
