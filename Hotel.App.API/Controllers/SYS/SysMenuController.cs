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
    public class SysMenuController : Controller
    {
        private ISysMenuRepository _sysMenuRpt;
        private ISysRoleMenuRepository _sysRoleMenuRpt;
        public SysMenuController(ISysMenuRepository sysMenuRpt,ISysRoleMenuRepository sysRoleMenuRpt)
        {
            _sysMenuRpt = sysMenuRpt;
            _sysRoleMenuRpt = sysRoleMenuRpt;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_sysMenuRpt.GetAll().ToList());
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// 获取组织下面的用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/roles", Name = "GetRoleList")]
        public IActionResult GetRoleList(int id)
        {
            return new OkObjectResult(_sysRoleMenuRpt.FindBy(f => f.MenuId == id));
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]sys_menu value)
        {
            var oldSysMenu = _sysMenuRpt.FindBy(f => f.MenuName == value.MenuName);
            if(oldSysMenu.Count() > 0)
            {
                return BadRequest(string.Concat(value.MenuName, "已经存在。"));
            }
            value.CreatedAt = DateTime.Now;
            value.UpdatedAt = DateTime.Now;
            _sysMenuRpt.Add(value);
            _sysMenuRpt.Commit();
            return new OkObjectResult(value);
        }
        /// <summary>
        /// 设置用户所属组织
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost("{id}/{rid}", Name = "NewRoleMenu")]
        public IActionResult NewRoleMenu(int id,int rid)
        {
            _sysRoleMenuRpt.Add(new sys_role_menu { MenuId= id, RoleId = rid });
            _sysRoleMenuRpt.Commit();
            return new NoContentResult();
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            sys_menu _sysMenu = _sysMenuRpt.GetSingle(id);
            if (_sysMenu == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _sysRoleMenuRpt.DeleteWhere(f => f.MenuId == id);
                _sysRoleMenuRpt.Commit();
                _sysMenuRpt.Delete(_sysMenu);
                _sysMenuRpt.Commit();

                return new NoContentResult();
            }
        }
        /// <summary>
        /// 删除用户组织
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rid}",Name ="DeleteRoleMenu")]
        public IActionResult DeleteRoleMenu(int id,int rid)
        {
            _sysRoleMenuRpt.DeleteWhere(f => f.MenuId == id && f.RoleId == rid);
            _sysRoleMenuRpt.Commit();
            return new NoContentResult();
        }
    }
}
