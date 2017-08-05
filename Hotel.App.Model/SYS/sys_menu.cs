using System;
namespace Hotel.App.Model.SYS
{
	public class sys_menu : IEntityBase
    {   		     
		public int Id { get; set; }     
		/// <summary>
		/// menu_name
        /// </summary>		
                public string MenuName{ get; set; }     
		/// <summary>
		/// parent_menu_id
        /// </summary>		
                public int ParentMenuId{ get; set; }     
		/// <summary>
		/// menu_level
        /// </summary>		
                public int MenuLevel{ get; set; }     
		/// <summary>
		/// menu_addr
        /// </summary>		
                public string MenuAddr{ get; set; }     
		/// <summary>
		/// createdAt
        /// </summary>		
                public DateTime CreatedAt{ get; set; }     
		/// <summary>
		/// updatedAt
        /// </summary>		
        public DateTime UpdatedAt{ get; set; }     
		   
	}
}

