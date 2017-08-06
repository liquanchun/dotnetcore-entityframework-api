using System;
using System.Collections.Generic;

namespace Hotel.App.Model.SYS
{
    public class sys_role : IEntityBase
    {
        public sys_role()
        {
            RoleUserList = new List<sys_role_user>();
        }
        /// <summary>
        /// auto_increment
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// role_name
        /// </summary>		
        public string RoleName { get; set; }
        /// <summary>
        /// role_desc
        /// </summary>		
        public string RoleDesc { get; set; }
        /// <summary>
        /// createdAt
        /// </summary>		
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// updatedAt
        /// </summary>		
        public DateTime UpdatedAt { get; set; }

        public ICollection<sys_role_user> RoleUserList { get; set; }

    }
}

