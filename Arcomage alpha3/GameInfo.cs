using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage_alpha3
{
    [Serializable]
    public class GameInfo
    {
        int _player1_towerSize = 20;
        int _player1_wallSize = 10;
        int _player1_quarry = 2;
        int _player1_bricks = 15;
        int _player1_magic = 2;
        int _player1_gems = 15;
        int _player1_dungeon = 2;
        int _player1_recruits = 15;

        int _player2_towerSize = 20;
        int _player2_wallSize = 10;
        int _player2_quarry = 2;
        int _player2_bricks = 15;
        int _player2_magic = 2;
        int _player2_gems = 15;
        int _player2_dungeon = 2;
        int _player2_recruits = 15;
        public GameInfo()
        {
            _player1_towerSize = 20;
            _player1_wallSize = 10;
            _player1_quarry = 2;
            _player1_bricks = 15;
            _player1_magic = 2;
            _player1_gems = 15;
            _player1_dungeon = 2;
            _player1_recruits = 15;

            _player2_towerSize = 20;
            _player2_wallSize = 10;
            _player2_quarry = 2;
            _player2_bricks = 15;
            _player2_magic = 2;
            _player2_gems = 15;
            _player2_dungeon = 2;
            _player2_recruits = 15;
        }
        public bool turn = true; // true - Player 1; false - Player 2

        public string player1_name = "Player 1";
        public int player1_towerSize
        {
            get
            {
                return _player1_towerSize;
            }
            set
            {
                _player1_towerSize = value;
                if (_player1_towerSize <= 0)
                {
                    _player1_towerSize = 0;
                }
                if (_player1_towerSize >= 100)
                {
                    _player1_towerSize = 100;
                }
            }
        }
        public int player1_wallSize
        {
            get
            {
                return _player1_wallSize;
            }
            set
            {
                _player1_wallSize = value;
                if (_player1_wallSize <= 0)
                {
                    _player1_wallSize = 0;
                }
                if (_player1_wallSize >= 100)
                {
                    _player1_wallSize = 100;
                }
            }
        }
        public int player1_quarry
        {
            get
            {
                return _player1_quarry;
            }
            set
            {
                _player1_quarry = value;
                if (_player1_quarry <= 0)
                {
                    _player1_quarry = 0;
                }
                if (_player1_quarry >= 99)
                {
                    _player1_quarry = 99;
                }
            }
        }
        public int player1_bricks
        {
            get
            {
                return _player1_bricks;
            }
            set
            {
                _player1_bricks = value;
                if (_player1_bricks <= 0)
                {
                    _player1_bricks = 0;
                }
                if (_player1_bricks >= 999)
                {
                    _player1_bricks = 999;
                }
            }
        }
        public int player1_magic
        {
            get
            {
                return _player1_magic;
            }
            set
            {
                _player1_magic = value;
                if (_player1_magic <= 0)
                {
                    _player1_magic = 0;
                }
                if (_player1_magic >= 99)
                {
                    _player1_magic = 99;
                }
            }
        }
        public int player1_gems
        {
            get
            {
                return _player1_gems;
            }
            set
            {
                _player1_gems = value;
                if (_player1_gems <= 0)
                {
                    _player1_gems = 0;
                }
                if (_player1_gems >= 999)
                {
                    _player1_gems = 999;
                }
            }
        }
        public int player1_dungeon
        {
            get
            {
                return _player1_dungeon;
            }
            set
            {
                _player1_dungeon = value;
                if (_player1_dungeon <= 0)
                {
                    _player1_dungeon = 0;
                }
                if (_player1_dungeon >= 99)
                {
                    _player1_dungeon = 99;
                }
            }
        }
        public int player1_recruits
        {
            get
            {
                return _player1_recruits;
            }
            set
            {
                _player1_recruits = value;
                if (_player1_recruits <= 0)
                {
                    _player1_recruits = 0;
                }
                if (_player1_recruits >= 999)
                {
                    _player1_recruits = 999;
                }
            }
        }

        public string player2_name = "Player 2";
        public int player2_towerSize
        {
            get
            {
                return _player2_towerSize;
            }
            set
            {
                _player2_towerSize = value;
                if (_player2_towerSize <= 0)
                {
                    _player2_towerSize = 0;
                }
                if (_player2_towerSize >= 100)
                {
                    _player2_towerSize = 100;
                }
            }
        }
        public int player2_wallSize
        {
            get
            {
                return _player2_wallSize;
            }
            set
            {
                _player2_wallSize = value;
                if (_player2_wallSize <= 0)
                {
                    _player2_wallSize = 0;
                }
                if (_player2_wallSize >= 100)
                {
                    _player2_wallSize = 100;
                }
            }
        }
        public int player2_quarry
        {
            get
            {
                return _player2_quarry;
            }
            set
            {
                _player2_quarry = value;
                if (_player2_quarry <= 0)
                {
                    _player2_quarry = 0;
                }
                if (_player2_quarry >= 99)
                {
                    _player2_quarry = 99;
                }
            }
        }
        public int player2_bricks
        {
            get
            {
                return _player2_bricks;
            }
            set
            {
                _player2_bricks = value;
                if (_player2_bricks <= 0)
                {
                    _player2_bricks = 0;
                }
                if (_player2_bricks >= 999)
                {
                    _player2_bricks = 999;
                }
            }
        }
        public int player2_magic
        {
            get
            {
                return _player2_magic;
            }
            set
            {
                _player2_magic = value;
                if (_player2_magic <= 0)
                {
                    _player2_magic = 0;
                }
                if (_player2_magic >= 99)
                {
                    _player2_magic = 99;
                }
            }
        }
        public int player2_gems
        {
            get
            {
                return _player2_gems;
            }
            set
            {
                _player2_gems = value;
                if (_player2_gems <= 0)
                {
                    _player2_gems = 0;
                }
                if (_player2_gems >= 999)
                {
                    _player2_gems = 999;
                }
            }
        }
        public int player2_dungeon
        {
            get
            {
                return _player2_dungeon;
            }
            set
            {
                _player2_dungeon = value;
                if (_player2_dungeon <= 0)
                {
                    _player2_dungeon = 0;
                }
                if (_player2_dungeon >= 99)
                {
                    _player2_dungeon = 99;
                }
            }
        }
        public int player2_recruits
        {
            get
            {
                return _player2_recruits;
            }
            set
            {
                _player2_recruits = value;
                if (_player2_recruits <= 0)
                {
                    _player2_recruits = 0;
                }
                if (_player2_recruits >= 999)
                {
                    _player2_recruits = 999;
                }
            }
        }

    }
}
