namespace TimeEater
{
    public class Inventory
    {
        public static List<int> BoughtItemToInventory = new List<int>();
        public static List<int> EquippedItem = new List<int>();
        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("[인벤토리]\n");
            Console.WriteLine("[아이템 목록]\n");
            // 여기에 아이템 목록을 출력하는 로직을 추가할 수 있습니다.
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
        }
    }
}
