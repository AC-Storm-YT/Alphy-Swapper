using System;
using Alphy;

namespace Alphy2
{
    public class SwapperPlugin : Alphy.Form1.IAlphyPlugin
    {
        private Alphy.Form1.IAlphyHost _host;

        public string Name => "Alphy Swapper";
        public string Description => "Advanced .upk and .bnk asset swapper.";
        public string Version => "1.0.2";

        public void Initialize(Alphy.Form1.IAlphyHost host)
        {
            _host = host;
            _host.LogToConsole("System: Alphy Swapper Plugin loaded and connected to Alphy.");
        }

        public void ShowUI()
        {
            using (Form1 swapperForm = new Form1(_host))
            {
                swapperForm.ShowDialog();
            }
        }
    }
}