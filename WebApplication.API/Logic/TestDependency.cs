using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.API.Logic
{
    public class TestDependency : ITestDependency
    {
        public int GetValue(int input)
        {
            return input * 10;
        }
    }
}