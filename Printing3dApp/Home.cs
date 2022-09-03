using System.Windows.Forms;

namespace Printing3dApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void projectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var manageprojects = new ManageProjects();
            manageprojects.MdiParent = this;
            manageprojects.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        
    }
}
