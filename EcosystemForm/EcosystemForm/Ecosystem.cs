using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcosystemForm
{
    
    public partial class Ecosystem : Form
    {
        //Creations des List
        private List<UserControl> ListUC;

        //Listes de UserControl type Lapin et Carotte
        private List<UserControlLapin.UserControlLapin> Lapins;
        private List<UserControlCarotte.UserControlCarotte> Carot;

        //Pour creer le lion
        UserControlLion.UserControl1 lion = new UserControlLion.UserControl1();
       
        //Pour creer le lac
        UserControlLac.UserControlLac lac = new UserControlLac.UserControlLac();

        private Random alea;

        public Ecosystem()
        {
            InitializeComponent();
            alea = new Random(DateTime.Now.Millisecond);

            Lapins = new List<UserControlLapin.UserControlLapin>();
            Carot = new List<UserControlCarotte.UserControlCarotte>();

            ListUC = new List<UserControl>();

            PlaceLion();
            PlaceCarotte(8);
            PlaceLapin(4);
            PlaceLac(1);

           
            ListUC.Add(lac);
            ListUC.Add(lion);
          //  ListUC.Add();
        }

       

        //Pour placer le lion dans le formulaire
        //Pas besoin de parametre, comme il y a un seul lion
        private void PlaceLion()
        {
            //Creer un point aleatoire (x,y)
            for (int cnt = 0; cnt < 2;cnt++)
            {
                int x = alea.Next(0,400);
                int y = alea.Next(0,0);

                this.lion.Location = new Point(x, y);
               this.Controls.Add(lion);
            }

        }

        //Pour placer les lapins dans le formulaire
        private void PlaceLapin(int nb)
        {
            for (int cnt =0;cnt<nb;cnt++)
            {
                UserControlLapin.UserControlLapin lapin = new UserControlLapin.UserControlLapin();
                lapin.Location = new Point(alea.Next(0, 400), alea.Next(0, 345));

                this.Controls.Add(lapin);
                Lapins.Add(lapin);
                ListUC.Add(lapin);

                lapin.MoveOverLion(lion);
                lapin.FINDcaroote(Carot);
                
            }
        }

        //Pour placer les carottes dans le formulaire
        private void PlaceCarotte(int nb)
        {
            for (int cnt = 0; cnt < nb; cnt++)
            {
                UserControlCarotte.UserControlCarotte carotte = new UserControlCarotte.UserControlCarotte();

                carotte.Location = new Point(alea.Next(0, 400), alea.Next(0, 345));

                this.Controls.Add(carotte);
                Carot.Add(carotte);
                ListUC.Add(carotte);
            }

        }

        //Pour placer le lac dans le formulaire
        private void PlaceLac(int nb)
        {
            for (int cnt = 0; cnt < nb; cnt++)
            {

                this.lac.Location = new Point(alea.Next(0, 400), alea.Next(0, 345));
                this.Controls.Add(lac);

            }

        }


       ////Fonction de type bolean pour gerer la collision
       // private bool IsColliding(UserControl userControl)
       // {
           
       //     double distance = 0;
       //     foreach(UserControl element in ListUC)
       //     {
       //         distance = Math.Sqrt(
       //             Math.Pow((userControl.Location.X - element.Location.X),2) + 
       //             Math.Pow((userControl.Location.Y - element.Location.Y),2)
       //             );
       //         if (distance <=10)
       //         {
       //             return false;
       //         }
             
       //     }
       //     return false;
       // }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

           // IsColliding(userControl: UserControl);
        }

        private void Ecosystem_KeyDown(object sender, KeyEventArgs e)
        {
            lion.MoveWithKey(e);
            Mange();
        }


        private void Mange()
        {
            foreach (UserControlLapin.UserControlLapin lapin in Lapins)
            {
                if (lion.Bounds.IntersectsWith(lapin.Bounds))
                {
                    lapin.Dispose();
                }
            }

            foreach(UserControlCarotte.UserControlCarotte carotte in Carot)
            {
                if(lion.Bounds.IntersectsWith(carotte.Bounds))
                {
                    carotte.Dispose();
                }

            }

        }

    }
}
