using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Semana8_Grupo4
{
    public partial class Form1 : Form
    {
        public OleDbConnection miconexion;
        public string usuario_modificar;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creado la variable para la nueva conexion

            OleDbConnection conexion_access = newOleDbConnection();
            //Cadena de conexión para la base de datos
            //Se recomienda generar la cadena de conexion para evitar errores
            conexion_access.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\orell\\OneDrive\\Escritorio\\sistemas.mdb"; 
            //conexion_access.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\sistema\sistema.mdb;Persist Security Info=False;";
            //Abriendo conexion
            conexion_access.Open();
            //Consulta a tabla de usuarios en la base de datos
            //Para encontrar fila que tiene los datos del usuario y clave ingresados
            OleDbDataAdapter consulta = newOleDbDataAdapter("SELECT * FROM tusuario", conexion_access);
            //OleDbDataReader reader = command.ExecuteReader();
            DataSet resultado = new DataSet();
            consulta.Fill(resultado);
            foreach (DataRow registro in resultado.Tables[0].Rows)
            {
                if ((txtusuario.Text == registro["nombre"].ToString()) && (txtclave.Text == registro["clave"].ToString()))
                {
                    //llamando formulario principal llamado menufmenu
                    fm = new fmenu();
                    fm.Show();
                    this.Hide();
                }
            }
          
        }
                  

           
        
    }
}
           

        
    

