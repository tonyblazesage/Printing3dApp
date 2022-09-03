using System;
using System.Linq;
using System.Windows.Forms;

namespace Printing3dApp
{
    public partial class ViewClosedProject : Form
    {
        private readonly bool isViewMode;
        private readonly Waam3dPrintingEntities _db;
        public ViewClosedProject()
        {
            InitializeComponent();
            isViewMode = false;
            _db = new Waam3dPrintingEntities();
        }

        public ViewClosedProject(ProjectRecord records)
        {
            InitializeComponent();
            Populatefields(records);
            isViewMode = true;
            _db = new Waam3dPrintingEntities();
        }

        private void Populatefields(ProjectRecord record)
        {
            try
            {
               
                
                    lbId.Text = record.id.ToString();
                    tbProjectTitle.Text = record.ProjectTitle.ToString();
                    tbOwnerName.Text = record.OwnerName;
                    tbBuildHeight.Text = record.BuildHeight.ToString();
                    tbDateCreated.Text = record.DateCreated.ToString();
                    tbDateModified.Text = record.DateModified.ToString();
                    tbStatus.Text = record.Status.ToString();
                    tbMaterial.Text = record.Material.ToString();
                    tbProcess.Text = record.Process.ToString();
                    rtbComments.Text = record.Comments.ToString();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
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
