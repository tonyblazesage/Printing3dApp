using System.Windows.Forms;

namespace Printing3dApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void addNewProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var addProject = new AddProject();
            addProject.MdiParent = this;
            addProject.Show();
        }

        private void projectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
    }
}
