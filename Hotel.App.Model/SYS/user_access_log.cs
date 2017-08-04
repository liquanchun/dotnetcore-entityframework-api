using System;
namespace Hotel.App.Model.SYS
{
	public class user_access_log : IEntityBase
    {   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		        public int Id { get; set; }     
		/// <summary>
		/// user_id
        /// </summary>		
                public string user_id{ get; set; }     
		/// <summary>
		/// menu_id
        /// </summary>		
                public int menu_id{ get; set; }     
		/// <summary>
		/// function_id
        /// </summary>		
                public int function_id{ get; set; }     
		/// <summary>
		/// createdAt
        /// </summary>		
                public DateTime createdAt{ get; set; }     
		/// <summary>
		/// updatedAt
        /// </summary>		
                public DateTime updatedAt{ get; set; }     
		/// <summary>
		/// desc
        /// </summary>		
                public string desc{ get; set; }     
		   
	}
}

