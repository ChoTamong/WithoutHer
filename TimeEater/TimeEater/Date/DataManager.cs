namespace TimeEater
{
    public class DataManager
    {
        private static DataManager _instance;
        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }


        // 데이터 리스트 관리

        //public static List<Item> baseItemAttribute = new List<Item>()
        //{
        //    new Item ("투구", "그냥 투구", 1, 5, 1500),
        //    new Item ("갑옷", "그냥 갑옷", 1, 10, 2500),
        //    new Item ("방패", "그냥 방패", 1, 7, 2000),
        //    new Item ("검", "그냥 검", 0, 10, 1000),
        //    new Item ("창", "그냥 창", 0, 15, 2000),
        //    new Item ("도끼", "그냥 도끼", 0, 20, 3000),
        //    new Item ("회복약", "체력을 회복하는 아이템", 2, 50, 500),
        //    new Item ("마나약", "마나를 회복하는 아이템", 2, 30, 300)
        //};

        public List<MonsterData> monsterList = new List<MonsterData>()
        {
            // string name, int level, int type, int maxHp, int attack, int defense
            new MonsterData("째깍이", 2, 1, 15, 5, 0),
            new MonsterData("끄적이", 3, 2, 10, 4, 0),
            new MonsterData("깜짝이", 4, 3, 25, 8, 0),
            new MonsterData("실라", 5, 4, 50, 10, 15)
        };

        public Player player;

        // 가져가는 기능 (메서드), 가져갈 것들이 많다면 일부만 가져야 하면 만드는게 좋음. 
    }

}
