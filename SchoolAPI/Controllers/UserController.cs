﻿using Microsoft.AspNetCore.Mvc;
using SchoolBL;
using SchoolDAL.Model;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBL.IBL ibl;

        public UserController(IBL.IBL _iBl)
        {
            ibl = _iBl;
        }
        
        
        // POST api/<UserAPI>
        [HttpPost]
        public bool Post([FromBody] User value)
        {
            ibl.AddNew(User);

            return true;
        }
        
        
        
        [HttpPost("PostWithPassword{value}")]
        public bool PostWithPassword([FromBody] User value)
        {
            ibl.AddNew(User);
            return true;
        }
        //// GET: api/<UserAPI>
        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    return new UserBL().GetAll();
        //}

        //// GET api/<UserAPI>/5
        //[HttpGet("{id}")]
        //public User Get(int id)
        //{
        //    return new UserBL().Get(id);
        //}

        //// POST api/<UserAPI>
        //[HttpPost]
        //public bool Post([FromBody] User value)
        //{
        //    return new UserBL().Add(value);
        //}

        //// PUT api/<UserAPI>/5
        //[HttpPut("{id}")]
        //public bool Put([FromBody] User value)
        //{
        //    return new UserBL().Update(value);
        //}

        //// DELETE api/<UserAPI>/5
        //[HttpDelete("{id}")]
        //public bool Delete(int id)
        //{
        //    return new UserBL().Delete(id);
        //}
    }
}
