using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18_Task
{
    class Receiver : Command
    {
        Downloader downloader;

        public Receiver(Downloader downloader)
        {
            this.downloader = downloader;
        }
        public override void Run()
        {
            downloader.Operation();
        }
    }
}
