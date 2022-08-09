using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
   public partial class frmInicio : Form
   {
      public frmInicio()
      {
         InitializeComponent();
      }

      #region Variables
      string formulario;
      #endregion

      #region Edicion
      [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
      private extern static void ReleaseCapture();
      [DllImport("user32.DLL", EntryPoint = "SendMessage")]
      private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
      #endregion

      private void PosicionBoton(Control c)
      {
         pnPosicion.Height = c.Height;
         pnPosicion.Top = c.Top;
      }

      #region Posicion Dash

      private void btnClientes_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnClientes);

         AbrirFormHijo(new frmClientes());
         //AdaptacionTamaño("Clientes");
      }

      private void btnPersonal_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnPersonal);

         AbrirFormHijo(new Formularios.frmPersonal());
      }

      private void btnServicios_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnServicios);

         AbrirFormHijo(new Formularios.frmServicios());
      }

      private void btnPromociones_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnPromociones);

         AbrirFormHijo(new Formularios.frmPromocion());
      }

      private void btnCaja_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnCaja);

         AbrirFormHijo(new Formularios.frmCaja());
      }

      private void btnRep_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnRep);

         if (pnSubRep.Visible == false)
         {
            pnSubRep.Visible = true;
         }
         else
         {
            pnSubRep.Visible = false;
         }

      }

      private void btnTurnos_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnTurnos);

         AbrirFormHijo(new Formularios.frmTurnos());
      }

      private void btnRepFinanzas_Click(object sender, EventArgs e)
      {

      }

      private void btnRepClientes_Click(object sender, EventArgs e)
      {

      }

      private void btnRepServicios_Click(object sender, EventArgs e)
      {

      }

      private void btnPerfiles_Click(object sender, EventArgs e)
      {
         PosicionBoton(btnPerfiles);

         AbrirFormHijo(new Formularios.frmCargo());
      }

      #endregion

      private void btnSlide_Click(object sender, EventArgs e)
      {
         if (pnPrincipal.Width == 220)
         {
            pnPrincipal.Size = new Size(56, 535);
            pcLogo.Location = new Point(-45, 0);
            line.Location = new Point(-1, 53);
         }
         else
         {
            pnPrincipal.Size = new Size(220, 535);
            pcLogo.Location = new Point(39, -1);
            line.Location = new Point(4, 53);
         }
      }

      private void AbrirFormHijo(object formhijo)
      {
         if (this.pnCont.Controls.Count > 0)
            this.pnCont.Controls.RemoveAt(0);

         Form fh = formhijo as Form;
         fh.TopLevel = false;
         fh.Dock = DockStyle.Fill;
         this.pnCont.Controls.Add(fh);
         fh.Show();
      }

      private void pnTitulo_MouseDown(object sender, MouseEventArgs e)
      {
         ReleaseCapture();
         SendMessage(this.Handle, 0x112, 0xf012, 0);
      }

      private void frmInicio_Load(object sender, EventArgs e)
      {
         AbrirFormHijo(new Formularios.frmTurnos());
      }

      private void AdaptacionTamaño(string form)
      {
         form = formulario;

         switch (form)
         {
            case "Clientes":
               break;
            case "Servicios":
               break;
            case "Turnos":
               break;
            case "Caja":
               break;
            case "Promociones":
               break;
            case "Reportes":
               break;
            case "Personal":
               break;
         }
      }

      private void btnCerrarSesion_Click(object sender, EventArgs e)
      {
         DialogResult result = MessageBox.Show("Seguro que desea cerrar sesión ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

         if (result == DialogResult.Yes)
         {
            Application.Exit();
         }
      }
   }
}
