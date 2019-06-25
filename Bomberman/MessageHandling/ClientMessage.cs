using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bomberman.MessageHandling
{
    public class ClientMessage
    {
        public readonly MessageConsts.RequestCode RequestCode;
        public readonly MessageConsts.GameKeyCode GameKeyCode;
        public readonly uint PlayerId;

        public ClientMessage(byte[] message)
        {
            RequestCode = (MessageConsts.RequestCode)message[0];
            GameKeyCode = (MessageConsts.GameKeyCode)message[1];
            PlayerId = BitConverter.ToUInt32(message, 2);
        }
    }
}
