using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacrosConverter
{
    public class Bloody
    {
        private bool ButtonStartDetect = false;
        private List<string> FileContent = new List<string>();
        public Bloody(List<string> FileContent)
        {
            this.FileContent = FileContent;
        }
        public bool FileValid = false;
        public string Convert(MacrosConverter.Languages language)
        {
            string done = "";
            int ValidLevel = 0;
            foreach (string line in FileContent)
            {
                if (line.StartsWith("<Root>") && ValidLevel == 0)
                {
                    ValidLevel++;
                }
                else if (line.StartsWith("  <DefaultMacro>") && ValidLevel == 1)
                {
                    ValidLevel++;
                }
                else if (line.StartsWith("    <Major></Major>") && ValidLevel == 2)
                {
                    ValidLevel++;
                }
                else if (line.StartsWith("    <KeyUp>") && ValidLevel == 3)
                {
                    ValidLevel++;
                }
                else if (line.StartsWith("    <KeyDown>") && ValidLevel == 4)
                {
                    ValidLevel++;
                }
                else if (line.StartsWith("      <Syntax>") && ValidLevel == 5)
                {
                    string down = Regex.Match(line, "<Syntax>(.*)").Groups[1].Value;
                    if (down == "LeftDown 1")
                    {
                        if (language == MacrosConverter.Languages.CSharp)
                        {
                            done += "if (IsKeyPressed(Keys.LButton))\n{\n";
                            ButtonStartDetect = true;
                        }
                    }
                    else if (down == "RightDown 1")
                    {
                        if (language == MacrosConverter.Languages.CSharp)
                        {
                            done += "if (IsKeyPressed(Keys.RButton))\n{\n";
                            ButtonStartDetect = true;
                        }
                    }
                    else if (down.StartsWith("KeyDown"))
                    {
                        Keys key = CPPButtonCodes.GetKey(int.Parse(Regex.Match(line, "KeyDown (.*)").Groups[1].Value.Split(' ')[0]));
                        if (key != Keys.None)
                        {
                            if (language == MacrosConverter.Languages.CSharp)
                            {
                                done += "if (IsKeyPressed(Keys." + key+ "))\n{\n";
                                ButtonStartDetect = true;
                            }
                        }
                    }
                    ValidLevel = 1337;
                    FileValid = true;
                }
                else if (line == "RightDown 1" && ValidLevel == 1337)
                {
                    if (language == MacrosConverter.Languages.CSharp)
                    {
                        if (ButtonStartDetect)
                        {
                            done += "   RightDown();" + "\n";
                        }
                        else
                        {
                            done += "RightDown(); " + "\n";
                        }
                    }
                }
                else if (line == "RightUp 1" && ValidLevel == 1337)
                {
                    if (language == MacrosConverter.Languages.CSharp)
                    {
                        if (ButtonStartDetect)
                        {
                            done += "   RightUp();" + "\n";
                        }
                        else
                        {
                            done += "RightUp(); " + "\n";
                        }
                    }
                }
                else if (line == "LeftDown 1" && ValidLevel == 1337)
                {
                    if (language == MacrosConverter.Languages.CSharp)
                    {
                        if (ButtonStartDetect)
                        {
                            done += "   LeftDown();" + "\n";
                        }
                        else
                        {
                            done += "LeftDown(); " + "\n";
                        }
                    }
                }
                else if (line == "LeftUp 1" && ValidLevel == 1337)
                {
                    if (language == MacrosConverter.Languages.CSharp)
                    {
                        if (ButtonStartDetect)
                        {
                            done += "   LeftUp();" + "\n";
                        }
                        else
                        {
                            done += "LeftUp(); " + "\n";
                        }
                    }
                }
                else if (line.StartsWith("MoveR") && ValidLevel == 1337)
                {
                    string x = Regex.Match(line, "MoveR (.*)").Groups[1].Value.Split(' ')[0];
                    string y = Regex.Match(line, "MoveR (.*)").Groups[1].Value.Split(' ')[1];
                    if (x != "" && y != "")
                    {
                        if (language == MacrosConverter.Languages.CSharp)
                        {
                            if (ButtonStartDetect)
                            {
                                done += "   MouseMove(" + x + ", " + y + ");" + "\n";
                            }
                            else
                            {
                                done += "MouseMove(" + x + ", " + y + ");" + "\n";
                            }
                        }
                    }
                }
                else if (line.StartsWith("Delay") && ValidLevel == 1337)
                {
                    int delay = int.Parse(Regex.Match(line, "Delay (.*) ms").Groups[1].Value);
                    if (language == MacrosConverter.Languages.CSharp)
                    {
                        if (ButtonStartDetect)
                        {
                            done += "   Sleep(" + delay + ");" + "\n";
                        }
                        else
                        {
                            done += "Sleep(" + delay + ");" + "\n";
                        }
                    }
                }
                else if(line.StartsWith("KeyUp") && ValidLevel == 1337)
                {
                    Keys key = CPPButtonCodes.GetKey(int.Parse(Regex.Match(line, "KeyUp (.*)").Groups[1].Value.Split(' ')[0]));
                    if (language == MacrosConverter.Languages.CSharp)
                    {
                        if (key == Keys.None)
                        {
                            if (int.Parse(Regex.Match(line, "KeyUp (.*)").Groups[1].Value.Split(' ')[0]) == 224)
                            {
       
                            }
                        }
                        if (ButtonStartDetect)
                        {
                            done += "   KeyUp(Keys." + key + ");" + "\n";
                        }
                        else
                        {
                            done += "KeyUp(Keys." + key + "); " + "\n";
                        }
                    }
                }
                else if (line.StartsWith("KeyDown") && ValidLevel == 1337)
                {
                    Keys key = CPPButtonCodes.GetKey(int.Parse(Regex.Match(line, "KeyDown (.*)").Groups[1].Value.Split(' ')[0]));
                    if (language == MacrosConverter.Languages.CSharp)
                    {
                        if (ButtonStartDetect)
                        {
                            done += "   KeyDown(Keys." + key + ");" + "\n";
                        }
                        else
                        {
                            done += "KeyDown(Keys." + key + "); " + "\n";
                        }
                    }
                }
            }
            if (ButtonStartDetect)
            {
                if (language == MacrosConverter.Languages.CSharp)
                {
                    done += "}";
                }
            }
            return done;
        }
    }
}
