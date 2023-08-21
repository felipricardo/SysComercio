using System.Windows.Forms;
using CamadaNegocio;

namespace CamadadeApresentacao
{
    public partial class frmCategoria : Form
    {
        private bool eNovo = false;
        private bool eEditar = false;

        public frmCategoria()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome da Categoria");

        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}