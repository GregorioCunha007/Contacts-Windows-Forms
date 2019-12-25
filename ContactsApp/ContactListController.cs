using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class ContactListController : IContactListService
    {
        private string _connectionString;
        private string vw_CompaniesLookup = "Select * from vw_Companies";
        private string sp_EmployeesLookup = "sp_GetEmployees";
        private string sp_EmployeesInfoList = "sp_GetEmployeesInfo";
        public ContactListController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
        }

        public List<KeyValuePair<int, string>> GetCompaniesLookup ()
        {
            List<KeyValuePair<int, string>> companies = new List<KeyValuePair<int, string>>();

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(vw_CompaniesLookup, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = (int) dr["ID"];
                        string name = dr["Name"].ToString();
                        companies.Add(new KeyValuePair<int, string>(id, name));
                    }
                }
                catch (Exception e)
                {
                    // Should log exception
                    // Return empty list
                    return new List<KeyValuePair<int, string>>();
                }

                return companies;
            }
        }

        public List<KeyValuePair<int, string>> GetEmployeesLookup(int companyId)
        {
            List<KeyValuePair<int, string>> employees = new List<KeyValuePair<int, string>>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sp_EmployeesLookup, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int id = (int)dr["ID"];
                        string name = dr["Name"].ToString();
                        employees.Add(new KeyValuePair<int, string>(id, name));
                    }
                }
                catch (Exception e)
                {
                    // Should log exception
                    // Return empty list
                    return new List<KeyValuePair<int, string>>();
                }

                return employees;
            }
        }

        public DataTable GetEmployeesList(int companyId, int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    DataTable dataTable = new DataTable();
                    SqlCommand cmd = new SqlCommand(sp_EmployeesInfoList, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);                    
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception e)
                {
                    // Should log exception
                    // Return empty datatable
                    return new DataTable();
                }
            }
        }
    }

}
