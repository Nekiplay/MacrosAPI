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
    public class WTFBridge : Plugin
    {
        private Keys key = Keys.None;
        public WTFBridge(Keys keys)
        {
            this.key = keys;
        }

        public override void Update()
        {
            if (IsKeyPressed(key))
            {
                RightClick();
                Thread.Sleep(32);
                MouseMove(600, -800);
                Thread.Sleep(32);
            }
        }
    }
}
