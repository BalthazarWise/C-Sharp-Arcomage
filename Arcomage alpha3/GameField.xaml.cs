using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Arcomage_alpha3
{
    /// <summary>
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : Window
    {
        const int cardsCount = 102;
        NetManO2O net = new NetManO2O();
        public GameInfo gameInfo = new GameInfo();
        Random rnd = new Random();
        int[] deck = new int[cardsCount];
        public bool turn = false;
        Card card = new Card();
        bool isGameEnded = false;

        public GameField()
        {
            InitializeComponent();
            SortDeck();
            CloseAllCards();
            RefreshInterface();
        }

        internal void Server()
        {
            //NetManO2O net = new NetManO2O();
            net.onRecieve += Recive;
            net.CreateServer();
        }
        internal void Client(string ip)
        {
            //NetManO2O net = new NetManO2O();
            net.onRecieve += Recive;
            net.CreateClient(ip);
        }
        private void Recive()
        {
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                gameInfo = LoadInfo(@"GameInfo.txt");
                RefreshInterface();
            }));
        }
        public void RefreshInterface()
        {
            player1Tower.Value = gameInfo.player1_towerSize;
            player1Wall.Value = gameInfo.player1_wallSize;
            player1TowerSize.Content = gameInfo.player1_towerSize;
            player1WallSize.Content = gameInfo.player1_wallSize;
            player1Quarry.Content = gameInfo.player1_quarry;
            player1Bricks.Content = gameInfo.player1_bricks;
            player1Magic.Content = gameInfo.player1_magic;
            player1Gems.Content = gameInfo.player1_gems;
            player1Dungeon.Content = gameInfo.player1_dungeon;
            player1Recruits.Content = gameInfo.player1_recruits;

            player2Tower.Value = gameInfo.player2_towerSize;
            player2Wall.Value = gameInfo.player2_wallSize;
            player2TowerSize.Content = gameInfo.player2_towerSize;
            player2WallSize.Content = gameInfo.player2_wallSize;
            player2Quarry.Content = gameInfo.player2_quarry;
            player2Bricks.Content = gameInfo.player2_bricks;
            player2Magic.Content = gameInfo.player2_magic;
            player2Gems.Content = gameInfo.player2_gems;
            player2Dungeon.Content = gameInfo.player2_dungeon;
            player2Recruits.Content = gameInfo.player2_recruits;

            if (gameInfo.turn == true && net.getType() == "client")
            {
                CloseAllCards();
            }
            if (gameInfo.turn == false && net.getType() == "client")
            {
                OpenAvialableCards();
            }
            if (gameInfo.turn == false && net.getType() == "server")
            {
                CloseAllCards();
            }
            if (gameInfo.turn == true && net.getType() == "server")
            {
                OpenAvialableCards();
            }
            if (!isGameEnded)
            {
                CheckWin();
            }

        }
        private void CloseAllCards()
        {
            card = card.getCard(deck[0]);
            card1.Background = GetImageBrush(card.imgNameLocked);
            card = card.getCard(deck[1]);
            card2.Background = GetImageBrush(card.imgNameLocked);
            card = card.getCard(deck[2]);
            card3.Background = GetImageBrush(card.imgNameLocked);
            card = card.getCard(deck[3]);
            card4.Background = GetImageBrush(card.imgNameLocked);
            card = card.getCard(deck[4]);
            card5.Background = GetImageBrush(card.imgNameLocked);
            card = card.getCard(deck[5]);
            card6.Background = GetImageBrush(card.imgNameLocked);
            card1.IsEnabled = false;
            card2.IsEnabled = false;
            card3.IsEnabled = false;
            card4.IsEnabled = false;
            card5.IsEnabled = false;
            card6.IsEnabled = false;
        }
        private void OpenAvialableCards()
        {
            card1.IsEnabled = true;
            card2.IsEnabled = true;
            card3.IsEnabled = true;
            card4.IsEnabled = true;
            card5.IsEnabled = true;
            card6.IsEnabled = true;
            card = card.getCard(deck[0]);
            if ((net.getType() == "server" && gameInfo.player1_bricks >= card.costBricks && gameInfo.player1_gems >= card.costGems && gameInfo.player1_recruits >= card.costRecruits) ||
                (net.getType() == "client" && gameInfo.player2_bricks >= card.costBricks && gameInfo.player2_gems >= card.costGems && gameInfo.player2_recruits >= card.costRecruits))
            {
                card1.Background = GetImageBrush(card.imgName);
            }
            card = card.getCard(deck[1]);
            if ((net.getType() == "server" && gameInfo.player1_bricks >= card.costBricks && gameInfo.player1_gems >= card.costGems && gameInfo.player1_recruits >= card.costRecruits) ||
                (net.getType() == "client" && gameInfo.player2_bricks >= card.costBricks && gameInfo.player2_gems >= card.costGems && gameInfo.player2_recruits >= card.costRecruits))
            {
                card2.Background = GetImageBrush(card.imgName);
            }
            card = card.getCard(deck[2]);
            if ((net.getType() == "server" && gameInfo.player1_bricks >= card.costBricks && gameInfo.player1_gems >= card.costGems && gameInfo.player1_recruits >= card.costRecruits) ||
                (net.getType() == "client" && gameInfo.player2_bricks >= card.costBricks && gameInfo.player2_gems >= card.costGems && gameInfo.player2_recruits >= card.costRecruits))
            {
                card3.Background = GetImageBrush(card.imgName);
            }
            card = card.getCard(deck[3]);
            if ((net.getType() == "server" && gameInfo.player1_bricks >= card.costBricks && gameInfo.player1_gems >= card.costGems && gameInfo.player1_recruits >= card.costRecruits) ||
                (net.getType() == "client" && gameInfo.player2_bricks >= card.costBricks && gameInfo.player2_gems >= card.costGems && gameInfo.player2_recruits >= card.costRecruits))
            {
                card4.Background = GetImageBrush(card.imgName);
            }
            card = card.getCard(deck[4]);
            if ((net.getType() == "server" && gameInfo.player1_bricks >= card.costBricks && gameInfo.player1_gems >= card.costGems && gameInfo.player1_recruits >= card.costRecruits) ||
                (net.getType() == "client" && gameInfo.player2_bricks >= card.costBricks && gameInfo.player2_gems >= card.costGems && gameInfo.player2_recruits >= card.costRecruits))
            {
                card5.Background = GetImageBrush(card.imgName);
            }
            card = card.getCard(deck[5]);
            if ((net.getType() == "server" && gameInfo.player1_bricks >= card.costBricks && gameInfo.player1_gems >= card.costGems && gameInfo.player1_recruits >= card.costRecruits) ||
                (net.getType() == "client" && gameInfo.player2_bricks >= card.costBricks && gameInfo.player2_gems >= card.costGems && gameInfo.player2_recruits >= card.costRecruits))
            {
                card6.Background = GetImageBrush(card.imgName);
            }
        }
        private static ImageBrush GetImageBrush(string fileName)
        {
            ImageBrush imgBrush = new ImageBrush();
            BitmapImage bmi = new BitmapImage();
            string fullPath = @"Images\" + fileName;

            bmi.BeginInit();
            bmi.UriSource = new Uri(fullPath, UriKind.Relative);
            bmi.EndInit();

            imgBrush.ImageSource = bmi;

            return imgBrush;
        }
        private static void SaveInfo(GameInfo gI, string path)
        {
            path = (System.IO.Path.GetFullPath(path));
            XmlSerializer serializer = new XmlSerializer(typeof(GameInfo));
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, gI);
                fs.Flush();
                fs.Close();
            }
        }
        private static GameInfo LoadInfo(string path)
        {
            path = (System.IO.Path.GetFullPath(path));
            GameInfo gI;
            XmlSerializer serializer = new XmlSerializer(typeof(GameInfo));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                gI = (GameInfo)serializer.Deserialize(fs);
                fs.Flush();
                fs.Close();
            }
            return gI;
        }
        private void card1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click(0);
        }
        private void card2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click(1);
        }
        private void card3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click(2);
        }
        private void card4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click(3);
        }
        private void card5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click(4);
        }
        private void card6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click(5);
        }
        private void card1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Discard(0, true);
        }
        private void card2_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Discard(1, true);
        }
        private void card3_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Discard(2, true);
        }
        private void card4_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Discard(3, true);
        }
        private void card5_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Discard(4, true);
        }
        private void card6_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Discard(5, true);
        }

        private void PlayCard(Card card)
        {
            if (net.getType() == "server")
            {
                gameInfo.player1_bricks -= card.costBricks;
                gameInfo.player1_gems -= card.costGems;
                gameInfo.player1_recruits -= card.costRecruits;

                gameInfo.player1_towerSize += card.myTowerHealth;
                gameInfo.player1_wallSize += card.myWallHealth;
                gameInfo.player1_quarry += card.myQuarry;
                gameInfo.player1_bricks += card.myBricks;
                gameInfo.player1_magic += card.myMagic;
                gameInfo.player1_gems += card.myGems;
                gameInfo.player1_dungeon += card.myDungeon;
                gameInfo.player1_recruits += card.myRecruits;

                gameInfo.player2_towerSize += card.enemyTowerHealth;
                gameInfo.player2_wallSize += card.enemyWallHealth;
                gameInfo.player2_quarry += card.enemyQuarry;
                gameInfo.player2_bricks += card.enemyBricks;
                gameInfo.player2_magic += card.enemyMagic;
                gameInfo.player2_gems += card.enemyGems;
                gameInfo.player2_dungeon += card.enemyDungeon;
                gameInfo.player2_recruits += card.enemyRecruits;

                if (gameInfo.player1_wallSize > card.myDamage)
                {
                    gameInfo.player1_wallSize -= card.myDamage;
                }
                else
                {
                    int buffer = card.myDamage;
                    buffer -= gameInfo.player1_wallSize;
                    gameInfo.player1_wallSize = 0;
                    gameInfo.player1_towerSize -= buffer;
                }
                if (gameInfo.player2_wallSize > card.enemyDamage)
                {
                    gameInfo.player2_wallSize -= card.enemyDamage;
                }
                else
                {
                    int buffer = card.enemyDamage;
                    buffer -= gameInfo.player2_wallSize;
                    gameInfo.player2_wallSize = 0;
                    gameInfo.player2_towerSize -= buffer;
                }

            }
            if (net.getType() == "client")
            {
                gameInfo.player2_bricks -= card.costBricks;
                gameInfo.player2_gems -= card.costGems;
                gameInfo.player2_recruits -= card.costRecruits;

                gameInfo.player1_towerSize += card.enemyTowerHealth;
                gameInfo.player1_wallSize += card.enemyWallHealth;
                gameInfo.player1_quarry += card.enemyQuarry;
                gameInfo.player1_bricks += card.enemyBricks;
                gameInfo.player1_magic += card.enemyMagic;
                gameInfo.player1_gems += card.enemyGems;
                gameInfo.player1_dungeon += card.enemyDungeon;
                gameInfo.player1_recruits += card.enemyRecruits;

                gameInfo.player2_towerSize += card.myTowerHealth;
                gameInfo.player2_wallSize += card.myWallHealth;
                gameInfo.player2_quarry += card.myQuarry;
                gameInfo.player2_bricks += card.myBricks;
                gameInfo.player2_magic += card.myMagic;
                gameInfo.player2_gems += card.myGems;
                gameInfo.player2_dungeon += card.myDungeon;
                gameInfo.player2_recruits += card.myRecruits;

                if (gameInfo.player1_wallSize > card.enemyDamage)
                {
                    gameInfo.player1_wallSize -= card.enemyDamage;
                }
                else
                {
                    int buffer = card.enemyDamage;
                    buffer -= gameInfo.player1_wallSize;
                    gameInfo.player1_wallSize = 0;
                    gameInfo.player1_towerSize -= buffer;
                }
                if (gameInfo.player2_wallSize > card.myDamage)
                {
                    gameInfo.player2_wallSize -= card.myDamage;
                }
                else
                {
                    int buffer = card.myDamage;
                    buffer -= gameInfo.player2_wallSize;
                    gameInfo.player2_wallSize = 0;
                    gameInfo.player2_towerSize -= buffer;
                }
            }

        }
        private void SortDeck()
        {
            var nums = Enumerable.Range(0, cardsCount).ToList();
            deck = new int[cardsCount];
            for (int i = 0; i < cardsCount; i++)
            {
                int pos = rnd.Next(0, nums.Count);
                deck[i] = nums[pos];
                nums.RemoveAt(pos);
            }
        }
        private void Click(int cardNumber)
        {
            card = card.getCard(deck[cardNumber]);

            if ((net.getType() == "server" && gameInfo.player1_bricks >= card.costBricks && gameInfo.player1_gems >= card.costGems && gameInfo.player1_recruits >= card.costRecruits) ||
                (net.getType() == "client" && gameInfo.player2_bricks >= card.costBricks && gameInfo.player2_gems >= card.costGems && gameInfo.player2_recruits >= card.costRecruits))
            {
                PlayCard(card);
                Discard(cardNumber, false);
            }
        }
        private void Discard(int cardNumber, bool isDiscarded)
        {
            card = card.getCard(deck[cardNumber]);
            int buffer = deck[cardNumber];
            deck[cardNumber] = deck[6];
            for (int i = 6; i < cardsCount - 1; i++)
            {
                deck[i] = deck[i + 1];
            }
            deck[101] = buffer;
            if (card.playAgain != true || isDiscarded)
            {
                if (net.getType() == "server")
                {
                    gameInfo.player1_bricks += gameInfo.player1_quarry;
                    gameInfo.player1_gems += gameInfo.player1_magic;
                    gameInfo.player1_recruits += gameInfo.player1_dungeon;
                }
                if (net.getType() == "client")
                {
                    gameInfo.player2_bricks += gameInfo.player2_quarry;
                    gameInfo.player2_gems += gameInfo.player2_magic;
                    gameInfo.player2_recruits += gameInfo.player2_dungeon;
                }
                gameInfo.turn = !gameInfo.turn;
            }
            SaveInfo(gameInfo, @"GameInfo.txt");
            RefreshInterface();
            net.SendStr(card1.Name);
        }
        private void CheckWin()
        {
            EndGameForm egf;
            if (net.getType() == "server")
            {
                if (gameInfo.player1_towerSize == 100 || gameInfo.player2_towerSize == 0 || (gameInfo.player1_bricks == 300 || gameInfo.player1_gems == 300 || gameInfo.player1_recruits == 300))
                {
                    egf = new EndGameForm(true);
                    ShowEndGameForm(egf);
                }
                if (gameInfo.player2_towerSize == 100 || gameInfo.player1_towerSize == 0 || (gameInfo.player2_bricks == 300 || gameInfo.player2_gems == 300 || gameInfo.player2_recruits == 300))
                {
                    egf = new EndGameForm(false);
                    ShowEndGameForm(egf);
                }
            }
            if (net.getType() == "client")
            {
                if (gameInfo.player1_towerSize == 100 || gameInfo.player2_towerSize == 0 || (gameInfo.player1_bricks == 300 || gameInfo.player1_gems == 300 || gameInfo.player1_recruits == 300))
                {
                    egf = new EndGameForm(false);
                    ShowEndGameForm(egf);
                }
                if (gameInfo.player2_towerSize == 100 || gameInfo.player1_towerSize == 0 || (gameInfo.player2_bricks == 300 || gameInfo.player2_gems == 300 || gameInfo.player2_recruits == 300))
                {
                    egf = new EndGameForm(true);
                    ShowEndGameForm(egf);
                }
            }

        }
        private void ShowEndGameForm(EndGameForm egf)
        {
            isGameEnded = true;
            net.SendStr(card1.Name);
            egf.Owner = this;
            egf.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            egf.ShowDialog();
            Close();
        }
    }
}
