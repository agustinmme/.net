using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form2 : Form
    {
        private Empleado newEmp = null;
        private bool addOrMod = false;
        public Form2()
        {
            InitializeComponent();
            addOrMod = true;
            newEmp = new Empleado();
        }
        public Form2(Empleado emp)
        {
            InitializeComponent();
            newEmp = emp;
        }


        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if ((tbName.Text == "")|| (tbAge.Text == "") || (tbDni.Text == "") || (tbSalary.Text == ""))
            {
                MessageBox.Show("Primero cargue datos en los campos  vacios.");
            }
            else {
                if (addOrMod)
                {
                    EmpleadoSql connection = new EmpleadoSql();
                    newEmp.NombreCompleto = tbName.Text;
                    newEmp.DNI = tbDni.Text;
                    newEmp.Edad = int.Parse(tbAge.Text);
                    if (cbMarry.Text == "Si")
                        newEmp.Casado = true;
                    else newEmp.Casado = false;
                    newEmp.Salario = double.Parse(tbSalary.Text);
                    connection.Add(newEmp);
                    Clear();
                } else 
                {
                    EmpleadoSql empQuerry = new EmpleadoSql();
                    newEmp.Id = newEmp.Id;
                    newEmp.NombreCompleto = tbName.Text;
                    newEmp.DNI = tbDni.Text;
                    newEmp.Edad = int.Parse(tbAge.Text);
                    if (cbMarry.Text == "Si")
                        newEmp.Casado = true;
                    else newEmp.Casado = false;
                    newEmp.Salario = double.Parse(tbSalary.Text);
                    empQuerry.Update(newEmp);
                    this.Close();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (addOrMod) cbMarry.SelectedIndex = 1;
            else {
                tbName.Text = newEmp.NombreCompleto;
                tbDni.Text = newEmp.DNI;
                tbAge.Text = newEmp.Edad.ToString();
                if (newEmp.Casado)
                    cbMarry.Text = "Si";
                else cbMarry.Text = "No";
                tbSalary.Text = newEmp.Salario.ToString();
                btnAddEmp.Text = "Aceptar";
            }
        }
        private void Clear() 
        {
            if (addOrMod)
            {
                cbMarry.SelectedIndex = 1;
                tbAge.Clear();
                tbDni.Clear();
                tbSalary.Clear();
                tbName.Clear();
            } 
            else 
            {
                this.Close();
            }
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tbDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
