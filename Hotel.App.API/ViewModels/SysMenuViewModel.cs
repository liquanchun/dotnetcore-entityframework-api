﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.App.API.ViewModels
{
    public class SysMenuViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// menu_name
        /// </summary>		
        public string MenuName { get; set; }
        /// <summary>
        /// parent_menu_id
        /// </summary>		
        public int ParentId { get; set; }
        /// <summary>
        /// menu_level
        /// </summary>		
        public int MenuLevel { get; set; }
        /// <summary>
        /// menu_addr
        /// </summary>		
        public string MenuAddr { get; set; }

        public string Icon { get; set; }

        public int MenuOrder { get; set; }
        /// <summary>
        /// createdAt
        /// </summary>		
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// updatedAt
        /// </summary>		
        public DateTime UpdatedAt { get; set; }

        public string RoleIds { get; set; }

        public string RoleNames { get; set; }
    }
}
