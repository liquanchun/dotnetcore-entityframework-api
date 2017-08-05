using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.App.Data.Abstract;
using Hotel.App.Model.SYS;
using Hotel.App.API.ViewModels;
using AutoMapper;
using Hotel.App.API.Core;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.App.API.Controllers
{
    [Route("api/[controller]")]
    public class SysOrgController : Controller
    {
        private ISysOrgRepository _sysOrgRepository;
        public SysOrgController(ISysOrgRepository sysOrgRepository)
        {
            _sysOrgRepository = sysOrgRepository;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_sysOrgRepository.GetAll().ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]sys_org value)
        {
            var oldSysOrg = _sysOrgRepository.FindBy(f => f.DeptName == value.DeptName);
            if(oldSysOrg.Count() > 0)
            {
                return BadRequest(string.Concat(value.DeptName,"已经存在。"));
            }
            value.CreatedAt = DateTime.Now;
            value.UpdatedAt = DateTime.Now;
            _sysOrgRepository.Add(value);
            _sysOrgRepository.Commit();
            return new OkObjectResult(value);
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
    }
}
