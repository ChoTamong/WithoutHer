namespace TimeEater
{
    public class DataManager : Singleton<DataManager>
    {
        // Monster
        public List<MonsterData> monsterList = new List<MonsterData>()
        {
            new MonsterData("신입교도관", 2, 1, 15, 5, 0),
            new MonsterData("선임교도관", 3, 2, 20, 7, 0),
            new MonsterData("교도부사관", 4, 3, 30, 10, 0),
            new MonsterData("교도관리소장", 5, 4, 50, 15, 0)
        };

        // Shop
        public List<Item> shopItems = new List<Item>()
        {
            new Item("DIY 블레이드", "칫솔 이었던 것", 0, 8, 1500),
            new Item("잡지 뭉치", "칼은 맞을 수 있을지도?", 1, 5, 2000),
            new Item("총", "교도관 몰래 훔쳐 온 총.", 0, 99, 10000),
            new Item("몽둥이", "교도관이 버린 몽둥이.", 0, 20, 3500)
        };
        public List<Item> recoveryItem = new List<Item>()
        {
            new Item("담배", "체력을 회복하는 아이템", 2, 50, 500),
            new Item("각성제", "마나를 회복하는 아이템", 3, 30, 300)
        };

        // Inventory
        public List<Item> boughtItemToInventory = new List<Item>()
        {
            new Item("종이 복대", "신문지 뭉치로 만든 복대", 0, 5, 1500),
            new Item("낡은 송곳", "작업실에서 가져온 송곳", 1, 5, 1500)
        };
        public List<Item> boughtRecoverItemToInventory = new List<Item>()
        {
            new Item("물", "목마를 때 마시는 물", 2, 5, 500)
        };

        // Player
        public Player player;
    }

}
