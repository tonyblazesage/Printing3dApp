using System;
using System.Linq;
using System.Windows.Forms;


namespace Printing3dApp
{
    public partial class Form1 : Form
    {
        //establish the instance for the connection to the database
        private readonly Waam3dPrintingEntities _db;
        public Form1()
        {
            InitializeComponent();

            //initialise an instance of the connection
            _db = new Waam3dPrintingEntities();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {

            try
            {
                string projectTitle = tbProjectTitle.Text;
                string ownerName = tbOwnerName.Text;
                var buildHeight = Convert.ToDouble(tbBuildHeight.Text);
                var dateCreated = dtpDateCreated.Value;
                var material = cbMaterial.Text;
                var process = cbProcess.Text;
                var status = cbStatus.Text;
                string comments = rtbComments.Text;
                var isValid = true;


                if (string.IsNullOrWhiteSpace(projectTitle))
                {
                    isValid = false;
                    MessageBox.Show("Poject Title is Required");
                }

                if (string.IsNullOrWhiteSpace(ownerName))
                {
                    isValid = false;
                    MessageBox.Show("Owner name is Required");
                }
                if (material == null)
                {
                    isValid = false;
                    MessageBox.Show("Please select a Material value!");
                }

                if (process == null)
                {
                    isValid = false;
                    MessageBox.Show("Please select a Process value!");
                }
                if (buildHeight == double.NaN || buildHeight <= 0.00)
                {
                    isValid = false;
                    MessageBox.Show("This field is required and must be greated than 0.00");

                }
                if (string.IsNullOrWhiteSpace(comments))
                {
                    isValid = false;
                    MessageBox.Show("This field is required");
                }
                if (comments.Length > 100)
                {
                    isValid = false;
                    MessageBox.Show("Must be 100 characters or less");
                }


                if (isValid)
                {
                    MessageBox.Show($"Project: {projectTitle}\n\r" +
                    $"created by {ownerName}" +
                    $"is successful on {dateCreated}");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //throw;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //select * from MaterialTypes
            var materials = _db.MaterialTypes.ToList();
            cbMaterial.DisplayMember = "Type";
            cbMaterial.ValueMember = "id";
            cbMaterial.DataSource = materials;

            //select * from StatusStates
            var states = _db.StatusStates.ToList();
            cbStatus.DisplayMember = "State";
            cbStatus.ValueMember = "id";
            cbStatus.DataSource = states;

            //select * from ProcessTypes
            var processes = _db.ProcessTypes.ToList();
            cbProcess.DisplayMember = "Type";
            cbProcess.ValueMember = "id";
            cbProcess.DataSource = processes;
        }
    }
}
