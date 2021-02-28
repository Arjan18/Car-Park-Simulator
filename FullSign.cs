using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class FullSign
    {
        private bool lit;

        public FullSign()
        {
            lit = false;
        }

        public bool IsLit()
        {
            return lit;
        }

        public void SetLit(bool checkLit)
        {
            lit = checkLit;
        }
    }
}
