using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TamagotchiForms.Classes
{
    class Pet
    {
        public delegate void DieHandler();
        public event DieHandler Died;

        public delegate void RequestHandler();
        public event RequestHandler RequestShowed;
        public event RequestHandler RequestClosed;

        StaminBar _staminBar;
        int _healthPoints = 3;

        public Pet(StaminBar staminBar)
        {
            _staminBar = staminBar;
            _staminBar.Tired += OnTired;
        }

        enum RequestType
        { 
            Eat,
            Walk,
            Heal,
            Sleep
        }
        public void OnTired()
        {
            RequestShowed();
            ShowRequest(RequestType.Sleep);
            RequestClosed();
        }
        public void OnTimerTick(object sender, EventArgs e)
        {
            RequestType generatedRequest = GenerateRequest();

            RequestShowed();
            ShowRequest(generatedRequest);
            RequestClosed();

            _staminBar.ReduceStamin();
        }
        public void OnDied(object sender, EventArgs e)
        {
            Died?.Invoke();
            MessageBox.Show("Умер", "Конец", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        RequestType GenerateRequest()
        {
            Random random = new Random();
            return (RequestType)random.Next(0, 2);
        }

        void HandleAnswer(RequestType requestType, bool answer)
        {
               
        }
        bool ShowRequest(RequestType requestType)
        {
            string messageText = "";
            switch(requestType)
            {
                case RequestType.Eat:
                    messageText = "Хочу есть";
                    break;
                case RequestType.Walk:
                    messageText = "Хочу гулять";
                    break;
                case RequestType.Sleep:
                    messageText = "Хочу спать";
                    break;
            }
            if(MessageBox.Show(messageText, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

    }
}
