using EmployeeManagementDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDAL
{
    public class DepartmentDAL
    {
        public void Display(List<DepartmentDTO> dpt)
        {
            if (dpt==null||dpt.Count==0)
            {
                Console.WriteLine("\nNo Department Found.");
            }
            else
            {
                for (int i=0;i<dpt.Count;i++)
                {
                    Console.WriteLine("\nDetails "+(i + 1)+":");
                    Console.WriteLine("\nId: "+dpt[i].Id+"\nName: "+dpt[i].Name+"\nDescription: "+dpt[i].Description);
                }
            }

        }
        //Made Update function for rewriting all the updated data after updation or deletion in the file after clearing the previous data in the file.
        public void Update(List<DepartmentDTO> list)
        {
            StreamWriter finr=new StreamWriter("Departments.txt");
            foreach (DepartmentDTO dpt in list)
            {
                finr.WriteLine(dpt.Id+","+dpt.Name+","+dpt.Description);
            }
            finr.Close();
        }
        //Search function that to find department in the file.
        public List<DepartmentDTO> FindDepartment(List<DepartmentDTO> dpt,string searchInput)
        {
            List<DepartmentDTO> d=new List<DepartmentDTO>();
            for (int i=0;i<dpt.Count;i++)
            {
                if (dpt[i].Id==searchInput||dpt[i].Name==searchInput)
                {
                    d.Add(dpt[i]);
                }
            }
            return d;
        }
        public void AddDepartment(DepartmentDTO dpt)
        {   
            StreamWriter finr=new StreamWriter("Departments.txt",true);
            finr.WriteLine(dpt.Id+","+dpt.Name+","+dpt.Description);
            finr.Close();
            Console.WriteLine("\nDepartment Added Succesfully");
        }
        public void DeleteDepartment(List<DepartmentDTO> list,int index)
        {
            list.RemoveAt(index);
            Update(list);
            Console.WriteLine("\nDepartment Deleted Succesfully");
        }
        public void UpdateDepartmentName(List<DepartmentDTO> list,int index,string name)
        {
            list[index].Name=name;
            Update(list);
            Console.WriteLine("\nDepartment's name Updated Succesfully");
        }
        public void UpdateDepartmentDescription(List<DepartmentDTO> list,int index,string description)
        {
            list[index].Description=description;
            Update(list);
            Console.WriteLine("\nDepartment's description Updated Succesfully");
        }
        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO> list=new List<DepartmentDTO>();
            FileStream fout=new FileStream("Departments.txt", FileMode.Open);
            StreamReader foutR=new StreamReader(fout);
            string data;

            while ((data=foutR.ReadLine())!=null)
            {
                string[] itemData=data.Split(',');

                if (itemData.Length<3) continue;

                DepartmentDTO d=new DepartmentDTO();
                d.Id=itemData[0].Trim();
                d.Name=itemData[1].Trim();
                d.Description=itemData[2].Trim();

                list.Add(d);
            }
            foutR.Close();
            fout.Close();
            return list;
        }
    }
}
