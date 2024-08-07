using DTO;
using IBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupBL iGroupBL;
 
        public GroupController(IGroupBL _iGroupBL )
        {
            iGroupBL = _iGroupBL;
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


        // POST api/<GroupController>
        [HttpPost]
        public  ActionResult   Post([FromBody] GroupDTO  value)
        {
            iGroupBL.AddNew(value );

            return Ok (new { Message = "Item addede successfuly" });
        }

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
