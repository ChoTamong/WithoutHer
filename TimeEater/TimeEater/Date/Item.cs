namespace TimeEater
{
    //테이터 클래스:
    public class Item
    {
        // Name, Type, Power, Price, Description 기본 요소

        public string name;
        public string description;
        public int type;
        public int power;
        public int price;

        public Item(string name, string description, int type, int power, int price)
        {
            this.name = name; // 아이템 이름
            this.description = description; // 아이템 설명
            this.type = type; // 0: 무기, 1: 방어구 2: 물약
            this.power = power; // 공격력, 방어력
            this.price = price; // 가격
        }
    }
}
