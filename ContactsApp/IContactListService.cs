using System;
using System.Collections.Generic;
using System.Data;

namespace ContactsApp
{
    public interface IContactListService
    {
        List<KeyValuePair<int,string>> GetCompaniesLookup ();
        List<KeyValuePair<int, string>> GetEmployeesLookup (int companyId);
        DataTable GetEmployeesList(int companyId, int employeeId);
    }
}