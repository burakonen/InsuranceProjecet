using InsuranceProject.Context;
using InsuranceProject.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceProject.Areas.Admin.Model
{
    public class GetAllUser
    {

        ApplicationContext context = new ApplicationContext();
        public List<GroupsAndUsers> GetUsers()
        {
            //var users = context.Users.Include(a => a.InsuranceList).ThenInclude(s => s.Category).ThenInclude(i => i.GroupsAndCategories).ToList();

            var users = context.GroupsAndUsers.Include(a => a.Groups).ThenInclude(i => i.GroupsAndCategories).Include(s => s.Users).ThenInclude(o => o.InsuranceList).ToList();

            return users;
        }
    }
}
