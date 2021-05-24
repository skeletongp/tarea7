using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Practica_7
{
    public partial class AirManager : Form
    {
        Vuelos vuelo = new Vuelos();
        public AirManager()
        {
            InitializeComponent();
            LlenarPendientes();
            LlenarListos();
        }
        private void LlenarPendientes()
        {
            dgvPendientes.Rows.Clear();
            foreach (DataRow fila in vuelo.Data_Vuelo("Pendiente").Rows)
            {
                dgvPendientes.Rows.Add(fila[0], "#" + fila[1], 
                    fila[2] + " Pasajeros", fila[3]);
            }
        }
        private void LlenarListos()
        {
            dgvListos.Rows.Clear();
            foreach (DataRow fila in vuelo.Data_Vuelo("Listo").Rows)
            {
                dgvListos.Rows.Add(fila[0], "#" + fila[1], 
                    fila[2]+" Pasajeros", fila[4].ToString()
                    .Substring(0,8));
            }
        }

        private void dgvPendientes_CellContentClick(object sender, 
            DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int id = int.Parse(dgvPendientes.CurrentRow.Cells[0].
                    Value.ToString());
                vuelo.Marcar_Vuelo(id);
                LlenarPendientes();
                LlenarListos();
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void Registrar()
        {
            if(!string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty
                (txtCantidad.Text)){
                int numero = int.Parse(txtNumero.Text);
                int cantidad = int.Parse(txtCantidad.Text);
                vuelo.Insertar_Vuelo(numero, cantidad);
            }
        }
        private void Limpiar()
        {
            foreach(var ctrl in this.Controls)
            {
                if(ctrl is Guna2TextBox)
                {
                    Guna2TextBox txt = (Guna2TextBox)ctrl;
                    txt.Clear();
                }
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
            LlenarListos();
            LlenarPendientes();
            Limpiar();
        }
    }
}
