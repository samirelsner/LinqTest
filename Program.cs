using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string myuserName = "AGL2002";
            short myuserType = 4;

            List<User> users = new List<User>()
            {
                new User(){UserId=1,UserName="IndiaTeamAdmin",UserTypeID=4},
                new User(){UserId=2,UserName="AusTeamAdmin",UserTypeID=4},
                new User(){UserId=3,UserName="WITeamAdmin",UserTypeID=4},
                new User(){UserId=4,UserName="IndiaOrgAdmin",UserTypeID=5},
                new User(){UserId=5,UserName="AusOrgAdmin",UserTypeID=5},
                new User(){UserId=6,UserName="WIOrgAdmin",UserTypeID=5},
                new User(){UserId=7,UserName="IndiaTeamBAdmin",UserTypeID=4},
            };

            List<TeamAdmin> teamAdmins = new List<TeamAdmin>()
            {
                new TeamAdmin(){TeamAdminId=1,UserId=1,TeamId=1},
                new TeamAdmin(){TeamAdminId=2,UserId=2,TeamId=2},
                new TeamAdmin(){TeamAdminId=3,UserId=7,TeamId=4},
            };

            List<Team> teams = new List<Team>()
            {
                new Team(){TeamId=1,TeamName="India",DiscountCode="AGL2001"},
                new Team(){TeamId=2,TeamName="Aus",DiscountCode="AGL2002"},
                new Team(){TeamId=3,TeamName="WI",DiscountCode="AGL2001"},
                new Team(){TeamId=4,TeamName="IndiaB",DiscountCode="AGL2001"}
            };

            List<Organization> organizations = new List<Organization>()
            {
                new Organization(){OrgId=1,OrgName="IndiaOrg",DiscountCode="AGL2001"},
                new Organization(){OrgId=2,OrgName="AusOrg",DiscountCode="AGL2002"}       
                
            };


            //var filterUsers = users.Where(x => x.UserTypeID == myuserType && teamAdmins.Any(y => y.UserId == x.UserId && teams.Any(z => z.TeamId == y.TeamId && z.DiscountCode == myuserName)));

            //filterUsers.ToList().ForEach(x => Console.WriteLine(x.UserId + "" + x.UserName + "" + x.UserTypeID));


            var query = from t in teams
                        join ta in teamAdmins on t.TeamId equals ta.TeamId into result
                        from output in result.DefaultIfEmpty()
                        select new { t.TeamId, myuserid= (output.UserId==null)?0:output.UserId,t.TeamName };


            query.ToList().ForEach(x => Console.WriteLine(x.TeamId + " " + x.TeamName + " " + x.myuserid));


            Console.ReadKey();
        }
    }


    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string DiscountCode { get; set; }

    }

    public class Organization
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string DiscountCode { get; set; }
    }

    public class TeamAdmin
    {
        public int TeamAdminId { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte UserTypeID { get; set; }
    }
}
