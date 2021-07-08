using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MacrosConverter
{
    public class MacrosConverter
    {
        private FileInfo File;
        private string SaveFile;

        public List<string> FileContent = new List<string>();
        public MacrosConverter(FileInfo File)
        {
            this.File = File;
            this.SaveFile = SaveFile;

            if (System.IO.File.Exists(File.FullName))
            {
                using (var reader = new StreamReader(new BufferedStream(System.IO.File.OpenRead(File.FullName), 1024 * 1024)))
                {
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        FileContent.Add(line);
                    }
                }
            }
            bloody = new Bloody(FileContent);
            logitech = new Logitech(FileContent);
        }
        public Bloody bloody = null;
        public Logitech logitech = null;
        public enum Languages
        {
            None,
            Bloody,
            CSharp,
        }
    }
}
