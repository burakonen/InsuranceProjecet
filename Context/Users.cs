using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace InsuranceProject.Context
{
    public class Users:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public int InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }
        public List<GroupsAndUsers> UsersAndGroups { get; set; }
    }
}
