using System;
using System.Linq;
using System.Windows.Forms;

namespace Printing3dApp
{
    public partial class ManageProjects : Form
    {
        private readonly Waam3dPrintingEntities _db;
        public ManageProjects()
        {
            InitializeComponent();
            _db = new Waam3dPrintingEntities();
        }

        private void ManageProjects_Load(object sender, EventArgs e)
        {
            // var projects = _db.ProjectRecords.ToList();

            //using lamda expression to select the columns we need from the database
            var projects = _db.ProjectRecords.
                Select(s => new
                {
                    s.id,
                    ProjectTitle = s.ProjectTitle,
                    DateOfCreation = s.DateCreated,
                    s.Status
                })
                .ToList();
            dgvManageProjects.DataSource = projects;

            //using an index to select the subscript of the data array i want to display in the datagrid and rename the column

            dgvManageProjects.Columns[0].Visible = false;
            dgvManageProjects.Columns[1].HeaderText = "Project Title";
            dgvManageProjects.Columns[2].HeaderText = "Date of Creation";




        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            var addProject = new AddProject();
            addProject.MdiParent = this.MdiParent;
            addProject.Show();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //get id and status of the row.
            var ID = (int)dgvManageProjects.SelectedRows[0].Cells["id"].Value;
            var status = (int)dgvManageProjects.SelectedRows[0].Cells["Status"].Value;


            //then we need to query the database
            var record = _db.ProjectRecords.FirstOrDefault(r => r.Status == status && r.id == ID);



            //launch the form (closed or Active form) according to status code
            if (record.Status == 1)
            {
                var viewopenproject = new ViewOpenProject(record);
                viewopenproject.MdiParent = this.MdiParent;
                viewopenproject.Show();
            }
            //if(record.Status == 2)
            //{
            // var viewclosedproject = new ViewClosedProject(record);
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //get id and status of the row.

            var ID = (int)dgvManageProjects.SelectedRows[0].Cells["id"].Value;


            //then we need to query the database
            var record = _db.ProjectRecords.FirstOrDefault(r => r.id == ID);


            //delete record from the table
            _db.ProjectRecords.Remove(record);
            _db.SaveChanges();


            dgvManageProjects.Refresh();
        }
    }
}
