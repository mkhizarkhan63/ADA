using System;
using System.Collections.Generic;
using System.Text;

namespace ADAClassLibrary.DTOLibraries
{
    public class ClaimDTO
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int LoginId { get; set; }
        public string DynamicMenu { get; set; }
        public string Permissions { get; set; }


    }
 
}
