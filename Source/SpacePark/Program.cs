using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using static TestConnectionJW;
using DbContext = System.Data.Entity.DbContext;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeFirstContext.AddData(1, "Ericsson");
        }
    }
   
}
