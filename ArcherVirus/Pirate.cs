using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ArcherVirus
{
    // This form is setup to open on top, in fullscreen, with no borders.
    public partial class Pirate : Form
    {
        // Make a soundplayer to play the sound for the 'virus'
        SoundPlayer player = new SoundPlayer();
        // Make a timer that is the length of the 'virus'
        System.Timers.Timer timer = new System.Timers.Timer(13000);
        public Pirate()
        {
            InitializeComponent();
        }

        private void Pirate_Load(object sender, EventArgs e)
        {
            try
            {   
                //Load the 'virus' gif from an embedded resource
                System.Reflection.Assembly thisExe;
                thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream file = thisExe.GetManifestResourceStream("ArcherVirus.Archer.gif");

                //Display the 'virus' gif
                pictureBox1.Image = Image.FromStream(file);
                
                //Load the sound from an embedded resource
                player.Stream = this.GetType().Assembly.GetManifestResourceStream("ArcherVirus.Archer.wav");
                player.Play();

                // Make the timer call the method "timer_tick" on each tick.
                // Enable the timer
                timer.SynchronizingObject = this;
                timer.Elapsed += new ElapsedEventHandler(timer_tick); // Everytime timer 
                timer.Enabled = true;                       // Enable the timer
            }

            catch { }
        }

        // This method runs on the timer tick and stops the sound player as well as disposing of the 
        // form.
        private void timer_tick(object sender, EventArgs e)
        {
            player.Stop();
            this.Close();
        }        
    }
}
