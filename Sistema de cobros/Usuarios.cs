using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_cobros.Utilidades;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_de_cobros
{
    public partial class Usuarios: Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo(){ Valor = 0, Texto = "No Activo"});
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaConcepto = new CN_Rol().Listar();

            foreach (Rol item in listaConcepto)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.idrol, Texto = item.descripcion });
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            /*List<Rol> listaRol = new CN_Rol().Listar();
            cboRol.DataSource = listaRol;
            cboRol.DisplayMember = "descripcion";
            cboRol.ValueMember = "idrol";*/

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Visible == true && column.Name != "btnseleccionar")
                {
                    cboBuscarpor.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText }); 
                }
                cboBuscarpor.DisplayMember = "Texto";
                cboBuscarpor.ValueMember = "Valor";
                if (cboBuscarpor.Items.Count > 0)
                {
                    cboBuscarpor.SelectedIndex = 0;
                }
            }

            if (dataGridView1.Columns["Estado"] == null)
            {
                DataGridViewTextBoxColumn estadoColumn = new DataGridViewTextBoxColumn();
                estadoColumn.Name = "Estado";
                estadoColumn.HeaderText = "Estado";
                dataGridView1.Columns.Add(estadoColumn);
            }

            List<Usuario> listaUsuario = new CNUsuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dataGridView1.Rows.Add(new object[] { "", item.idUsuario, item.NroDocumento, item.NombreCompleto, item.Clave, item.oRol.idrol, item.oRol.descripcion, item.Estado == true ? "Activo" : "No Activo" });
            }
        }

        private void GuardarUsuario_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            // Creación del objeto Usuario con datos de la interfaz
            Usuario obj = new Usuario()
            {
                idUsuario = Convert.ToInt32(ID.Text),
                NombreCompleto = NombreU.Text,
                NroDocumento = NroDoc.Text,
                Clave = Contraseña1.Text,
                oRol = new Rol() { idrol = Convert.ToInt32((cboRol.SelectedItem as OpcionCombo).Valor) },
                Estado = Convert.ToInt32((cboEstado.SelectedItem as OpcionCombo).Valor) == 1
            };

            // Si idUsuario es 0, se trata de un nuevo registro
            if (obj.idUsuario == 0)
            {
                int idUsuarioGenerado = new CNUsuario().Registrar(obj, out Mensaje);

                if (idUsuarioGenerado != 0)
                {
                    // Se valida que los combobox tengan el formato correcto
                    if (cboRol.SelectedItem is OpcionCombo selectedRol && cboEstado.SelectedItem is OpcionCombo selectedEstado)
                    {
                        dataGridView1.Rows.Add(new object[] {
                    "", // Puedes quitar si no es necesario
                    idUsuarioGenerado,
                    NroDoc.Text,
                    NombreU.Text,
                    Contraseña1.Text,
                    selectedRol.Valor.ToString(),
                    selectedRol.Texto.ToString(),
                    selectedEstado.Valor.ToString(),
                    selectedEstado.Texto.ToString()
                });

                        Limpiecito();  // Método para limpiar los controles
                    }
                    else
                    {
                        MessageBox.Show("Error en la selección del rol o estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos: " + Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else  // Si idUsuario no es 0, se edita el registro existente
            {
                bool Respuesta = new CNUsuario().Editar(obj, out Mensaje);

                if (Respuesta)
                {
                    // Se asume que txtindice contiene el índice de la fila a actualizar en el DataGridView
                    int indice;
                    if (int.TryParse(txtindice.Text, out indice) && indice >= 0 && indice < dataGridView1.Rows.Count)
                    {
                        DataGridViewRow row = dataGridView1.Rows[indice];
                        row.Cells["idUsuario"].Value = ID.Text;
                        row.Cells["NroDocumento"].Value = NroDoc.Text;
                        row.Cells["NombreCompleto"].Value = NombreU.Text;
                        row.Cells["Clave"].Value = Contraseña1.Text;
                        row.Cells["idrol"].Value = (cboRol.SelectedItem as OpcionCombo).Valor;
                        row.Cells["Rol"].Value = (cboRol.SelectedItem as OpcionCombo).Texto;
                        row.Cells["EstadoValor"].Value = (cboEstado.SelectedItem as OpcionCombo).Valor;
                        row.Cells["Estado"].Value = (cboEstado.SelectedItem as OpcionCombo).Texto;

                        Limpiecito();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el índice de edición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al editar los datos: " + Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
                     
        }

        private void Limpiecito()
        {
            txtindice.Text = "-1";
            ID.Text = "0";
            NombreU.Text = "";
            NroDoc.Text = "";
            Contraseña1.Text = "";
            Contraseña2.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            NombreU.Select();
        }

        private void Limpiar_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
            txtbus.Text = "";
        }
            private void Busqueda_Click(object sender, EventArgs e)
        {
            string searchValue = txtbus.Text.ToLower();
            string searchColumn = (cboBuscarpor.SelectedItem as OpcionCombo)?.Valor.ToString();

            if (string.IsNullOrEmpty(searchValue) || string.IsNullOrEmpty(searchColumn))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y escriba un valor.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[searchColumn].Value != null &&
                    row.Cells[searchColumn].Value.ToString().ToLower().Contains(searchValue))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if(indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    ID.Text = dataGridView1.Rows[indice].Cells["idUsuario"].Value.ToString();
                    NroDoc.Text = dataGridView1.Rows[indice].Cells["NroDocumento"].Value.ToString();
                    NombreU.Text = dataGridView1.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    Contraseña1.Text = dataGridView1.Rows[indice].Cells["Clave"].Value.ToString();
                    Contraseña2.Text = dataGridView1.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach(OpcionCombo item in cboRol.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGridView1.Rows[indice].Cells["idrol"].Value))
                        {
                            int index = cboRol.Items.IndexOf(item);
                            cboRol.SelectedIndex = index;
                            break;
                        }
                    }
                    foreach(OpcionCombo item in cboEstado.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dataGridView1.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int index = cboEstado.Items.IndexOf(item);
                            cboEstado.SelectedIndex = index;
                            break;
                        }
                    }
                }
                
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
           Limpiecito();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ID.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Usuario obj = new Usuario()
                    {
                        idUsuario = Convert.ToInt32(ID.Text)
                    };

                    bool respuesta = new CNUsuario().EliminarUsuario(obj, out Mensaje);

                    if (respuesta)
                    {
                        dataGridView1.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiecito();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar los datos: " + Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}


