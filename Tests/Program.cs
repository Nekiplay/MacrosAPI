﻿using PluginsAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileInfo file = new FileInfo(@"C:\Users\Herob\Downloads\FastZoom shot.amc");
            MacrosConverter.MacrosConverter converter = new MacrosConverter.MacrosConverter(file);
            Console.WriteLine(converter.bloody.Convert(MacrosConverter.MacrosConverter.Languages.CSharp));
            Console.ReadKey();
        }
    }
}
