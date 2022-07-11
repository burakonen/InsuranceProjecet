using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GroupsAndCategories> GroupsAndCategories { get; set; }
        public List<GroupsAndUsers> UsersAndGroups { get; set; }


    }
}
   //< a class= "@(ViewBag.GroupId == Model.GroupsInd.Id.ToString()?"active ":"") nav-link dropdown-toggle" href = "/home/index" > Bireysel < span class= "sr-only" > (current) </ span ></ a >