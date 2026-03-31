using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MiniDuel.Net.Message
{
    class DuelSpectatorCountMessage : NetMessage
    {
        public override NetMessageType Type
        {
            get { return NetMessageType.DuelSpectatorCount; }
        }

        public int Count;

        public override void Read(BinaryReader reader)
        {
            Count = reader.ReadInt32();
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(Count);
        }
    }
}


