using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcherVirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // As soon as the first form is ready, hide the form. Will not be visible on taskbar or 
        // in windows task manager applications. Go to Processes to kill it.
        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Hide();            
        }

        // Every timer tick make a new instance of the form Pirate and show it
        // This is the form that plays the video and sound for the 'virus'         
        private void timer1_Tick(object sender, EventArgs e)
        {
            Pirate pirate = new Pirate();
            pirate.Show();
        }
    }
}
