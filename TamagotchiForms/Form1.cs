using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TamagotchiForms.Classes;

namespace TamagotchiForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            requestTimer.Start();
            lifeTimer.Start();

            StaminBar staminBar = new StaminBar(progressBar1);
            Pet pet = new Pet(staminBar);

            pet.Died += () => {
                lifeTimer.Stop();
                requestTimer.Stop();
                };

            pet.RequestShowed += () => {
                lifeTimer.Stop();
                requestTimer.Stop();
            };

            pet.RequestClosed += () => {
                lifeTimer.Start();
                requestTimer.Start();
            };

            requestTimer.Tick += pet.OnTimerTick;
            lifeTimer.Tick += pet.OnDied;
        }
        
        
    }
}
