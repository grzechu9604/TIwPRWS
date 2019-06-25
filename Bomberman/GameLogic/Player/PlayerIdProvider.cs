using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bomberman.GameLogic.Player
{
    public class PlayerIdProvider
    {
        private UInt32 _nextId = 0;
        private PlayerIdProvider()
        {
        }

        public static PlayerIdProvider Instance;

        static PlayerIdProvider()
        {
            Instance = new PlayerIdProvider();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public UInt32 GetId()
        {
            IncrementNextId();
            return _nextId;
        }

        private void IncrementNextId()
        {
            if (_nextId < UInt32.MaxValue)
            {
                _nextId++;
            }
            else
            {
                _nextId = 1;
            }
        }
    }
}
