﻿using System;
using System.Collections.Generic;
using System.Linq;
using Employee_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        Employee_DatabaseContext db;
        public EmployeeRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }

        public int addEmployee(Employee employee)
        {
            try
            {
                if (db != null)
                {
                    db.Employee.Add(employee);
                    db.SaveChanges();
                    return 0;
                }
                else
                {
                    return 1;
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("add employee" + ex);
                return 1;
            }
        }

        public int deleteEmployee(string employeeIds)
        {
            if (db != null)
            {
                try
                {
                    employeeIds = employeeIds.Substring(0, employeeIds.Length - 1);
                    int[] IDs = Array.ConvertAll(employeeIds.Split(','), int.Parse);
                    foreach (int i in IDs)
                    {
                        db.Employee.Remove(db.Employee.FirstOrDefault(e => e.Emp_ID == i));
                        db.SaveChanges();
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("delete employee : " + ex);
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        public Employee employeeDetail(int id)
        {
            if (db != null)
            {
                return  db.Employee.FirstOrDefault(e => e.Emp_ID == id);
            }
            else
            {
                return null;
            }
        }

        public List<EmployeeDetail> showEmployee()
        {
            if (db != null)
            {
                return  db.EmployeeDetail.ToList();
            }
            else
            {
                return null;
            }
        }

        public int updateEmployee(int empID, Employee employee)
        {
            if (db != null)
            {
                try
                {
                    var entity = db.Employee.FirstOrDefault(e => e.Emp_ID == empID);

                    entity.Emp_First_Name = employee.Emp_First_Name;
                    entity.Emp_Last_Name = employee.Emp_Last_Name;
                    entity.Emp_Email_ID = employee.Emp_Email_ID;
                    entity.Emp_Mobile_Number = employee.Emp_Mobile_Number;
                    entity.Emp_State_ID = Convert.ToInt32(employee.Emp_State_ID);
                    entity.Emp_City_ID = Convert.ToInt32(employee.Emp_City_ID);
                    entity.Emp_Skill_ID = Convert.ToInt32(employee.Emp_Skill_ID);
                    entity.Emp_Dob = employee.Emp_Dob;
                    entity.Emp_Doj = employee.Emp_Doj;
                    entity.Emp_Dept_ID = Convert.ToInt32(employee.Emp_Dept_ID);
                    entity.Emp_Rating = employee.Emp_Rating;

                    db.SaveChanges();
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("update employee : " + ex);
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
