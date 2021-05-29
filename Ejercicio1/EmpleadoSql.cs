using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace Ejercicio1
{
    class EmpleadoSql
    {
        public void Delete(Empleado emp)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = "data source=DESKTOP-QL7GP7B; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "  DELETE FROM Empleados WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Connection = connection;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se a eliminado correctamente el empleado:"+emp.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString()) ;
            }
            finally 
            {
                connection.Close();
            }
            
            

        }
        public List<Empleado> Search(string name)
        {


            List<Empleado> list = new List<Empleado>();
            SqlConnection coonection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;


            coonection.ConnectionString = "data source=DESKTOP-QL7GP7B; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "  SELECT * FROM Empleados WHERE lower(NombreCompleto) LIKE @Id";
            cmd.Parameters.AddWithValue("@Id","%" +name + "%");
                                                  
            
            cmd.Connection = coonection;

            try
            {

                coonection.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Id = reader.GetInt32(0);
                    aux.NombreCompleto = reader.GetString(1);
                    aux.DNI = reader.GetString(2);
                    aux.Edad = reader.GetInt32(3);
                    aux.Casado = reader.GetBoolean(4);
                    aux.Salario = Convert.ToDouble(reader.GetDecimal(5));

                    list.Add(aux);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.ToString());

            }
            finally
            {

                coonection.Close();

            }

            return list;

        }
        public void Add(Empleado emp)
        {


            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();


            connection.ConnectionString = "data source=DESKTOP-QL7GP7B; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "  INSERT INTO Empleados ([NombreCompleto] ,[DNI],[Edad],[Casado],[Salario])VALUES(@name,@dni,@age,@marry,@salary)";
            cmd.Parameters.AddWithValue("@name", emp.NombreCompleto);
            cmd.Parameters.AddWithValue("@dni", emp.DNI);
            cmd.Parameters.AddWithValue("@age", emp.Edad);
            cmd.Parameters.AddWithValue("@marry", emp.Casado);
            cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(emp.Salario));

            cmd.Connection = connection;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se agrego correcamente el Empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally {
                connection.Close();
            }
        }
        public void Update(Empleado emp)
        {


            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();


            connection.ConnectionString = "data source=DESKTOP-QL7GP7B; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = " UPDATE Empleados SET NombreCompleto =@name,DNI=@dni,Edad=@age,Casado=@marry,Salario=@salary WHERE Id =@Id ;";
            cmd.Parameters.AddWithValue("@name", emp.NombreCompleto);
            cmd.Parameters.AddWithValue("@dni", emp.DNI);
            cmd.Parameters.AddWithValue("@age", emp.Edad);
            cmd.Parameters.AddWithValue("@marry", emp.Casado);
            cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(emp.Salario));
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Connection = connection;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se a modificado correctamente el empleado:" + emp.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Empleado> list()
        {
            List<Empleado> list = new List<Empleado>();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            connection.ConnectionString = "data source=DESKTOP-QL7GP7B; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Empleados";
            cmd.Connection = connection;

            try
            {

                connection.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Id = reader.GetInt32(0);
                    aux.NombreCompleto = reader.GetString(1);
                    aux.DNI = reader.GetString(2);
                    aux.Edad = reader.GetInt32(3);
                    aux.Casado = reader.GetBoolean(4);
                    aux.Salario = Convert.ToDouble(reader.GetDecimal(5));

                    list.Add(aux);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.ToString());

            }
            finally
            {

                connection.Close();

            }


            return list;
        }

    }
    
}

