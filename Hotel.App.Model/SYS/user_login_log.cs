using System;
namespace Hotel.App.Model.SYS
{
	public class user_login_log : IEntityBase
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
		/// login_info
        /// </summary>		
                public string login_info{ get; set; }     
		/// <summary>
		/// login_IP
        /// </summary>		
                public string login_IP{ get; set; }     
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

