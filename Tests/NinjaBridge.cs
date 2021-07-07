using PluginsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public class NinjaBridge : Plugin
    {
        private Keys key = Keys.None;
        public NinjaBridge(Keys keys)
        {
            this.key = keys;
        }

        public override void Update()
        {
            if (IsKeyPressed(key))
            {
                RightClick();
                KeyDown(Keys.S);
                Sleep(230);
                KeyDown(Keys.LShiftKey);
                Sleep(210);
                KeyUp(Keys.S);
                Sleep(5);
                KeyUp(Keys.LShiftKey);
                RightClick();
            }
        }
    }
}
