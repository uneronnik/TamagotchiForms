using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TamagotchiForms.Classes
{
    class StaminBar
    {
        public delegate void FatigueHandler();
        public event FatigueHandler Tired;

        ProgressBar _bar;
        const int _maxStamin = 3;
        int _currentStamin = _maxStamin;
        public StaminBar(ProgressBar bar)
        {
            _bar = bar;
            bar.Click += ResetStamin;
            UpdateBarValue();
            
        }

        public void ReduceStamin()
        {
            _currentStamin -= 1;
            UpdateBarValue();
            if (_currentStamin == 0)
                Tired?.Invoke();
        }
        private void UpdateBarValue()
        {
            _bar.Value = (int)((double)_currentStamin / _maxStamin * 100);
        }
        public void ResetStamin(object sender, EventArgs e)
        {
            _currentStamin = _maxStamin;
            UpdateBarValue();
        }


    }
}
