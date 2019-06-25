using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Bomberman.MessageHandling
{
    public class MessageHandler
    {
        public static MessageHandler Instance;
        private MessageHandler()
        {
        }

        static MessageHandler()
        {
            Instance = new MessageHandler();
        }

        private byte[] HandleRequestForNewGame(byte[] message)
        {
            throw new NotImplementedException();
        }

        private byte[] HandleRequestForExistingGame()
        {
            throw new NotImplementedException();
        }

        private byte[] HandleKeyUp()
        {
            throw new NotImplementedException();
        }

        private byte[] HandleKeyDown()
        {
            throw new NotImplementedException();
        }

        private byte[] HandleKeyLeft()
        {
            throw new NotImplementedException();
        }

        private byte[] HandleKeyRight()
        {
            throw new NotImplementedException();
        }

        private byte[] HandleKeySpacebar()
        {
            throw new NotImplementedException();
        }

        public byte[] HandleMessage(byte[] buffer)
        {
            ClientMessage message = new ClientMessage(buffer);
            return buffer;
        }
    }
}
