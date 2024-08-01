using IBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupBL iGroupBL;
        private readonly DbContext dbContext;

        public GroupController(IGroupBL _iGroupBL,DbContext _context)
        {
            iGroupBL = _iGroupBL;
            dbContext = _context;
        }



        // GET: api/<GroupController>
        [HttpGet]
        //public IEnumerable<SchoolDAL.Model.GroupPermission> Get()
        public IEnumerable<object> Get()
        {
            return iGroupBL.GetAll();
        }




        //// GET api/<GroupController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}




        //// POST api/<GroupController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<GroupController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GroupController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
