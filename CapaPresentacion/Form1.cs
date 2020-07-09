using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        ClsAlumno Al = new ClsAlumno();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            String msj = "";

            try
            {
                Al.m_Dni = Convert.ToInt32(txtDni.Text);
                Al.m_Apellidos = txtApellidos.Text;
                Al.m_Nombres = txtNombres.Text;
                Al.m_Sexo = rbtMasculino.Checked == true ? 'M' : 'F';
                Al.m_FechaNac = dtpFechaNacimiento.Value;
                Al.m_Direccion = txtDireccion.Text;

                msj = Al.Registrar_Alumnos();

                MessageBox.Show(msj);

                txtDni.Clear();
                txtNombres.Clear();
                txtApellidos.Clear();
                txtDireccion.Clear();
                txtDireccion.Clear();
                //dtpFechaNacimiento.Value = "";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LinkVerListado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 fr = new Form2();
            fr.ShowDialog();
        }
    }
}
