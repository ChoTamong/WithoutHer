using System.Reflection.Metadata;

namespace TimeEater
{
    public class Inventory
    {
        public static List<Item> BoughtItemToInventory = new List<Item>() 
        {
            new Item("종이 복대", "신문지 뭉치로 만든 복대", 0, 5, 1500),
            new Item("낡은 송곳", "작업실에서 가져온 송곳", 1, 5, 1500)
        };
        public static List<Item> BoughtRecoverItemToInventory = new List<Item>()
        {
            new Item("물", "목마를 때 마시는 물", 2, 5, 500)
        };

        public static List<Item> EquippedItem = new List<Item>();
        //public static List<Item> UseAndDeletItem = new List<Item>();

        public void FirstShowInventory()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[인벤토리]");
            UI.Instance.Inventoryline();
            Console.WriteLine("1. 장착 아이템");
            Console.WriteLine("2. 사용 아이템\n");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");
            
            int inputNum = Utility.readNum(0, 2);

            switch (inputNum)
            {
                case 1:
                    ShowInventory();
                    break;
                case 2:
                    ShowRecoveryItem();
                    break;
                case 0:
                    return;
            }
        }

        public void ShowRecoveryItem()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[사용 아이템]");
            UI.Instance.Inventoryline();
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in BoughtRecoverItemToInventory)
            {
                Console.WriteLine($"- {displayItem.name} | {(displayItem.type == 2 ? "HP" : "MP")} + {displayItem.power} | {displayItem.description} ");
            }
            Console.WriteLine("\n1. 아이템 사용");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");
            int inputNum = Utility.readNum(0, 1);
            switch (inputNum)
            {
                case 0:
                    FirstShowInventory();
                    break;
                case 1:
                    UseItem();
                    break;
            }
        }
        public void UseItem()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[사용 아이템]");
            UI.Instance.Inventoryline();
            Console.WriteLine("[아이템 목록]\n");
            foreach (var displayItem in BoughtRecoverItemToInventory)
            {
                int selectedIndex = BoughtRecoverItemToInventory.IndexOf(displayItem) + 1;
                Console.WriteLine($"- {selectedIndex} {displayItem.name} | {(displayItem.type == 2 ? "HP" : "MP")} + {displayItem.power} | {displayItem.description} ");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");

            int inputNum = Utility.readNum(0, BoughtRecoverItemToInventory.Count);
            
            switch (inputNum)
            {
                case 0:
                    return;
                default:
                    int targetItem = inputNum - 1;
                    var selectedItem = BoughtRecoverItemToInventory[targetItem];
                    bool isEquipped = BoughtRecoverItemToInventory.Contains(selectedItem);

                    if (isEquipped)
                    {
                        BoughtRecoverItemToInventory.Remove(selectedItem);
                        if (selectedItem.type == 2)
                        { 
                            DataManager.Instance.player.nowHp += selectedItem.power;
                            if (DataManager.Instance.player.nowHp > DataManager.Instance.player.hp)
                            {
                                DataManager.Instance.player.nowHp = DataManager.Instance.player.hp;
                            }
                        }
                        else
                        { 
                            DataManager.Instance.player.nowMp += selectedItem.power;
                            if (DataManager.Instance.player.nowMp > DataManager.Instance.player.mp)
                            {
                                DataManager.Instance.player.nowMp = DataManager.Instance.player.mp;
                            }
                        }
                    }
                    UseItem();
                    break;
            }
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[장착 아이템]");
            UI.Instance.Inventoryline();
            Console.WriteLine("[아이템 목록]\n");
            foreach (var getIem in BoughtItemToInventory)
            {
                string displayEquipped = EquippedItem.Contains(getIem) ? "[E]" : "";
                Console.WriteLine($"- {displayEquipped} {getIem.name} | {(getIem.type == 0 ? "공격력" : "방어력")} + {getIem.power} | {getIem.description} ");
            }
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");

            int inputNum = Utility.readNum(0, 1);
            switch (inputNum)
            {
                case 1:
                    EquipItem();
                    break;
                case 0:
                    FirstShowInventory();
                    break;
            }

        }
        public void EquipItem()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[장착 아이템]");
            UI.Instance.Inventoryline();
            Console.WriteLine("[아이템 목록]\n");
            foreach (var getIem in BoughtItemToInventory)
            {
                int selectedIndex = BoughtItemToInventory.IndexOf(getIem) + 1;
                string displayEquipped = EquippedItem.Contains(getIem) ? "[E]" : "";
                Console.WriteLine($"- {selectedIndex} {displayEquipped} {getIem.name} | {(getIem.type == 0 ? "공격력" : "방어력")} + {getIem.power} | {getIem.description} ");
            }
            Console.WriteLine("\n0. 나가기");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");

            int inputNum = Utility.readNum(0, BoughtItemToInventory.Count);
            switch (inputNum)
            {
                case 0:
                    return;
                default:
                    int targetItem = inputNum - 1;
                    var selectedItem = BoughtItemToInventory[targetItem];
                    bool isEquipped = EquippedItem.Contains(selectedItem);

                    if (isEquipped)
                    {
                        EquippedItem.Remove(selectedItem);
                        if (selectedItem.type == 0)
                        { DataManager.Instance.player.extarAck -= selectedItem.power; }
                        else 
                        { DataManager.Instance.player.extarDef -= selectedItem.power; }
                    }
                    else
                    {
                        EquippedItem.Add(selectedItem);
                        if (selectedItem.type == 0)
                        { DataManager.Instance.player.extarAck += selectedItem.power; }
                        else
                        { DataManager.Instance.player.extarDef += selectedItem.power; }
                    }
                    EquipItem();
                    break;
            }
        }
    }
}
