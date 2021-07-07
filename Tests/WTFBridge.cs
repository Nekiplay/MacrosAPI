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
        private void MakeTrash(int x, int y, Keys key = Keys.D, bool revert = false)
        {
            RightClick();
            Sleep(32);
            if (!revert)
                MouseMove(x, -y);
            else
                MouseMove(-x, -y);
            Sleep(16);
            RightClick();
            DownKey(key);
            Sleep(235);
            DownKey(Keys.LShiftKey);
            Sleep(150);
            UpKey(key);
            Sleep(15);
            UpKey(Keys.LShiftKey);
            if (!revert)
                MouseMove(-x, y);
            else
                MouseMove(x, y);
            Sleep(16);
            RightClick();
            Sleep(32);
            RightClick();
            Sleep(16);
            RightClick();
        }
        public override void Update()
        {
            if (IsKeyPressed(key))
            {
                MakeTrash(600, 600, Keys.D);
            }
            if (IsKeyPressed(key))
            {
                MakeTrash(600, 600, Keys.A, true);
            }
        }
    }
}
