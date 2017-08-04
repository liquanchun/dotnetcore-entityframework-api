using System;
namespace Hotel.App.Model.SYS
{
	public class sys_org : IEntityBase
    {   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		        public int Id { get; set; }     
		/// <summary>
		/// dept_id
        /// </summary>		
                public string dept_id{ get; set; }     
		/// <summary>
		/// dept_name
        /// </summary>		
                public string dept_name{ get; set; }     
		/// <summary>
		/// parent_org_id
        /// </summary>		
                public int parent_org_id{ get; set; }     
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

