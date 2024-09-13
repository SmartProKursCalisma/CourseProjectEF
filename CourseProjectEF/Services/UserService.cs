using CourseProjectEF.DbCotntext;
using System.Linq;

namespace CourseProjectEF.Services
{
    public class UserService
    {
        public bool Login(string userName,string password)
        {
            using (AppDbContext context = new AppDbContext())
            {
               var user =  context.Users
                    .FirstOrDefault(x=> x.Username == userName && x.Password == password);
                if (user != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
