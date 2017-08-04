using System;
using System.Text;
using System.Collections.Generic;
namespace Hotel.App.Model.SYS
{
    
    public class sys_function : IEntityBase
    {
        /// <summary>
        /// auto_increment
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// function_name
        /// </summary>		
        public string function_name { get; set; }
        /// <summary>
        /// function_addr
        /// </summary>		
        public string function_addr { get; set; }
        /// <summary>
        /// component
        /// </summary>		
        public string component { get; set; }
        /// <summary>
        /// menu_id
        /// </summary>		
        public int menu_id { get; set; }
        /// <summary>
        /// createdAt
        /// </summary>		
        public DateTime createdAt { get; set; }
        /// <summary>
        /// updatedAt
        /// </summary>		
        public DateTime updatedAt { get; set; }

    }
}

