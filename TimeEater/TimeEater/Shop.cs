using System.Diagnostics.Contracts;
using System.Linq;

namespace TimeEater
{
    public class Shop
    {
        int price = 12000;// 나중에 바꿔야 한다.
        public static List<Item> ShopItems = new List<Item>()
        {
            new Item("DIY 블레이드", "칫솔 이었던 것", 0, 15, 1500),
            new Item("잡지 뭉치", "칼은 맞을 수 있을지도?", 1, 5, 3500),
            new Item("총", "교도관 몰래 훔쳐 온 총.", 0, 99, 10000),
            new Item("몽둥이", "교도관이 사용하는 몽둥이.", 0, 20, 2000)
        };

        public void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("[상점]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{price}G\n");// 나중에 바꿔야 한다.
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in ShopItems)
            {
                string displayPrice = Inventory.BoughtItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.Price}G";
                Console.WriteLine($"- {displayItem.Name} | {(displayItem.Type == 0 ? "공격력" : "방어력")} + {displayItem.Power} | {displayItem.Description} | {displayPrice}");
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
                    return;
            }
        }
        public void BuyItem()
        {
            Console.Clear();
            Console.WriteLine("[아이템 구매]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{price}G\n");// 나중에 바꿔야 한다.
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in ShopItems)
            {
                int selectedIndex = ShopItems.IndexOf(displayItem) + 1;
                string displayPrice = Inventory.BoughtItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.Price}G";
                Console.WriteLine($"- {selectedIndex} {displayItem.Name} | {(displayItem.Type == 0 ? "공격력" : "방어력")} + {displayItem.Power} | {displayItem.Description} | {displayPrice}");
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
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else 
                    {
                        
                        if (price >= boughtItem.Price)
                        {
                            Console.WriteLine("아이템을 구매했습니다.");
                            price -= boughtItem.Price;// 나중에 바꿔야 한다.
                            Inventory.BoughtItemToInventory.Add(boughtItem);
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");                                                                                                
                        }
                    }
                    Console.WriteLine("계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();
                    BuyItem();
                    break;
                case 0:
                    return;
            }
        }
    }
}
