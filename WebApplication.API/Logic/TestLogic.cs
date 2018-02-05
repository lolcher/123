using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.API.Logic
{
    public class TestLogic : ITestLogic
    {
        private ITestDependency dependency;

        public TestLogic(ITestDependency dependency)
        {
            this.dependency = dependency;
        }

        public int GetProcessedValue(int input)
        {
            return dependency.GetValue(input);
        }
    }
}