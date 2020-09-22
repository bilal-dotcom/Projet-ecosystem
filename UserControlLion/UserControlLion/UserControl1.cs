using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace UserControlLion
{
    public partial class UserControl1: UserControl
    {
        private ArrayList ListUC;

        public void MoveWithKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                this.Location = new Point(this.Location.X - 10, this.Location.Y);
            }
            else if (e.KeyCode == Keys.D)
            {
                this.Location = new Point(this.Location.X + 10, this.Location.Y);
            }
            else if (e.KeyCode == Keys.W)
            {
                this.Location = new Point(this.Location.X, this.Location.Y - 10);
            }
            else if (e.KeyCode == Keys.S)
            {
                this.Location = new Point(this.Location.X, this.Location.Y + 10);
            }


        }

        public void Eat()
        {
            //foreach(UserControl element in ListUC)
            //{
            //    if (element is )
            //    {

            //    }

            //}

        }
        public UserControl1()
        {
            InitializeComponent();
            ListUC = new ArrayList();
             
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {


        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
