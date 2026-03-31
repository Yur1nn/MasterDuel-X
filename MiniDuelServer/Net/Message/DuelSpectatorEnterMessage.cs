using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MiniDuel.Net.Message
{
    class DuelSpectatorEnterMessage : NetMessage
    {
        public override NetMessageType Type
        {
            get { return NetMessageType.DuelSpectatorEnter; }
        }
    }
}


