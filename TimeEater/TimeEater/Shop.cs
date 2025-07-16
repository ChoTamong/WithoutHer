namespace TimeEater
{
    public class Shop
    { 
        public static List<Item> ShopItems = new List<Item>()
        {
            new Item("DIY 블레이드", "칫솔 이었던 것", 0, 15, 1500),
            new Item("잡지 뭉치", "칼은 맞을 수 있을지도?.", 1, 5, 3500),
            new Item("총", "교도관 몰래 훔쳐 온 총.", 0, 99, 10000),
            new Item("몽둥이", "교도관이 사용하는 몽둥이.", 0, 20, 2000),
        };

        public void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("[상점]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{Player.Gold}G\n");
            Console.WriteLine("[아이템 목록]\n");

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");
        }
        public void BuyItem()
        {
            Console.Clear();
        }
    }
}
