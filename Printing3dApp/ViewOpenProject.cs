using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            try
            {
                lbID.Text = recordEdit.id.ToString();
                tbProjectTitle.Text = recordEdit.ProjectTitle;
                tbOwnerName.Text = recordEdit.OwnerName;
                tbDateCreated.Text = recordEdit.DateCreated.ToString();
                tbBuildHeight.Text = recordEdit.BuildHeight.ToString();
                rtbComments.Text = recordEdit.Comments.ToString();
                cbStatus.Text = recordEdit.Status.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);    
            }

            
        }



        private void ViewOpenProject_Load(object sender, EventArgs e)
        {
            //select * from MaterialTypes


            //select * from StatusStates
            var states = _db.StatusStates.ToList();
            cbStatus.DisplayMember = "State";
            cbStatus.ValueMember = "id";
            cbStatus.DataSource = states;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                double BuildHeight = Convert.ToDouble(tbBuildHeight.Text);
                var status = cbStatus.Text;
                
                if (isEditMode)
                {
                    //edit implementation
                    var id = int.Parse(lbID.Text);
                    var record = _db.ProjectRecords.FirstOrDefault(r => r.id == id);
                    record.Comments = rtbComments.Text;
                    record.ProjectTitle = tbProjectTitle.Text;
                    record.DateModified = dtpDateModified.Value;
                    record.OwnerName = tbOwnerName.Text;
                    record.BuildHeight = BuildHeight;
                    record.Material = cbMaterial.Text;
                    record.Process = cbMaterial.Text;
                    record.Status = (int)cbStatus.SelectedValue;


                    _db.SaveChangesAsync();
                    MessageBox.Show("Changes saved successfully");
                    Close();

                }

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
    }
}
