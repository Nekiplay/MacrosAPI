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
                DownKey(Keys.S);
                Thread.Sleep(230);
                DownKey(Keys.LShiftKey);

                Thread.Sleep(210);
                UpKey(Keys.S);
                Thread.Sleep(5);
                UpKey(Keys.LShiftKey);
                RightClick();
            }
        }
    }
}
