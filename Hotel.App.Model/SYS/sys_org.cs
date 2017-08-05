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
		/// dept_name
        /// </summary>		
                public string DeptName{ get; set; }     
		/// <summary>
		/// parent_org_id
        /// </summary>		
                public int ParentOrgId { get; set; }     
		/// <summary>
		/// createdAt
        /// </summary>		
                public DateTime CreatedAt { get; set; }     
		/// <summary>
		/// updatedAt
        /// </summary>		
                public DateTime UpdatedAt{ get; set; }     
		   
	}
}

