﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetDataAnnotats.CoreTest.Model.Input;
using NetDataAnnotations;

namespace NetDataAnnotats.CoreTest.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        

        /// <summary>
        /// 测试测试方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("postuser")]
        [NetValidate(BaseModelType.Insert)]
        public bool PostUser(UserInput input)
        {
            return false;
        }
    }
}
