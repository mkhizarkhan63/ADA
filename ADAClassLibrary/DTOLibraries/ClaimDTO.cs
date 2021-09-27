using System;
using System.Collections.Generic;
using System.Text;

namespace ADAClassLibrary.DTOLibraries
{

    public class ClaimDTO
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public bool SuperAdminRights { get; set; }
        public bool StaffActive { get; set; }
        public bool StaffRights { get; set; }

    }

}


