namespace Hotel.App.Model.SYS
{
	public class sys_role_function : IEntityBase
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
		/// function_id
        /// </summary>		
                public int function_id{ get; set; }     
		   
	}
}

