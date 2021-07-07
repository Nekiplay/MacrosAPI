using PluginsAPI;
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
            PluginUpdater pluginUpdater = new PluginUpdater();
            PluginClient pluginClient = new PluginClient(pluginUpdater);
            LegitCPS auto = new LegitCPS(Keys.XButton2, 14, 20);
            pluginClient.PluginLoad(auto);
            Console.ReadKey();
        }
    }
}
