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
            var player = GameFactory.Instance.ConnectPlayer();
            return BitConverter.GetBytes(player.ID);
        }

        private byte[] HandleRequestForExistingGame(ClientMessage message)
        {
            var player = GameFactory.Instance.ConnectPlayer(message.PlayerId);
            return BitConverter.GetBytes(player.ID);
        }

        private byte[] HandleGamingRequest(ClientMessage message)
        {
            switch (message.GameKeyCode)
            {
                case MessageConsts.GameKeyCode.KEY_UP_GAME_CODE:
                    HandleKeyUp(message);
                    break;
                case MessageConsts.GameKeyCode.KEY_DOWN_GAME_CODE:
                    HandleKeyDown(message);
                    break;
                case MessageConsts.GameKeyCode.KEY_LEFT_GAME_CODE:
                    HandleKeyLeft(message);
                    break;
                case MessageConsts.GameKeyCode.KEY_RIGHT_GAME_CODE:
                    HandleKeyRight(message);
                    break;
                case MessageConsts.GameKeyCode.KEY_SPACEBAR_GAME_CODE:
                    HandleKeySpacebar(message);
                    break;
                default:
                    throw new InvalidOperationException("Niepoprawny kod klawisza!");
            }
            return null;
        }

        private void HandleKeyUp(ClientMessage message)
        {
            throw new NotImplementedException();
        }

        private void HandleKeyDown(ClientMessage message)
        {
            throw new NotImplementedException();
        }

        private void HandleKeyLeft(ClientMessage message)
        {
            throw new NotImplementedException();
        }

        private void HandleKeyRight(ClientMessage message)
        {
            throw new NotImplementedException();
        }

        private void HandleKeySpacebar(ClientMessage message)
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
