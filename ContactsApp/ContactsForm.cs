using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class ContactsForm : Form
    {
        public List<KeyValuePair<int, string>> Companies { get; set; }
        public List<KeyValuePair<int, string>> Employees { get; set; }

        IContactListService client;

        private int currentCompanyId;
        private int currentEmployeeId;

        public ContactsForm(ContactListController contactListController)
        {
            InitializeComponent();
            client = contactListController;
            // Populate company dropdown
            Companies = client.GetCompaniesLookup();
            Companies.ForEach(company => CompanyDropdown.Items.Add(company.Value));
            // Initialize disabled while no company has been chosen
            EmployeeDropdown.Enabled = false;
            // Disable edit options in data grid
            EmployeesList.AllowUserToAddRows = false;
            EmployeesList.ReadOnly = true;
        }

        private void CompanyDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCompanyId = Companies[CompanyDropdown.SelectedIndex].Key;
            // Enable employee dropdown if disabled
            if (!EmployeeDropdown.Enabled) EmployeeDropdown.Enabled = true;
            // Get new employees list           
            Employees = client.GetEmployeesLookup(currentCompanyId);
            EmployeeDropdown.SelectedIndex = -1; // Reset selected option
            EmployeeDropdown.Items.Clear();
            Employees.ForEach(emp => EmployeeDropdown.Items.Add(emp.Value));
            RefreshDataTable();
        }

        private void EmployeeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there's no Employee selected, SelectedIndex will be -1
            currentEmployeeId = EmployeeDropdown.SelectedIndex != -1 ? Employees[EmployeeDropdown.SelectedIndex].Key : 0;
            RefreshDataTable();
        }

        private void RefreshDataTable()
        {
            EmployeesList.DataSource = client.GetEmployeesList(currentCompanyId, currentEmployeeId);
        }
    }
}
