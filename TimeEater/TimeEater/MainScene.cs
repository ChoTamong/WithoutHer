using System.Security.Cryptography.X509Certificates;

namespace TimeEater
{
    internal class MainScene
    {
        // 1. 함수 만들 때 "파스칼"로;
        // 2. 변수 만들 때 "카멜"로;
        // 3. 변수의 접근제한자 "public" 만
        static void Main(string[] args)
        {
            MainMenu game = new MainMenu();
            game.Run();
        }
    }

    // 기본 씬 클래스:
    public class MainMenu
    {
        public void Run()
        {
            EnterNameAndJob();
            while (true)
            {
                ShowMenu();
            }
        }

        public void EnterNameAndJob()
        {
            Console.Clear();
        }
        public void ShowMenu()
        {
            Console.Clear();
        }
    }

    public class Player
    {
        public void PlayerStatus()
        {
            Console.Clear();
        }
    }
    public class Inventory
    {
        public void ShowInventory()
        {
            Console.Clear();
        }
        public void EquipItem()
        {
            Console.Clear();
        }
    }
    public class Shop
    { 
        public void ShowShop()
        {
            Console.Clear();
        }
        public void BuyItem()
        {
            Console.Clear();
        }
    }
    public class Battle
    {
        public void EnterDungeon()
        { }
        public void EnterBattle()
        { }
        public void PlayerTurn()
        { }
        public void EnemyTurn()
        { }
    }

    //테이터 클래스:
    public class Item
    { }
    public class Monster
    { }
    public class PlayerInfo 
    { }
    public class GameManager
    { }

}
