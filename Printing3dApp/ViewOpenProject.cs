using System.Linq;
using System.Windows.Forms;

namespace Printing3dApp
{
    public partial class ViewOpenProject : Form
    {
        private bool isEditMode;
        private readonly Waam3dPrintingEntities _db;
        public ViewOpenProject()
        {
            InitializeComponent();
            isEditMode = false;
            _db = new Waam3dPrintingEntities();
        }

        public ViewOpenProject(ProjectRecord recordEdit)
        {
            isEditMode = true;
            InitializeComponent();
            Populate(recordEdit);
            _db = new Waam3dPrintingEntities();

        }

        private void Populate(ProjectRecord recordEdit)
        {
            lbID.Text = recordEdit.id.ToString();
            tbProjectTitle.Text = recordEdit.ProjectTitle;
            tbOwnerName.Text = recordEdit.OwnerName;
            tbDateCreated.Text = recordEdit.DateCreated.ToString();
            tbBuildHeight.Text = recordEdit.BuildHeight.ToString();
            rtbComments.Text = recordEdit.Comments.ToString();
            cbMaterial.Text = recordEdit.Material.ToString();
            cbProcess.Text = recordEdit.Process.ToString();
            cbStatus.Text = recordEdit.Status.ToString();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (isEditMode)
            {
                //edit implementation
                var id = int.Parse(lbID.Text);


                var record = _db.ProjectRecords.FirstOrDefault(r => r.id == id);
                record.Comments = rtbComments.Text;
                record.ProjectTitle = tbProjectTitle.Text;
                record.DateModified = dtpDateModified.Value;
                record.OwnerName = tbOwnerName.Text;
                record.BuildHeight = (decimal?)double.Parse(tbBuildHeight.Text);


                _db.SaveChanges();

            }

        }
    }
}
