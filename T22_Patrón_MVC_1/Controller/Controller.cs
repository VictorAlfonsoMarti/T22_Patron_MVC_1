using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T22_Patrón_MVC_1
{
    class Controller
    {
        public void Cliente_Controller(Cliente cliente)
        {
            //ATRIBUTOS
            DataTable datos = null;


            //EVENTOS
            cliente.boton_verTabla.Click += (sender, EventArgs) => {verTabla_Click(sender, EventArgs, cliente.textBoxBD.Text, cliente.textBoxTabla.Text, cliente);};
            cliente.boton_verRegistros.Click += (sender, EventArgs) => {verRegistros_Click(sender, EventArgs, cliente.textBoxBD.Text, cliente.textBoxTabla.Text, cliente); };
            cliente.boton_actualizar.Click += (sender, EventArgs) => { insertar_Click(sender, EventArgs, cliente.textBoxBD.Text, cliente.textBoxTabla.Text, cliente); };
            cliente.boton_eliminar.Click += (sender, EventArgs) => { eliminar_Click(sender, EventArgs, cliente.textBoxBD.Text, cliente.textBoxTabla.Text, cliente); };
            cliente.boton_editar.Click += (sender, EventArgs) => { editarRegistro_Click(sender, EventArgs, cliente.textBoxBD.Text, cliente.textBoxTabla.Text, cliente); };


            Application.Run(cliente);
        }


        public void verTabla_Click(object sender, EventArgs e, string DB, string tabla, Cliente cliente)
        {
            // botón para ver toda la tabla
            
            // ATRIBUTOS
            Model conexion = new Model(); // conexion al modelo
            DataTable datos = conexion.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
            cliente.tabla_clientes.DataSource = datos;
        }

        private void verRegistros_Click(object sender, EventArgs e, string DB, string tabla, Cliente cliente)
        {
            // botón para ver registros especificos

            // ATRIBUTOS
            Registro registro = new Registro();

            // asignamos la vista de mostrar y ejecutamos la ventana 
            registro.panel_mostrar.Visible = true;
            // asignamos evento al boton enviar
            registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "ver", DB, tabla, cliente); };
            registro.Show();

            // actualizamos la tabla
            verTabla_Click(sender, e, DB, tabla, cliente);
        }

        private void editarRegistro_Click(object sender, EventArgs e, string DB, string tabla, Cliente cliente)
        {
            // botón para actualizar registros

            // ATRIBUTOS
            Registro registro = new Registro();

            // asignamos la vista de mostrar y ejecutamos la ventana 
            registro.panelEditarID.Visible = true;
            // asignamos evento al boton enviar
            registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "editar", DB, tabla, cliente); };
            registro.Show();

            // actualizamos la tabla
            verTabla_Click(sender, e, DB, tabla, cliente);
        }

        private void insertar_Click(object sender, EventArgs e, string DB, string tabla, Cliente cliente)
        {
            // botón para actualizar registros

            // ATRIBUTOS
            Registro registro = new Registro();

            // asignamos la vista de mostrar y ejecutamos la ventana 
            registro.panel_anadir.Visible = true;
            // asignamos evento al boton enviar
            registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "insertar", DB, tabla, cliente); };
            registro.Show();

            // actualizamos la tabla
            verTabla_Click(sender, e, DB, tabla, cliente);
        }

        private void eliminar_Click(object sender, EventArgs e, string DB, string tabla, Cliente cliente)
        {
            // botón para eliminar registros

            // ATRIBUTOS
            Registro registro = new Registro();

            // asignamos la vista de mostrar y ejecutamos la ventana 
            registro.panel_eliminar.Visible = true;
            // asignamos evento al boton enviar
            registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "eliminar", DB, tabla, cliente); };
            registro.Show();
        }

        private void enviar_Click(object sender, EventArgs e, Registro registro, string accion, string DB, string tabla, Cliente cliente)
        {
            // botón para llamar a diferentes métodos dependiendo del evento que quieran hacer

            // ATRIBUTOS
            Model model = new Model();
            DataTable datos;

            switch (accion)
            {
                case "ver":
                    datos = model.Get_Id(DB, tabla, Convert.ToInt32(registro.textBoxMostrarID.Text)); // guardamos los datos de la BD en un objeto DataTable
                    cliente.tabla_clientes.DataSource = datos; // actualizamos la tabla
                    break;
                case "insertar":
                    model.Post(DB, tabla, registro.textBoxNombre.Text, registro.textBoxApellido.Text, registro.textBoxDireccion.Text, registro.textBoxDNI.Text);
                    datos = model.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    cliente.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
                case "editar":
                    model.Put(DB, tabla, registro.textBoxEditarNombre.Text, registro.textBoxEditarApellido.Text, registro.textBoxEditarDireccion.Text, registro.textBoxEditarDNI.Text, Convert.ToInt32(registro.textBoxEditarID.Text));
                    datos = model.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    cliente.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
                case "eliminar":
                    model.Delete(DB, tabla, Convert.ToInt32(registro.textBox_EliminarID.Text));
                    datos = model.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    cliente.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
            }
        }
    }
}
