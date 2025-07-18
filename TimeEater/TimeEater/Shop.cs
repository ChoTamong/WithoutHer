using System.Diagnostics.Contracts;
using System.Linq;

namespace TimeEater
{
    public class Shop
    {
        public static List<Item> ShopItems = new List<Item>()
        {
            new Item("DIY 블레이드", "칫솔 이었던 것", 0, 8, 1500),
            new Item("잡지 뭉치", "칼은 맞을 수 있을지도?", 1, 5, 2000),
            new Item("총", "교도관 몰래 훔쳐 온 총.", 0, 99, 10000),
            new Item("몽둥이", "교도관이 버린 몽둥이.", 0, 20, 3500)
        };

        public static List<Item> RecoveryItem = new List<Item>() 
        {
            new Item("담배", "체력을 회복하는 아이템", 2, 50, 500),
            new Item("각성제", "마나를 회복하는 아이템", 3, 30, 300)
        };

        public void FirstItemShop()
        {
            Console.Clear();
            Console.WriteLine("[상점]\n");
            Console.WriteLine("어이.. 친구 뭐가 필요하지...?\n");
            Console.WriteLine("1. 장착 아이템");
            Console.WriteLine("2. 회복 아이템\n");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하는 행동을 입력하세요.\n>>> ");

            int inputNum = Utility.readNum(0, 2);

            switch (inputNum)
            {
                case 1:
                    ShowShop();
                    break;
                case 2:
                    ShowRecoveryItem();
                    break;
                case 0:
                    Console.WriteLine("다음에 또 오라고 ㅎㅎㅎ....");
                    Console.ReadKey();
                    return;
            }
        }

        public void ShowRecoveryItem()
        {
            Console.Clear();
            Console.WriteLine("[회복 아이템]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in RecoveryItem)
            {
                string displayPrice = Inventory.BoughtRecoverItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
                Console.WriteLine($"- {displayItem.name} | {(displayItem.type == 2 ? "HP" : "MP")} + {displayItem.power} | {displayItem.description} | {displayPrice}");
            }
            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");
            
            int inputNum = Utility.readNum(0, 1);
            switch (inputNum)
            {
                case 1:
                    BuyRecoveryItem();
                    break;
                case 0:
                    FirstItemShop();
                    break;
            }
        }

        public void BuyRecoveryItem()
        {
            Console.Clear();
            Console.WriteLine("[회복 아이템 구매]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in RecoveryItem)
            {
                int selectedIndex = RecoveryItem.IndexOf(displayItem) + 1;
                string displayPrice = Inventory.BoughtRecoverItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
                Console.WriteLine($"- {selectedIndex} {displayItem.name} | {(displayItem.type == 2 ? "HP" : "MP")} + {displayItem.power} | {displayItem.description} | {displayPrice}");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");
            int inputNum = Utility.readNum(0, RecoveryItem.Count);
            switch (inputNum)
            {
                default:
                    int targetItem = inputNum - 1;
                    var boughtItem = RecoveryItem[targetItem];
                    if (Inventory.BoughtRecoverItemToInventory.Contains(boughtItem))
                    {
                        Console.WriteLine("이런 벌써 산 물건이야...");
                    }
                    else 
                    {
                        if (DataManager.Instance.player.gold >= boughtItem.price)
                        {
                            Console.WriteLine("아주 좋은 선택이야... ㅎㅎㅎ");
                            DataManager.Instance.player.gold -= boughtItem.price;
                            Inventory.BoughtRecoverItemToInventory.Add(boughtItem);
                        }
                        else
                        {
                            Console.WriteLine("돈이 필요하다구 친구....ㅎㅎㅎ");                                                                                                
                        }
                    }
                    Console.WriteLine("\n(계속하려면 아무 키나 누르세요...)");
                    Console.ReadKey();
                    BuyRecoveryItem();
                    break;
                case 0:
                    Console.WriteLine("다음에 또 오라고 ㅎㅎㅎ....");
                    Console.ReadKey();
                    FirstItemShop();
                    break;
            }
        }

        public void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("[장착아이템]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in ShopItems)
            {
                string displayPrice = Inventory.BoughtItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
                Console.WriteLine($"- {displayItem.name} | {(displayItem.type == 0 ? "공격력" : "방어력")} + {displayItem.power} | {displayItem.description} | {displayPrice}");
            }
            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");
            
            int inputNum = Utility.readNum(0, 1);

            switch (inputNum)
            {
                case 1:
                    BuyItem();
                    break;
                case 0:
                    FirstItemShop();
                    break;
            }
        }
        public void BuyItem()
        {
            Console.Clear();
            Console.WriteLine("[아이템 구매]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in ShopItems)
            {
                int selectedIndex = ShopItems.IndexOf(displayItem) + 1;
                string displayPrice = Inventory.BoughtItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
                Console.WriteLine($"- {selectedIndex} {displayItem.name} | {(displayItem.type == 0 ? "공격력" : "방어력")} + {displayItem.power} | {displayItem.description} | {displayPrice}");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");

            int inputNum = Utility.readNum(0, ShopItems.Count);

            switch (inputNum)
            {
                default:
                    int targetItem = inputNum - 1;
                    var boughtItem = ShopItems[targetItem];

                    if (Inventory.BoughtItemToInventory.Contains(boughtItem))
                    {
                        Console.WriteLine("이런 벌써 산 물건이야...");
                    }
                    else 
                    {
                        
                        if (DataManager.Instance.player.gold >= boughtItem.price)
                        {
                            Console.WriteLine("아주 좋은 선택이야... ㅎㅎㅎ");
                            DataManager.Instance.player.gold -= boughtItem.price;
                            Inventory.BoughtItemToInventory.Add(boughtItem);
                        }
                        else
                        {
                            Console.WriteLine("돈이 필요하다구 친구....ㅎㅎㅎ");                                                                                                
                        }
                    }
                    Console.WriteLine("\n(계속하려면 아무 키나 누르세요...)");
                    Console.ReadKey();
                    BuyItem();
                    break;
                case 0:
                    Console.WriteLine("다음에 또 오라고 ㅎㅎㅎ....");
                    Console.ReadKey();
                    FirstItemShop();
                    break;
            }
        }
    }
}
