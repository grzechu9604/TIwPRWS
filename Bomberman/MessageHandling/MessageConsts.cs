using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bomberman.MessageHandling
{
    public class MessageConsts
    {
        public enum RequestCode
        {
            REQUEST_FOR_NEW_GAME_CODE = 1,
            REQUEST_FOR_EXISTING_GAME_CODE = 2,
            GAMING_REQUEST_CODE = 3
        }

        public enum GameKeyCode
        {
            KEY_UP_GAME_CODE = 1,
            KEY_DOWN_GAME_CODE = 2,
            KEY_LEFT_GAME_CODE = 3,
            KEY_RIGHT_GAME_CODE = 4,
            KEY_SPACEBAR_GAME_CODE = 5
        }
    }
}
