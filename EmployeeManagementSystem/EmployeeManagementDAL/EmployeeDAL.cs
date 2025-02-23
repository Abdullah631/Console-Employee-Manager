using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementDTO;

namespace EmployeeManagementDAL
{
    public class EmployeeDAL
    {
        public void Display(List<EmployeeDTO> emp)
        {
            if (emp==null||emp.Count==0)
            {
                Console.WriteLine("\nNo Employee Found.");
            }
            else
            {
                for (int i=0;i<emp.Count;i++)
                {
                    Console.WriteLine("\nDetails "+(i + 1)+":");
                    Console.WriteLine("\nId: "+emp[i].Id+ "\nName: "+emp[i].Name+"\nAge: "+emp[i].Age+"\nDepartment: "+emp[i].Department+"\nSalary: Rs."+emp[i].Salary+"\nJoining Date: "+emp[i].Joindate);
                }
            }

        }
        //Made Update function for rewriting all the updated data after updation and deletion in the file after clearing the previous data in the file.
        public void Update(List<EmployeeDTO> list)
        {
            StreamWriter finr=new StreamWriter("Employees.txt");
            foreach (EmployeeDTO e in list)
            {
                finr.WriteLine(e.Id+"," +e.Name+","+e.Age+","+e.Department+","+e.Salary+","+e.Joindate);
            }
            finr.Close();
        }
        //Search function that to find employee in the file.
        public List<EmployeeDTO> FindEmployee(List<EmployeeDTO> employees,string searchInput)
        {
            List<EmployeeDTO> e = new List<EmployeeDTO>(); 
            for (int i=0;i<employees.Count;i++)
            {
                if (employees[i].Id==searchInput||employees[i].Name==searchInput||employees[i].Department==searchInput||employees[i].Joindate==searchInput)
                {
                    e.Add(employees[i]);
                }
            }
            return e;
        }
        public void AddEmployee(EmployeeDTO emp)
        { 
            StreamWriter finr = new StreamWriter("Employees.txt",true);
            finr.WriteLine(emp.Id+","+emp.Name+","+emp.Age+","+emp.Department+","+emp.Salary+","+emp.Joindate);
            finr.Close();
            Console.WriteLine("\nEmployee Added Succesfully");
        }
        public void DeleteEmployee(List<EmployeeDTO> list,int index)
        {
            list.RemoveAt(index);
            Update(list);
            Console.WriteLine("\nEmployee Deleted Succesfully");
        }
        public void UpdateEmployeeDepartment(List<EmployeeDTO> list ,int index,string department)
        {
            list[index].Department=department;
            Update(list);
            Console.WriteLine("\nEmployee's Department Updated Succesfully");
        }
        public void UpdateEmployeeSalary(List<EmployeeDTO> list,int index,double salary)
        {
            list[index].Salary=salary;
            Update(list);
            Console.WriteLine("\nEmployee's Salary Updated Succesfully");
        }
        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> list=new List<EmployeeDTO>();
            FileStream fout=new FileStream("Employees.txt",FileMode.Open);
            StreamReader foutR=new StreamReader(fout);
            string data;

            while ((data=foutR.ReadLine())!=null)
            {
                string[] itemData=data.Split(',');

                if (itemData.Length<6) continue;

                EmployeeDTO e=new EmployeeDTO();
                e.Id=itemData[0].Trim();
                e.Name=itemData[1].Trim();
                e.Age=int.Parse(itemData[2].Trim());
                e.Department=itemData[3].Trim();
                e.Salary=double.Parse(itemData[4].Trim());
                e.Joindate=itemData[5].Trim();

                list.Add(e);
            }
            foutR.Close();
            fout.Close();
            return list;
        }
    }
}
