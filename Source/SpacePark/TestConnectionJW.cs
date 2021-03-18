using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using DbContext = System.Data.Entity.DbContext;

public class TestConnectionJW
{        
    
    public class Company //Model class
    {
        public int CompanyID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }
    public class CodeFirstContext : DbContext //Context class
    {
        public CodeFirstContext() : base()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CodeFirstContext>());
        }
        public System.Data.Entity.DbSet<Company> Companies
        {
            get;
            set;
        }
        public static void AddData(int ID, string name)
        {
            Company objCompany = new Company();
            objCompany.CompanyID = ID;
            objCompany.Name = name;

            CodeFirstContext objContext = new CodeFirstContext();
            objContext.Companies.Add(objCompany);
            objContext.SaveChanges();
        }
    }
}

