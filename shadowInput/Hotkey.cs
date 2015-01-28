using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shadowInput
{
    public class Hotkey
    {
        private Keys key;
        private Keys modifierKey;
        private Func<bool> method;

        private bool blocked;
        private bool check;

        public Hotkey(Keys key, Keys modifierKey, Func<bool> method)
        {
            this.key = key;
            this.modifierKey = modifierKey;
            this.method = method;
        }

        public Hotkey(Keys key, Keys modifierKey, Action function)
        {
            this.key = key;
            this.modifierKey = modifierKey;
            this.method = () => 
            {
                function();
                return true;
            };
        }

        public Keys Key
        {
            get { return key; }
            set { key = value; }
        }

        public Keys ModifierKey
        {
            get { return modifierKey; }
            set { modifierKey = value; }
        }

        public Func<bool> Method
        {
            get { return method; }
        }

        public bool Blocked
        {
            get { return blocked; }
            set { blocked = value; }
        }

        public bool Check
        {
            get { return check; }
            set { check = value; }
        }
    }
}
