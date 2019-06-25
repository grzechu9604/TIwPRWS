using Bomberman.GameLogic.Player;
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

        private byte[] HandleRequestForNewGame()
        {
            var playerId = PlayerIdProvider.Instance.GetId();
            return BitConverter.GetBytes(playerId);
        }

        private byte[] HandleRequestForExistingGame(ClientMessage message)
        {
            return BitConverter.GetBytes(message.PlayerId);
        }

        private byte[] HandleGamingRequest(ClientMessage message)
        {
            return BitConverter.GetBytes(message.PlayerId);
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

            switch (message.RequestCode)
            {
                case MessageConsts.RequestCode.REQUEST_FOR_NEW_GAME_CODE:
                    return HandleRequestForNewGame();
                case MessageConsts.RequestCode.REQUEST_FOR_EXISTING_GAME_CODE:
                    return HandleRequestForExistingGame(message);
                case MessageConsts.RequestCode.GAMING_REQUEST_CODE:
                    return HandleGamingRequest(message);
                default:
                    throw new InvalidOperationException("Nieprawidłowy kod wiadomości!");
            }
        }
    }
}
