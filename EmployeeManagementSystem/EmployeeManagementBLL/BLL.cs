using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementDTO;
using EmployeeManagementDAL;

namespace EmployeeManagementBLL
{
    public class BLL
    {
        public void AddEmployee(EmployeeDTO emp)
        {
            EmployeeDAL eD=new EmployeeDAL();
            List<EmployeeDTO> list=eD.GetAll();
            if (list.Any(e=>e.Id==emp.Id))
            {
                Console.WriteLine("\nEmployee with this Id Already Exists. Try again by Assigning a new ID.");
            }
            else
            {
                eD.AddEmployee(emp);
            }
        }
        public void AddDepartment(DepartmentDTO d)
        {
            DepartmentDAL eD=new DepartmentDAL();
            List<DepartmentDTO> list=eD.GetAll();
            if (list.Any(e=>e.Id==d.Id))
            {
                Console.WriteLine("\nDepartment with this Id Already Exists. Try again by Assigning a new ID.");
            }
            else
            {
                eD.AddDepartment(d);
            }
        }
        public void DeleteEmployee(string id)
        {
            EmployeeDAL eD=new EmployeeDAL();
            List<EmployeeDTO> list=eD.GetAll();
            int index=list.FindIndex(d=>d.Id==id);
            if (index!=-1)
            {
                eD.DeleteEmployee(list,index);
            }
            else
            {
                Console.WriteLine("\nEmployee with ID "+id+" does'nt exist.");
            }
        }
        public void DeleteDepartment(string id)
        {
            DepartmentDAL eD=new DepartmentDAL();
            List<DepartmentDTO> list=eD.GetAll();
            int index=list.FindIndex(d=>d.Id==id);
            if (index!=-1)
            {
                eD.DeleteDepartment(list,index);
            }
            else
            {
                Console.WriteLine("\nDepartment with ID "+id+" does'nt exist.");
            }
        }
        public void UpdateEmployeeDepartment(string id,string department)
        {
            EmployeeDAL eD=new EmployeeDAL();
            List<EmployeeDTO> list=eD.GetAll();
            int index=list.FindIndex(d=>d.Id==id);
            if (index!=-1)
            {
                eD.UpdateEmployeeDepartment(list,index,department);
            }
            else
            {
                Console.WriteLine("\nEmployee with ID "+id+" does'nt exist.");
            }
        }
        public void UpdateDeptName(string id,string name)
        {
            DepartmentDAL eD=new DepartmentDAL();
            List<DepartmentDTO> list=eD.GetAll();
            int index=list.FindIndex(d=>d.Id==id);
            if (index!=-1)
            {
                eD.UpdateDepartmentName(list,index,name);
            }
            else
            {
                Console.WriteLine("\nDepartment with ID "+id+" does'nt exist.");
            }
        }
        public void UpdateDeptDesc(string id,string description)
        {
            DepartmentDAL eD=new DepartmentDAL();
            List<DepartmentDTO> list=eD.GetAll();
            int index=list.FindIndex(d=>d.Id==id);
            if (index!=-1)
            {
                eD.UpdateDepartmentDescription(list,index,description);
            }
            else
            {
                Console.WriteLine("\nDepartment with ID "+id+" does'nt exist.");
            }
        }
        public void UpdateEmployeeSalary(string id,double salary)
        {
            EmployeeDAL eD=new EmployeeDAL();
            List<EmployeeDTO> list=eD.GetAll();
            int index=list.FindIndex(d=>d.Id==id);
            if (index!=-1)
            {
                eD.UpdateEmployeeSalary(list,index,salary);
            }
            else
            {
                Console.WriteLine("\nEmployee with ID "+id+" does'nt exist.");
            }
        }
        public void SearchEmployee(string input)
        {
            EmployeeDAL ed=new EmployeeDAL();
            List<EmployeeDTO> list=ed.GetAll();
            ed.Display(ed.FindEmployee(list,input));
        }
        public void SearchDepartment(string input)
        {
            DepartmentDAL d=new DepartmentDAL();
            List<DepartmentDTO> list=d.GetAll();
            d.Display(d.FindDepartment(list,input));
        }
        public void ListEmployees()
        {
            EmployeeDAL ed=new EmployeeDAL();
            ed.Display(ed.GetAll());
        }
        public void ListDepartments()
        {
            DepartmentDAL ed=new DepartmentDAL();
            ed.Display(ed.GetAll());
        }
    }
}
