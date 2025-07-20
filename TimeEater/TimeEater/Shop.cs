using System.Diagnostics.Contracts;
using System.Linq;

namespace TimeEater
{
    public class Shop
    {
        public DataManager dataManager;
        public List<Item> recoveryItem;
        public List<Item> boughtRecoverItemToInventory;
        public List<Item> shopItems;
        public List<Item> boughtItemToInventory;

        public UI ui;

        public void FirstItemShop()
        {
            InitShop();

            Console.Clear();
            Console.WriteLine("[밀거래상]:");
            ui.shopScene(); // 상인 이미지;
            Console.WriteLine("어이.. 친구 뭐가 필요하지...?\n");
            Console.WriteLine("1. 장착 아이템");
            Console.WriteLine("2. 회복 아이템\n");
            Console.WriteLine("0. 나가기");
            Console.Write("\n(원하는 행동을 입력하세요.)\n>>> ");

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

        public void InitShop()
        {
            dataManager = DataManager.Instance;
            recoveryItem = dataManager.recoveryItem;
            boughtRecoverItemToInventory = dataManager.boughtRecoverItemToInventory;
            shopItems = dataManager.shopItems;
            boughtItemToInventory = dataManager.boughtItemToInventory;

            ui = UI.Instance;
        }
        
        public void ShowRecoveryItem()
        {
            Console.Clear();
            Console.WriteLine("[밀거래상]:");
            ui.shopScene(); // 상인 이미지;
            Console.WriteLine("[회복 아이템]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in recoveryItem)
            {
                string displayPrice = boughtRecoverItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
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
            Console.WriteLine("[밀거래상]:");
            ui.shopScene(); // 상인 이미지;
            Console.WriteLine("[회복 아이템 구매]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in recoveryItem)
            {
                int selectedIndex = recoveryItem.IndexOf(displayItem) + 1;
                string displayPrice = boughtRecoverItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
                Console.WriteLine($"- {selectedIndex} {displayItem.name} | {(displayItem.type == 2 ? "HP" : "MP")} + {displayItem.power} | {displayItem.description} | {displayPrice}");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");
            int inputNum = Utility.readNum(0, recoveryItem.Count);
            switch (inputNum)
            {
                default:
                    int targetItem = inputNum - 1;
                    var boughtItem = recoveryItem[targetItem];
                    if (boughtRecoverItemToInventory.Contains(boughtItem))
                    {
                        Console.WriteLine("이런 벌써 산 물건이야...");
                    }
                    else 
                    {
                        if (DataManager.Instance.player.gold >= boughtItem.price)
                        {
                            Console.WriteLine("아주 좋은 선택이야... ㅎㅎㅎ");
                            DataManager.Instance.player.gold -= boughtItem.price;
                            boughtRecoverItemToInventory.Add(boughtItem);
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
            Console.WriteLine("[밀거래상]:");
            ui.shopScene(); // 상인 이미지;
            Console.WriteLine("[장착아이템]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in shopItems)
            {
                string displayPrice = boughtItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
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
            Console.WriteLine("[밀거래상]:");
            ui.shopScene(); // 상인 이미지;
            Console.WriteLine("[아이템 구매]\n");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{DataManager.Instance.player.gold}G\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in shopItems)
            {
                int selectedIndex = shopItems.IndexOf(displayItem) + 1;
                string displayPrice = boughtItemToInventory.Contains(displayItem) ? "구매완료" : $"{displayItem.price}G";
                Console.WriteLine($"- {selectedIndex} {displayItem.name} | {(displayItem.type == 0 ? "공격력" : "방어력")} + {displayItem.power} | {displayItem.description} | {displayPrice}");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");

            int inputNum = Utility.readNum(0, shopItems.Count);

            switch (inputNum)
            {
                default:
                    int targetItem = inputNum - 1;
                    var boughtItem = shopItems[targetItem];

                    if (boughtItemToInventory.Contains(boughtItem))
                    {
                        Console.WriteLine("이런 벌써 산 물건이야...");
                    }
                    else 
                    {
                        
                        if (DataManager.Instance.player.gold >= boughtItem.price)
                        {
                            Console.WriteLine("아주 좋은 선택이야... ㅎㅎㅎ");
                            DataManager.Instance.player.gold -= boughtItem.price;
                            boughtItemToInventory.Add(boughtItem);
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
