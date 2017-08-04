namespace Hotel.App.Model.SYS
{
	public class sys_role_user : IEntityBase
    {   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		        public int Id { get; set; }     
		/// <summary>
		/// role_id
        /// </summary>		
                public int role_id{ get; set; }     
		/// <summary>
		/// user_id
        /// </summary>		
                public string user_id{ get; set; }     
		   
	}
}

