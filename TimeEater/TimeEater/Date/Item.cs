namespace TimeEater
{
    //테이터 클래스:
    public class Item
    {
        // Name, Type, Power, Price, Description 기본 요소

        public string Name;
        public string Description;
        public int Type;
        public int Power;
        public int Price;

        public Item(string name, string description, int type, int power, int price)
        {
            Name = name; // 아이템 이름
            Description = description; // 아이템 설명
            Type = type; // 0: 무기, 1: 방어구
            Power = power; // 공격력, 방어력
            Price = price; // 가격
        }
    }
}
