using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacrosConverter
{
    public class CPPButtonCodes
    {
        public static Keys GetKey(int keycode)
        {
            string key = "0x" + keycode;
            return GetKey(key);
        }
        public static Keys GetKey(string key)
        {
            switch (key)
            {
                case "0x1":
                    return Keys.LButton;
                case "0x2":
                    return Keys.RButton;
                case "0x4":
                    return Keys.MButton;
                case "0x5":
                    return Keys.XButton1;
                case "0x6":
                    return Keys.XButton2;
                case "0x8":
                    return Keys.Back;
                case "0x9":
                    return Keys.Tab;
                case "0x0C":
                    return Keys.Clear;
                case "0x0D":
                    return Keys.Enter;
                case "0x10":
                    return Keys.ShiftKey;
                case "0x11":
                    return Keys.ControlKey;
                case "0x12":
                    return Keys.Alt;
                case "0x13":
                    return Keys.Pause;
                case "0x14":
                    return Keys.CapsLock;
                case "0x1B":
                    return Keys.Escape;
                case "0x20":
                    return Keys.Space;
                case "0x30":
                    return Keys.D0;
                case "0x31":
                    return Keys.D1;
                case "0x32":
                    return Keys.D2;
                case "0x33":
                    return Keys.D3;
                case "0x34":
                    return Keys.D4;
                case "0x35":
                    return Keys.D5;
                case "0x36":
                    return Keys.D6;
                case "0x37":
                    return Keys.D7;
                case "0x38":
                    return Keys.D8;
                case "0x39":
                    return Keys.D9;
                default:
                    return Keys.None;
            }
        }
        public static int GetCode(Keys key)
        {
            switch (key)
            {
                case Keys.D0:
                    return 0x30;
                case Keys.D1:
                    return 0x31;
                default:
                    return -1;
            }
        }
    }
}
