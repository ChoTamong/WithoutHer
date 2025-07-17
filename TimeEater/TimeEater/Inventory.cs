namespace TimeEater
{
    public class Inventory
    {
        public static List<Item> BoughtItemToInventory = new List<Item>();
        public static List<Item> EquippedItem = new List<Item>();
        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("[인벤토리]\n");
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
                    return;
            }

        }
        public void EquipItem()
        {
            Console.Clear();
            Console.WriteLine("[장착관리]");
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
                        { /*-= selectedItem.Power*/ }
                        else 
                        { /*-= selectedItem.Power*/ }
                    }
                    else
                    {
                        EquippedItem.Add(selectedItem);
                        if (selectedItem.type == 0)
                        { /*+= selectedItem.Power*/ }
                        else
                        { /*+= selectedItem.Power*/ }
                    }
                    EquipItem();
                    break;
            }
        }
    }
}
