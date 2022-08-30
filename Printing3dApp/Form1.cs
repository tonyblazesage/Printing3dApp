using System;
using System.Windows.Forms;


namespace Printing3dApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {

            try
            {
                string projectTitle = tbProjectTitle.Text;
                string ownerName = tbOwnerName.Text;
                string buildHeight = tbBuildHeight.Text;
                var dateCreated = dtpDateCreated.Value;
                var material = cbMaterial.Text;
                var process = cbProcess.Text;
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
                    MessageBox.Show("Please select a Material value!");
                }


                if (isValid)
                {
                    MessageBox.Show($"Project: {projectTitle}\n\r" +
                    $"created by: {ownerName} " +
                    $" is successful on {dateCreated}");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //throw;
            }


        }
    }
}
