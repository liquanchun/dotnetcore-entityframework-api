using System;
namespace Hotel.App.Model.SYS
{
    public class sys_role : IEntityBase
    {
        /// <summary>
        /// auto_increment
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// role_name
        /// </summary>		
        public string role_name { get; set; }
        /// <summary>
        /// role_desc
        /// </summary>		
        public string role_desc { get; set; }
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

