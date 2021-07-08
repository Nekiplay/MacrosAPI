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
            /* Test Macro */
            PluginUpdater pluginUpdater = new PluginUpdater();
            PluginClient client = new PluginClient(pluginUpdater);
            FastZoom ninjaBridge = new FastZoom();
            client.PluginLoad(ninjaBridge);
            Console.ReadKey();
        }
    }
}
