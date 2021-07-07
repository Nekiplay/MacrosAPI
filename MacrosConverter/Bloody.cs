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
                    else if (down.StartsWith("KeyDown"))
                    {
                        Keys key = CPPButtonCodes.GetKey(int.Parse(Regex.Match(line, "KeyDown (.*)").Groups[1].Value.Split(' ')[0]));
                        if (key != Keys.None)
                        {
                            if (language == MacrosConverter.Languages.CSharp)
                            {
                                done += "if (IsKeyPressed(" + key+ "))\n{\n";
                                ButtonStartDetect = true;
                            }
                        }
                    }
                    ValidLevel = 1337;
                    FileValid = true;
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
                else if (line.StartsWith("Delay") && line.EndsWith("ms") && ValidLevel == 1337)
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
                        if (ButtonStartDetect)
                        {
                            done += "   KeyUp(" + key + ");" + "\n";
                        }
                        else
                        {
                            done += "KeyUp(" + key + "); " + "\n";
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
                            done += "   KeyDown(" + key + ");" + "\n";
                        }
                        else
                        {
                            done += "KeyDown(" + key + "); " + "\n";
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
