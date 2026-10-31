using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snort
{
    public class User
    {
       public bool UserMove { get; set; } = true;

        public ColorOfCell _colorOfCell { get; } = ColorOfCell.blue;

        public void UserMoveMethod()
        {
            if (UserMove == false)
                UserMove = true;//User Move now is true, can move...
        }

        public void UserStopMethod()
        {
            if(UserMove == true)
                UserMove = false;//User Move is now false(can't move when computer)
        }

        public User(User other)
        {
            UserMove = other.UserMove;
        }

        public User()
        {

        }
    }
}
