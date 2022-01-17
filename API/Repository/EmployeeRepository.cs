﻿using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace API.Repository
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext myContext;
        
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }


        public int Register(RegisterVM registerVM)
        {
            var checkEmail = myContext.Employees
                            .Where(e => e.Email == registerVM.Email)
                            .FirstOrDefault();
            if (checkEmail != null)
            {
                return 2; // Duplicate Email
            }

            var checkPhone = myContext.Employees
                            .Where(e => e.Phone == registerVM.Phone)
                            .FirstOrDefault();
            if (checkPhone != null)
            {
                return 3; // Duplicate Phone
            }

            int increment = myContext.Employees.ToList().Count;
            string formattedNIK = "";
            if (increment == 0)
            {
                formattedNIK = DateTime.Now.ToString("yyyy") + "0" + increment.ToString();
            }
            else
            {
                int increment2 = Int32.Parse(myContext.Employees.ToList().Max(e => e.NIK)) + 1;
                formattedNIK = increment2.ToString();
            }

            int result;
            var employee = new Employee()
            {
                NIK = formattedNIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                BirthDate = registerVM.BirthDate,
                Phone = registerVM.Phone,
                Email = registerVM.Email,
                Salary = registerVM.Salary,
                Gender = (Models.Gender)registerVM.Gender
            };
            try
            {
                myContext.Employees.Add(employee);
                result = myContext.SaveChanges();

            }
            catch (Exception)
            {
                return 4; //Employee add error
            }
            
            var account = new Account()
            {
                NIK = formattedNIK,
                Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password)
            };
            try
            {
                myContext.Accounts.Add(account);
                result = myContext.SaveChanges();
            }
            catch (Exception)
            {
                return 5; //Account add error
            }

            var education = new Education()
            {
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                UniversityId = registerVM.UniversityId
            };
            try
            {
                myContext.Educations.Add(education);
                result = myContext.SaveChanges();
            }
            catch (Exception)
            {
                return 6; //Education add error
            }

            var profiling = new Profiling()
            {
                NIK = formattedNIK,
                EducationId = education.Id
            };
            try
            {
                myContext.Profilings.Add(profiling);
                result = myContext.SaveChanges();
            }
            catch (Exception)
            {
                return 7; //Profiling add error
            }

            var accountRole = new AccountRole()
            {
                AccountId = formattedNIK,
                RoleId = 1
            };

            try
            {
                myContext.AccountRoles.Add(accountRole);
                result = myContext.SaveChanges();
            }
            catch (Exception)
            {
                return 8; //Role add error
            }
            return result;
        }

        public IEnumerable GetRegisteredData()
        {
            var query = (from employee in myContext.Set<Employee>()
                        join account in myContext.Set<Account>()
                            on employee.NIK equals account.NIK
                        join profiling in myContext.Set<Profiling>()
                            on account.NIK equals profiling.NIK
                        join education in myContext.Set<Education>()
                            on profiling.EducationId equals education.Id
                        join university in myContext.Set<University>()
                            on education.UniversityId equals university.Id
                        select new RegisteredVM{
                            NIK = employee.NIK,
                            FullName = employee.FirstName + " " + employee.LastName,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Gender = employee.Gender,
                            PhoneNumber = employee.Phone,
                            BirthDate = employee.BirthDate,
                            Salary = employee.Salary,
                            Email = employee.Email,
                            Degree = education.Degree,
                            GPA = education.GPA,
                            UniversityName = university.Name
                        });
            return query.ToList();
        }

        public IEnumerable GetRegisteredDataAlt()
        {
            var data = myContext.Employees
                .Include(employee => employee.Account)
                .ThenInclude(account => account.Profiling)
                .ThenInclude(profiling => profiling.Education)
                .ThenInclude(education => education.University)
                .ToList();
            return data;
        }

        public IEnumerable GetGenderStat()
        {
            var query = (from employee in myContext.Set<Employee>()
                         group employee by employee.Gender into g
                         select new
                         {
                             gender = g.Key,
                             count = g.Count()
                         });
            return query.ToList();
        }

        public RegisteredVM GetRegisteredDataByNIK(string nik)
        {
            var query = myContext.Employees.Where(e => e.NIK == nik)
                                            .Include(e => e.Account)
                                                .ThenInclude(a => a.Profiling)
                                                    .ThenInclude(p => p.Education)
                                                        .ThenInclude(e => e.University)
                                            .FirstOrDefault();

            if (query == null)
            {
                return null;
            }

            var selectedData = new RegisteredVM
            {
                NIK = query.NIK,
                FirstName = query.FirstName,
                LastName = query.LastName,
                FullName = query.FirstName + " " + query.LastName,
                PhoneNumber = query.Phone,
                BirthDate = query.BirthDate,
                Gender = query.Gender,
                Salary = query.Salary,
                Email = query.Email,
                Degree = query.Account.Profiling.Education.Degree,
                GPA = query.Account.Profiling.Education.GPA,
                UniversityName = query.Account.Profiling.Education.University.Name
            };

            return selectedData;
        }

        public int DeleteRegistered(string nik)
        {
            //var employee = myContext.Employees.Find(nik);
            var employee = myContext.Employees.Where(e => e.NIK == nik)
                    .Include(e => e.Account)
                        .ThenInclude(a => a.Profiling)
                    .FirstOrDefault();

            if (employee == null)
            {
                return 2; //Record not found
            }
            var educationId = employee.Account.Profiling.EducationId;
            myContext.Remove(employee);
            var education = myContext.Educations.Find(educationId);
            myContext.Remove(education);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
