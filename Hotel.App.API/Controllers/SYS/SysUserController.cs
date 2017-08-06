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
    public class SysUserController : Controller
    {
        private ISysUserRepository _sysUserRpt;
        private ISysRoleUserRepository _sysRoleUserRpt;
        private ISysRoleRepository _sysRoleRpt;
        public SysUserController(ISysUserRepository sysUserRpt, ISysRoleUserRepository sysRoleUserRpt, ISysRoleRepository sysRoleRpt)
        {
            _sysUserRpt = sysUserRpt;
            _sysRoleUserRpt = sysRoleUserRpt;
            _sysRoleRpt = sysRoleRpt;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var users = _sysUserRpt.AllIncluding(a => a.RoleUserList).Where(f => f.IsValid).ToList();
            IEnumerable<SysUserViewModel> _usersVM = Mapper.Map<IEnumerable<sys_user>, IEnumerable<SysUserViewModel>>(users);
            foreach (var item in _usersVM)
            {
                //角色名称转换
                List<string> roleName = new List<string>();
                if (!string.IsNullOrEmpty(item.RoleIds))
                {
                    string[] roleid = item.RoleIds.Split(",".ToCharArray());
                    for (int i = 0; i < roleid.Length; i++)
                    {
                        var role = _sysRoleRpt.GetSingle(int.Parse(roleid[i]));
                        if (role != null)
                        {
                            roleName.Add(role.RoleName);
                        }
                    }
                }
                item.RoleNames = string.Join(",", roleName);
            }
            return new OkObjectResult(_usersVM);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values
        //[Route("login")]
        //[HttpPost( Name ="Login")]
        //public IActionResult Login([FromBody]sys_user value)
        //{
        //    var oldSysUser = _sysUserRpt.FindBy(f => f.UserId == value.UserId && f.Pwd == value.Pwd);
        //    if (oldSysUser.Count() == 0)
        //    {
        //        return BadRequest(string.Concat(value.UserId, "不存在或密码错误。"));
        //    }
        //    var user = _sysUserRpt.GetSingle(f => f.UserId == value.UserId);
        //    if(user != null)
        //    {
        //        user.LastLoginTime = DateTime.Now;
        //        _sysUserRpt.Commit();
        //    }
        //    return new OkObjectResult(user);
        //}
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]sys_user value)
        {
            var oldSysUser = _sysUserRpt.FindBy(f => f.UserId == value.UserId);
            if(oldSysUser.Count() > 0)
            {
                return BadRequest(string.Concat(value.UserId, "已经存在。"));
            }
            value.CreatedAt = DateTime.Now;
            value.UpdatedAt = DateTime.Now;
            _sysUserRpt.Add(value);
            _sysUserRpt.Commit();

            if (!string.IsNullOrEmpty(value.RoleIds) && value.RoleIds.Length > 1)
            {
                //新增用户角色关系表
                string[] roles = value.RoleIds.Split(",".ToArray());
                foreach (var item in roles)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var userrole = new sys_role_user { RoleId = int.Parse(item), UserId = value.Id };
                        _sysRoleUserRpt.Add(userrole);
                    }
                }
                _sysRoleUserRpt.Commit();
            }
            var user = Mapper.Map<sys_user, SysUserViewModel>(value);
            return new OkObjectResult(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]sys_user value)
        {
            sys_user _userDb = _sysUserRpt.GetSingle(id);
            if (_userDb == null)
            {
                return NotFound();
            }
            else
            {
                _userDb.IsValid = value.IsValid;
                _userDb.Mobile = value.Mobile;
                _userDb.Weixin = value.Weixin;
                _userDb.Email = value.Email;
                _userDb.UserId = value.UserId;
                _userDb.UserName = value.UserName;
                _userDb.UpdatedAt = DateTime.Now;
                _userDb.RoleIds = value.RoleIds;
                _sysUserRpt.Commit();

                if (value.RoleIds != _userDb.RoleIds)
                {
                    //修改了用户角色
                    _sysRoleUserRpt.DeleteWhere(f => f.UserId == id);
                    _sysRoleUserRpt.Commit();

                    //新增用户角色关系表
                    string[] roles = value.RoleIds.Split(",".ToArray());
                    foreach (var item in roles)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            var userrole = new sys_role_user { RoleId = int.Parse(item), UserId = id };
                            _sysRoleUserRpt.Add(userrole);
                        }
                    }
                    _sysRoleUserRpt.Commit();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            sys_user _sysUser = _sysUserRpt.GetSingle(id);
            if (_sysUser == null)
            {
                return new NotFoundResult();
            }
            else
            {
                //_sysUser.IsValid = false;
                _sysUserRpt.Delete(_sysUser);
                _sysUserRpt.Commit();
                return new NoContentResult();
            }
        }
    }
}
