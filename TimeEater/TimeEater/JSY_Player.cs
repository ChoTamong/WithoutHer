namespace TimeEater
{
    public class JSY_Player
    {
        public string name;
        public string job;

        public int level = 1;
        public int hp = 100;
        public int attack = 10;
        public int defence = 5;
        public int gold = 1500;

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

        // 상태 출력
        public void PlayerStatus()
        {
            Console.WriteLine("=== PLAYER STATUS ===");
            Console.WriteLine($"이름     : {name}");
            Console.WriteLine($"직업     : {job}");
            Console.WriteLine($"레벨     : {level}");
            Console.WriteLine($"HP       : {hp}");
            Console.WriteLine($"공격력   : {attack}");
            Console.WriteLine($"방어력   : {defence}");
            Console.WriteLine($"Gold     : {gold}");
            Console.WriteLine("======================");
        }
    }
}
