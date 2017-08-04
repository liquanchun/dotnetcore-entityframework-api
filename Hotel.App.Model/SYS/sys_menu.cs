using System;
namespace Hotel.App.Model.SYS
{
	public class sys_menu : IEntityBase
    {   		     
		public int Id { get; set; }     
		/// <summary>
		/// menu_name
        /// </summary>		
                public string menu_name{ get; set; }     
		/// <summary>
		/// parent_menu_id
        /// </summary>		
                public int parent_menu_id{ get; set; }     
		/// <summary>
		/// menu_level
        /// </summary>		
                public int menu_level{ get; set; }     
		/// <summary>
		/// menu_addr
        /// </summary>		
                public string menu_addr{ get; set; }     
		/// <summary>
		/// createdAt
        /// </summary>		
                public DateTime createdAt{ get; set; }     
		/// <summary>
		/// updatedAt
        /// </summary>		
        public DateTime updatedAt{ get; set; }     
		   
	}
}

