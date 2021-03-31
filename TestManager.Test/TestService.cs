using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestManagerV2.Data;


namespace TestManager.Test
{
    class TestService
    {
        private TestManagerV2Context _context;


        public TestService(TestManagerV2.Data.TestManagerV2Context context)
        {
            _context = context;
        }

        public TestService()
        {
            
        }

        public EntityEntry<TestManagerV2.Models.Test> AddTest(string testName, string testDescription, string circuitName, int circuitId,
            string environment, bool published)
        {
            var test = _context.Test.Add(new TestManagerV2.Models.Test
            {
                TestName = testName, TestDescription = testDescription, CircuitName = circuitName,
                Environment = environment, CircuitId = circuitId, Published= published
            });
            _context.SaveChanges();

            return test;
        }

        public List<TestManagerV2.Models.Test> GetAllTests()
        {
            var query = from b in _context.Test
                select b;

            return query.ToList();
        }

    }
}