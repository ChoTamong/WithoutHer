namespace TimeEater
{
    public class Player
    {
        public string name;
        public string job;
        public int level = 1;
        public int hp = 100;
        public int attack = 10;
        public int defence = 5;
        public int gold = 1500;

        public int extarAck;
        public int extarDef;

        public Player(string name, int job)
        {
            SetName(name);
            SetJob(job);
            //this.level = 1;
            //this.hp = 100;
            //this.attack = 10;
            //this.defence = 5;
            //this.gold = 1500;
        }

        // 이름 설정
        public void SetName(string name)
        {
            this.name = name;
        }

        // 직업 설정
        public void SetJob(int jobCode)
        {
            switch (jobCode)
            {
                case 1:
                    job = "전사";                    
                    break;
                case 2:
                    job = "마법사";
                    break;
                case 3:
                    job = "궁수";
                    break;
                case 4:
                    job = "도적";
                    break;
                default:
                    job = "";
                    break;
            }
        }

        //public int GetTotalAttack() =>
        //    baseAttack + Inventory.EquippedItem.Where(i => i.Type == 0).Sum(i => i.Power);

        //public int GetTotalDefence() =>
        //    baseDefence + Inventory.EquippedItem.Where(i => i.Type == 1).Sum(i => i.Power);

        public void PlayerStatus(PlayerStatusDisplayMode mode)
        {
            if(mode == PlayerStatusDisplayMode.Normal)
                Console.Clear();

            Console.WriteLine("=== PLAYER STATUS ===");
            Console.WriteLine($"이름     : {name}");
            Console.WriteLine($"직업     : {job}");
            Console.WriteLine($"레벨     : {level}");
            Console.WriteLine($"HP       : {hp}");
            Console.WriteLine(extarAck == 0 ? $"공격력   : {attack}" : $"공격력   : {attack + extarAck} + ({extarAck})");
            Console.WriteLine(extarDef == 0 ? $"방어력   : {defence}" : $"방어력   : {defence + extarDef} + ({extarDef})");
            Console.WriteLine($"Gold     : {gold}");
            Console.WriteLine("======================");

            if(mode == PlayerStatusDisplayMode.Normal)
            {
                Console.WriteLine("\n아무 키나 누르면 돌아갑니다.");
                Console.ReadKey();
            }
        }
    }
}