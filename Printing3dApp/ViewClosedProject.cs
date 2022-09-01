using System;
using System.Windows.Forms;

namespace Printing3dApp
{
    public partial class ViewClosedProject : Form
    {
        private bool isViewMode;
        public ViewClosedProject()
        {
            InitializeComponent();
            isViewMode = false;

        }

        public ViewClosedProject(ProjectRecord records)
        {
            InitializeComponent();
            Populatefields(records);
            isViewMode = true;

        }

        private void Populatefields(ProjectRecord record)
        {
            lbId.Text = record.id.ToString();
            tbProjectTitle.Text = record.ProjectTitle.ToString();
            tbOwnerName.Text = record.OwnerName;
            tbBuildHeight.Text = record.BuildHeight.ToString();
            tbDateCreated.Text = record.DateCreated.ToString();
            tbDateModified.Text = record.DateModified.ToString();
            tbMaterial.Text = record.Material.ToString();
            tbProcess.Text = record.Process.ToString();
            tbStatus.Text = record.Status.ToString();
            rtbComments.Text = record.Comments.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewClosedProject_Load(object sender, EventArgs e)
        {

        }
    }
}
