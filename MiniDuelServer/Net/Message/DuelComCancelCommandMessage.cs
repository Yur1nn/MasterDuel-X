using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDuel.Net.Message
{
    class DuelComCancelCommandMessage : DuelComMessage
    {
        public override NetMessageType Type
        {
            get { return NetMessageType.DuelComCancelCommand; }
        }
    }
}


