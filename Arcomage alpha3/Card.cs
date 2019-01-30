using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage_alpha3
{
    class Card
    {
        public string imgName;
        public string imgNameLocked;

        public int costBricks = 0;
        public int costGems = 0;
        public int costRecruits = 0;

        public int enemyTowerHealth = 0;
        public int enemyWallHealth = 0;
        public int enemyDamage = 0;
        public int myTowerHealth = 0;
        public int myWallHealth = 0;
        public int myDamage = 0;

        public int myQuarry = 0;
        public int myBricks = 0;
        public int myMagic = 0;
        public int myGems = 0;
        public int myDungeon = 0;
        public int myRecruits = 0;

        public int enemyQuarry = 0;
        public int enemyBricks = 0;
        public int enemyMagic = 0;
        public int enemyGems = 0;
        public int enemyDungeon = 0;
        public int enemyRecruits = 0;
        
        public bool playAgain = false;
        public bool discardAfter = false;
        public int triggerNumber = 0;
        public Card getCard(int num)
        {
            if (num == 5 || num == 13 || num == 29 || num == 32 || num == 52 || num == 54 || num == 55 || num == 56 || num == 63 || num == 72 || num == 75 || num == 79 || num == 98 || num == 99 || num == 101)
            {
                num = 69;
            }
            Card card = new Card();
            card.imgName = @"Cards\" + num + ".png";
            card.imgNameLocked = @"Cards\" + num + "_locked.png";
            switch (num)
            {
                    //Blue cards
                case 0: {
                    card.costGems = 1;
                    card.myTowerHealth = 1;
                    card.playAgain = true;
                    break; }
                case 1: {
                    card.costGems = 2;
                    card.enemyTowerHealth = -1;
                    card.playAgain = true;
                    break; }
                case 2: {
                    card.costGems = 2;
                    card.myTowerHealth = 3;
                    break; }
                case 3: {
                    card.costGems = 3;
                    card.myMagic = 1;
                    break; }
                case 4: {
                    card.costGems = 2;
                    card.discardAfter = true;
                    card.playAgain = true;
                    break; }
                case 5: {
                    card.costGems = 5;
                    card.myTowerHealth = 3;
                    card.triggerNumber = 1; // Cant be discarded
                    break; }
                case 6: {
                    card.costGems = 4;
                    card.myTowerHealth = 2;
                    card.enemyTowerHealth = -2;
                    break; }
                case 7: {
                    card.costGems = 6;
                    card.myMagic = 1;
                    card.myTowerHealth = 3;
                    card.enemyTowerHealth = 1;
                    break; }
                case 8: {
                    card.costGems = 2;
                    card.enemyTowerHealth = -3;
                    break; }
                case 9: {
                    card.costGems = 3;
                    card.myTowerHealth = 5;
                    break; }
                case 10: {
                    card.costGems = 4;
                    card.enemyTowerHealth = -5;
                    break; }
                case 11: {
                    card.costGems = 3;
                    card.myMagic = 2;
                    card.myTowerHealth = -5;
                    break; }
                case 12: {
                    card.costGems = 7;
                    card.myMagic = 1;
                    card.myTowerHealth = 3;
                    card.myWallHealth = 3;
                    break; }
                case 13: {
                    card.costGems = 7;
                    card.triggerNumber = 2; // All magic equals the highest player magic
                    break; }
                case 14: {
                    card.costGems = 6;
                    card.myTowerHealth = 8;
                    break; }
                case 15: {
                    card.costGems = 9;
                    card.myTowerHealth = 5;
                    card.myMagic = 1;
                    break; }
                case 16: {
                    card.costGems = 8;
                    card.myMagic = -1;
                    card.enemyTowerHealth = -9;
                    break; }
                case 17: {
                    card.costGems = 7;
                    card.myTowerHealth = 5;
                    card.enemyBricks = -6;
                    break; }
                case 18: {
                    card.costGems = 10;
                    card.myTowerHealth = 11;
                    break; }
                case 19: {
                    card.costGems = 5;
                    card.myTowerHealth = -7;
                    card.enemyTowerHealth = -7;
                    card.myMagic = -1;
                    card.enemyMagic = -1;
                    break; }
                case 20: {
                    card.costGems = 13;
                    card.myTowerHealth = 6;
                    card.enemyTowerHealth = -4;
                    card.enemyWallHealth = -4;
                    break; }
                case 21: {
                    card.costGems = 4;
                    card.myTowerHealth = 7;
                    card.myBricks = -10;
                    break; }
                case 22: {
                    card.costGems = 12;
                    card.myTowerHealth = 8;
                    card.myWallHealth = 3;
                    break; }
                case 23: {
                    card.costGems = 14;
                    card.myTowerHealth = 8;
                    card.myDungeon = 1;
                    break; }
                case 24: {
                    card.costGems = 16;
                    card.myTowerHealth = 15;
                    break; }
                case 25: {
                    card.costGems = 15;
                    card.myTowerHealth = 10;
                    card.myWallHealth = 5;
                    card.myRecruits = 5;
                    break; }
                case 26: {
                    card.costGems = 17;
                    card.myTowerHealth = 12;
                    card.enemyTowerHealth = -6;
                    card.enemyWallHealth = -6;
                    break; }
                case 27: {
                    card.costGems = 21;
                    card.myTowerHealth = 20;
                    break; }
                case 28: {
                    card.costGems = 8;
                    card.myTowerHealth = 11;
                    card.myWallHealth = -6;
                    break; }
                case 29: {
                    card.triggerNumber = 3; // If myTower < ememyTower then myTower +2 else +1
                    break; }
                case 30: {
                    card.myTowerHealth = 1;
                    card.enemyTowerHealth = 1;
                    card.myGems = 3;
                    break; }
                case 31: {
                    card.costGems = 5;
                    card.myTowerHealth = 4;
                    card.myRecruits = -3;
                    card.enemyTowerHealth = -2;
                    break; }
                case 32: {
                    card.costGems = 11;
                    card.triggerNumber = 4; // if myTower > enemyTower then enemyTower -8 else enemyDamage 8;
                    break; }
                case 33: {
                    card.costGems = 18;
                    card.myTowerHealth = 13;
                    card.myRecruits = 6;
                    card.myBricks = 6;
                    break; }
                    //Green cards
                case 34: {
                    card.costRecruits = 0;
                    card.myRecruits = -6;
                    card.enemyRecruits = -6;
                    break; }
                case 35: {
                    card.costRecruits = 1;
                    card.enemyDamage = 2;
                    card.playAgain = true;
                    break; }
                case 36: {
                    card.costRecruits = 1;
                    card.enemyDamage = 4;
                    card.myGems = -3;
                    break; }
                case 37: {
                    card.costRecruits = 3;
                    card.myDungeon = 1;
                    break; }
                case 38: {
                    card.costRecruits = 2;
                    card.playAgain = true;
                    card.discardAfter = true;
                    break; }
                case 39: {
                    card.costRecruits = 3;
                    card.enemyDamage = 6;
                    card.myDamage = 3;
                    break; }
                case 40: {
                    card.costRecruits = 4;
                    card.enemyTowerHealth = -3;
                    card.myDamage = 1;
                    break; }
                case 41: {
                    card.costRecruits = 6;
                    card.enemyTowerHealth = -2;
                    card.playAgain = true;
                    break; }
                case 42: {
                    card.costRecruits = 3;
                    card.enemyDamage = 5;
                    break; }
                case 43: {
                    card.enemyDamage = 4;
                    card.myWallHealth = 3;
                    break; }
                case 44: {
                    card.costRecruits = 6;
                    card.enemyTowerHealth = -4;
                    break; }
                case 45: {
                    card.costRecruits = 7;
                    card.myDungeon = 2;
                    break; }
                case 46: {
                    card.costRecruits = 8;
                    card.enemyDamage = 2;
                    card.myWallHealth = 4;
                    card.myTowerHealth = 2;
                    break; }
                case 47: {
                    card.myDungeon = 1;
                    card.enemyDungeon = 1;
                    card.myRecruits = 3;
                    break; }
                case 48: {
                    card.costRecruits = 5;
                    card.enemyDamage = 6;
                    break; }
                case 49: {
                    card.costRecruits = 6;
                    card.enemyDamage = 7;
                    break; }
                case 50: {
                    card.costRecruits = 6;
                    card.enemyDamage = 6;
                    card.enemyRecruits = -3;
                    break; }
                case 51: {
                    card.costRecruits = 5;
                    card.enemyDamage = 6;
                    card.myDamage = 6;
                    card.myBricks = -5;
                    card.enemyBricks = -5;
                    card.myGems = -5;
                    card.enemyGems = -5;
                    card.myRecruits = -5;
                    card.enemyRecruits = -5;
                    break; }
                case 52: {
                    card.costRecruits = 8;
                    card.triggerNumber = 5; //If enemy wall = 0 then 10 damage else 6 damage
                    break; }
                case 53: {
                    card.costRecruits = 9;
                    card.enemyDamage = 9;
                    break; }
                case 54: {
                    card.costRecruits = 11;
                    card.triggerNumber = 6; //If enemy wall > 0 then 10 damage else 7 damage
                    break; }
                case 55: {
                    card.costRecruits = 9;
                    card.triggerNumber = 7; // If myMagic > enemyMagic then 12 damage else 8 damage
                    break; }
                case 56: {
                    card.costRecruits = 10;
                    card.triggerNumber = 8; // If myWall > enemyWall then enemyTower -6 else enemyDamage 6 
                    break; }
                case 57: {
                    card.costRecruits = 14;
                    card.enemyTowerHealth = -5;
                    card.enemyRecruits = -8;
                    break; }
                case 58: {
                    card.costRecruits = 11;
                    card.enemyDamage = 8;
                    card.enemyQuarry = -1;
                    break; }
                case 59: {
                    card.costRecruits = 12;
                    card.enemyBricks = -5;
                    card.myBricks = 3;
                    card.enemyGems = -10;
                    card.myGems = 5;
                    break; }
                case 60: {
                    card.costRecruits = 15;
                    card.enemyDamage = 10;
                    card.myWallHealth = 4;
                    break; }
                case 61: {
                    card.costRecruits = 17;
                    card.enemyDamage = 10;
                    card.enemyRecruits = -5;
                    card.enemyDungeon = -1;
                    break; }
                case 62: {
                    card.costRecruits = 25;
                    card.enemyDamage = 20;
                    card.enemyGems = -10;
                    card.enemyDungeon = -1;
                    break; }
                case 63: {
                    card.costRecruits = 2;
                    card.triggerNumber = 9; // If myWall > enemyWall then 3 damage else 2 damage
                    break; }
                case 64: {
                    card.costRecruits = 2;
                    card.enemyDamage = 3;
                    card.myGems = 1;
                    break; }
                case 65: {
                    card.costRecruits = 4;
                    card.enemyDamage = 8;
                    card.myTowerHealth = -3;
                    break; }
                case 66: {
                    card.costRecruits = 13;
                    card.enemyDamage = 13;
                    card.myGems = -3;
                    break; }
                case 67: {
                    card.costRecruits = 18;
                    card.enemyTowerHealth = -12;
                    break; }
                    // Red cards
                case 68: {
                    card.myBricks = -8;
                    card.enemyBricks = -8;
                    break; }
                case 69: {
                    card.myBricks = +2;
                    card.myGems = +2;
                    card.playAgain = true;
                    break; }
                case 70: {
                    card.costBricks = 1;
                    card.myWallHealth = 1;
                    card.playAgain = true;
                    break; }
                case 71: {
                    card.costBricks = 3;
                    card.myQuarry = 1;
                    break; }
                case 72: {
                    card.costBricks = 4;
                    card.triggerNumber = 10; // if myQuarry < enemyQuarry then myQuarry +2 else +1
                    break; }
                case 73: {
                    card.costBricks = 7;
                    card.myWallHealth = 4;
                    card.myQuarry = 1;
                    break; }
                case 74: {
                    card.costBricks = 2;
                    card.myWallHealth = 5;
                    card.myGems = -6;
                    break; }
                case 75: {
                    card.costBricks = 5;
                    card.triggerNumber = 11; // if myQuarry < enemyQuarry then myQuarry = enemyQuarry
                    break; }
                case 76: {
                    card.costBricks = 2;
                    card.myWallHealth = 3;
                    break; }
                case 77: {
                    card.costBricks = 3;
                    card.myWallHealth = 4;
                    break; }
                case 78: {
                    card.costBricks = 2;
                    card.myQuarry = 1;
                    card.enemyQuarry = 1;
                    card.myGems = 4;
                    break; }
                case 79: {
                    card.costBricks = 3;
                    card.triggerNumber = 12; // if my wall = 0 then +6 wall else +3 wall
                    break; }
                case 80: {
                    card.costBricks = 7;
                    card.myWallHealth = -5;
                    card.enemyWallHealth = -5;
                    card.playAgain = true;
                    break; }
                case 81: {
                    card.costBricks = 8;
                    card.myMagic = 1;
                    card.playAgain = true;
                    break; }
                case 82: {
                    card.myQuarry = -1;
                    card.enemyQuarry = -1;
                    break; }
                case 83: {
                    card.costBricks = 5;
                    card.myWallHealth = 6;
                    break; }
                case 84: {
                    card.costBricks = 4;
                    card.enemyQuarry = -1;
                    break; }
                case 85: {
                    card.costBricks = 6;
                    card.myQuarry = 2;
                    break; }
                case 86: {
                    card.myQuarry = -1;
                    card.myWallHealth = 10;
                    card.myGems = 5;
                    break; }
                case 87: {
                    card.costBricks = 8;
                    card.myWallHealth = 8;
                    break; }
                case 88: {
                    card.costBricks = 9;
                    card.myWallHealth = 5;
                    card.myDungeon = 1;
                    break; }
                case 89: {
                    card.costBricks = 9;
                    card.myWallHealth = 7;
                    card.myGems = 7;
                    break; }
                case 90: {
                    card.costBricks = 11;
                    card.myWallHealth = 6;
                    card.myTowerHealth = 3;
                    break; }
                case 91: {
                    card.costBricks = 13;
                    card.myWallHealth = 12;
                    break; }
                case 92: {
                    card.costBricks = 15;
                    card.myWallHealth = 8;
                    card.myTowerHealth = 5;                    
                    break; }
                case 93: {
                    card.costBricks = 16;
                    card.myWallHealth = 15;
                    break; }
                case 94: {
                    card.costBricks = 18;
                    card.myWallHealth = 6;
                    card.enemyDamage = 10;
                    break; }
                case 95: {
                    card.costBricks = 24;
                    card.myWallHealth = 20;
                    card.myTowerHealth = 8;
                    break; }
                case 96: {
                    card.costBricks = 7;
                    card.myWallHealth = 9;
                    card.myRecruits = -5;
                    break; }
                case 97: {
                    card.costBricks = 1;
                    card.myWallHealth = 1;
                    card.myTowerHealth = 1;
                    card.myRecruits = 2;
                    break; }
                case 98: {
                    card.costBricks = 6;
                    card.triggerNumber = 13; // if myWall < enemyWall then myDungeon -1 mytTower-2 else enemy...
                    break; }
                case 99: {
                    card.costBricks = 10;
                    card.myRecruits = 6;
                    card.myWallHealth = 6;
                    card.triggerNumber = 14; // if myDungeon < enemyDungeon then myDungeon +1
                    break; }
                case 100: {
                    card.costBricks = 14;
                    card.myWallHealth = 7;
                    card.enemyDamage = 6;
                    break; }
                case 101: {
                    card.costBricks = 17;
                    card.triggerNumber = 15; // swap walls
                    break; }                    
                default:
                    break;
            }            
            return card;
        }
    }
}
