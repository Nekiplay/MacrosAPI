using PluginsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public class LegitCPS : Plugin
    {
        private Keys key = Keys.None;
        private int minimum = 12;
        private int maximum = 15;
        public LegitCPS(Keys keys, int minimum, int maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
            this.key = keys;
        }

        public override void Update()
        {
            if (IsKeyPressed(key))
            {
                for (int i = 0; i < Generate(25, 35); i++)
                {
                    if (IsKeyPressed(key))
                    {
                        LeftClick();
                        Sleep(1000 / Generate(minimum, maximum));
                    }
                    else { break; }
                }
            }
        }
        private int Generate(int minimum, int maximum)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(minimum, maximum + 1);
        }
    }
}
