using EmployeeManagementDTO;
using EmployeeManagementBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    class Program
    {
        private static void Main(string[] args)
        {
            BLL b=new BLL(); 
            Console.WriteLine("Employee Management System");
            bool var=true;
            //Main presentation Layer with loop and condition based menu.
            while (var)
            {
                Console.WriteLine("\n1.List All Employees\n2.Add Employee\n3.Update Employee\n4.Delete Employee\n5.Search Employees\n6.Manage Departments\n7.Exit");
                Console.Write("Enter Choice (1,2,3,4,5,6,7): ");
                int choice=int.Parse(Console.ReadLine());
                if (choice==1)
                {
                    b.ListEmployees();
                }
                else if (choice==2)
                {

                    EmployeeDTO employee=new EmployeeDTO();
                    Console.WriteLine("Enter Employee Details:");
                    Console.Write("ID: ");
                    employee.Id=Console.ReadLine();
                    Console.Write("Name: ");
                    employee.Name=Console.ReadLine();
                    Console.Write("Age: ");
                    employee.Age=int.Parse(Console.ReadLine());
                    Console.Write("Department: ");
                    employee.Department=Console.ReadLine();
                    Console.Write("Salary: ");
                    employee.Salary=double.Parse(Console.ReadLine());
                    Console.Write("Join Date (Format -> YYYY-MM-DD): ");
                    employee.Joindate=Console.ReadLine();
                    b.AddEmployee(employee);
                }
                else if (choice==3)
                {
                    bool var2=true;
                    while (var2)
                    {
                        Console.WriteLine("\n1.Update Salary\n2.Update Department\n3.Back");
                        Console.Write("Enter Choice (1,2,3): ");
                        int choice2=int.Parse(Console.ReadLine());
                        if (choice2==1)
                        {
                            Console.Write("Enter Employee ID For Salary Updation: ");
                            String Id=Console.ReadLine();
                            Console.Write("New Salary: ");
                            Double Salary=double.Parse(Console.ReadLine());
                            b.UpdateEmployeeSalary(Id,Salary);
                        }
                        else if (choice2==2)
                        {
                            Console.Write("Enter Employee ID For Department Updation: ");
                            String Id=Console.ReadLine();
                            Console.Write("New Department: ");
                            String Department=Console.ReadLine();
                            b.UpdateEmployeeDepartment(Id, Department);
                        }
                        else if (choice2==3)
                        {
                            var2=false;
                        }
                        else
                        {
                            Console.WriteLine("Try Again. Enter Valid Choice");
                        }
                    }
                }
                else if (choice==4)
                {
                    Console.Write("Enter Employee ID To Delete Employee: ");
                    String Id=Console.ReadLine();
                    b.DeleteEmployee(Id);
                }
                else if (choice==5)
                {
                    bool var2=true;
                    while (var2)
                    {
                        Console.WriteLine("\n1.Search By ID\n2.Search by Name\n3.Search by Department\n4.Search by Joining Date\n5.Back");
                        Console.Write("Enter Choice (1,2,3,4,5): ");
                        int choice2=int.Parse(Console.ReadLine());
                        if (choice2==1)
                        {
                            Console.WriteLine("Enter Employee ID");
                            Console.Write("Employee ID: ");
                            String Id=Console.ReadLine();
                            b.SearchEmployee(Id);
                        }
                        else if (choice2==2)
                        { 
                            Console.Write("Enter Employee Name: ");
                            String name=Console.ReadLine();
                            b.SearchEmployee(name);
                        }
                        else if (choice2==3)
                        {
                            Console.Write("Enter Employee Department: ");
                            String department=Console.ReadLine();
                            b.SearchEmployee(department);
                        }
                        else if (choice2==4)
                        {
                            Console.WriteLine("Enter Employee Joining Date");
                            Console.Write("Employee Joining Date(Format -> YYYY-MM-DD): ");
                            String jDate=Console.ReadLine();
                            b.SearchEmployee(jDate);
                        }
                        else if (choice2==5)
                        {
                            var2=false;
                        }
                        else
                        {
                            Console.WriteLine("Try Again. Enter Valid Choice");
                        }
                    }
                }
                else if (choice==6)
                {
                    bool var2=true;
                    while (var2)
                    {
                        Console.WriteLine("\nManage Departments");
                        Console.WriteLine("\n1.Add Department\n2.Edit Department\n3.Delete Department\n4.Search Department\n5.List All Departments\n6.Back");
                        Console.Write("Enter Choice (1,2,3,4,5,6): ");
                        int choice2=int.Parse(Console.ReadLine());
                        if (choice2==1)
                        {
                            DepartmentDTO d = new DepartmentDTO();
                            Console.WriteLine("Enter Department Details");
                            Console.Write("Department ID: ");
                            d.Id=Console.ReadLine();
                            Console.Write("Department Name: ");
                            d.Name=Console.ReadLine();
                            Console.Write("Department Description: ");
                            d.Description=Console.ReadLine();
                            b.AddDepartment(d);
                        }
                        else if (choice2==2)
                        {
                            bool var3=true;
                            while (var3)
                            {
                                Console.WriteLine("\nEdit Departments");
                                Console.WriteLine("\n1.Edit Name\n2.Edit Description\n3.Back");
                                Console.Write("Enter Choice (1,2,3): ");
                                int choice3=int.Parse(Console.ReadLine());
                                if (choice3==1)
                                {
                                    Console.Write("Enter Department's ID: ");
                                    string Id=Console.ReadLine();
                                    Console.Write("Enter New Name: ");
                                    string name=Console.ReadLine();
                                    b.UpdateDeptName(Id,name);
                                }
                                else if (choice3==2)
                                {
                                    Console.Write("Enter Department's ID: ");
                                    string Id=Console.ReadLine();
                                    Console.Write("Enter New Description: ");
                                    string description=Console.ReadLine();
                                    b.UpdateDeptDesc(Id,description);
                                }
                                else if (choice3==3)
                                {
                                    var3=false;
                                }
                                else
                                {
                                    Console.WriteLine("Try Again. Enter Valid Choice");
                                }
                            }

                        }
                        else if (choice2==3)
                        {
                            Console.WriteLine("Enter Department Details");
                            Console.Write("Department ID: ");
                            string Id=Console.ReadLine();
                            b.DeleteDepartment(Id);
                        }
                        else if (choice2==4)
                        {
                            Console.Write("Enter Department's ID: ");
                            string Id=Console.ReadLine();
                            b.SearchDepartment(Id);
                        }
                        else if (choice2==5)
                        {
                            b.ListDepartments();
                        }
                        else if (choice2==6)
                        {
                            var2=false;
                        }
                        else
                        {
                            Console.WriteLine("Try Again. Enter Valid Choice");
                        }
                    }
                }
                else if (choice==7)
                {
                    var=false;
                }
                else
                {
                    Console.WriteLine("Try Again. Enter Valid Choice.");
                }
            }
        }
    }
}
