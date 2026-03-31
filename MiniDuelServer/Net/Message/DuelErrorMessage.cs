using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDuel.Net.Message
{
    class DuelErrorMessage : NetMessage
    {
        public override NetMessageType Type
        {
            get { return NetMessageType.DuelError; }
        }
    }
}


