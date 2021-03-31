using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestManagerV2.Data;
using TestManagerV2.Models;

namespace TestManagerV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly TestManagerV2Context _context;

        public TestsController(TestManagerV2Context context)
        {
            _context = context;
        }

        // GET: api/Tests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTest()
        {
            return await _context.Test.Include(s => s.Steps).ToListAsync();
        }

        // GET: api/Tests/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var listeTests = await _context.Test.Include(s => s.Steps).ToListAsync();
            var stepsArray = new List<Step>();
            foreach (var item in listeTests)
            {
                if (item.TestId == id)
                {
                    stepsArray = item.Steps;
                }
            }
            var test = await _context.Test.FindAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            test.Steps = stepsArray;

            return test;
        }

        
        // GET: api/Tests/title
        
        [HttpGet("{title}")]
        public async Task<ActionResult<IEnumerable<Test>>> GetTestByTitle(string title)
        {
            var listeTests = await _context.Test.Include(s => s.Steps).ToListAsync();
            var listeTestsResult = listeTests.FindAll( t => t.TestName.Contains(title, StringComparison.InvariantCultureIgnoreCase));

            return listeTestsResult;
        }

        // PUT: api/Tests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id, Test test)
        {
            if (id != test.TestId)
            {
                return BadRequest();
            }

            var listeTests = await _context.Test.Include(s => s.Steps).ToListAsync();
            var testToUpdate = listeTests.Find(t => t.TestId == id);

            testToUpdate.TestName = test.TestName;
            testToUpdate.TestDescription = test.TestDescription;
            testToUpdate.TestName = test.TestName;
            testToUpdate.CircuitName = test.CircuitName;
            testToUpdate.CircuitId = test.CircuitId;
            testToUpdate.Environment = test.Environment;
            testToUpdate.Steps = test.Steps;
            testToUpdate.Published = test.Published;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            _context.Test.Add(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTest", new { id = test.TestId }, test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Test>> DeleteTest(int id)
        {
            var test = await _context.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.Test.Remove(test);
            await _context.SaveChangesAsync();

            return test;
        }

        // DELETE: api/Tests/
        [HttpDelete]
        public async Task<ActionResult<Test>> DeleteAllTest()
        {
            _context.Test.RemoveRange(_context.Test);
            await _context.SaveChangesAsync();

            return null;
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.TestId == id);
        }
    }
}
