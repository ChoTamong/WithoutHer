namespace TimeEater
{
    public class Player
    {
        public string Name { get; private set; }
        public string Job { get; private set; }

        public int Level { get; private set; } = 1;
        public int Hp { get; private set; } = 100;
        public int Attack { get; private set; } = 10;
        public int Defence { get; private set; } = 5;
        public int Gold { get; private set; } = 1500;

        // 이름 설정
        public void SetName(string name)
        {
            Name = name;
        }

        // 직업 설정
        public void SetJob(int jobCode)
        {
            switch (jobCode)
            {
                case 1:
                    Job = "전사";                    
                    break;
                case 2:
                    Job = "마법사";
                    break;
                case 3:
                    Job = "궁수";
                    break;
                case 4:
                    Job = "도적";
                    break;
                default:
                    Job = "";
                    break;
            }
        }

        // 상태 출력
        public void PlayerStatus()
        {
            Console.Clear();
            Console.WriteLine("=== PLAYER STATUS ===");
            Console.WriteLine($"이름     : {Name}");
            Console.WriteLine($"직업     : {Job}");
            Console.WriteLine($"레벨     : {Level}");
            Console.WriteLine($"HP       : {Hp}");
            Console.WriteLine($"공격력   : {Attack}");
            Console.WriteLine($"방어력   : {Defence}");
            Console.WriteLine($"Gold     : {Gold}");
            Console.WriteLine("======================");

            Console.WriteLine("\n아무 키나 누르면 돌아갑니다...");
            Console.ReadKey(true);
        }
    }
}
