using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlLapin
{
  
    public partial class UserControlLapin: UserControl
    {
        private Timer beat;
        private Random alea;
        public UserControlLapin()
        {
            InitializeComponent();

            alea = new Random(DateTime.Now.Millisecond);
            beat = new Timer();
            beat.Interval = 100;
            beat.Tick += beat_Tick;

            beat.Enabled = true;
            beat.Start();
        }

        void beat_Tick(object sender, EventArgs e)
        {
            Move();
            FindCarotte();
        }

        private UserControl lionn;
        private List<UserControlCarotte.UserControlCarotte> carotttte;


        private void UserControl1_Load(object sender, EventArgs e)
        {
            
        }

        public void MoveOverLion(UserControl lion)
        {
            this.lionn = lion;
        }

        public void FINDcaroote(List<UserControlCarotte.UserControlCarotte> carot)
        {
            this.carotttte = carot;
        }

        private new void Move()
        {
            double deltaX = Math.Abs(lionn.Location.X - this.Location.X);
            double deltaY = Math.Abs(lionn.Location.Y - this.Location.Y);

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if(distance < 60 )
            {
                this.Location = new Point(Convert.ToInt16(this.Location.X +5 *((-deltaX/distance))),Convert.ToInt16(this.Location.Y + 5 *((-deltaY/distance))));
            }

    
        }

        private void FindCarotte()
        {
            double tmp = 999;
            foreach (UserControlCarotte.UserControlCarotte carotte in carotttte)
            {
                double distanceX = Math.Abs(this.Location.X - carotte.Location.X);
                double distanceY = Math.Abs(this.Location.Y - carotte.Location.Y);

                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                if (distance < tmp)
                {
                     
                    tmp = distance;
                }

               // carotte.Dispose();

            }

        }
        
    }
}
