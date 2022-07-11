using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class GroupsAndUsers
    {
        public string UsersId { get; set; }
        public Users Users{ get; set; }
        public int GroupsId{ get; set; }
        public Groups Groups{ get; set; }
    }
}
