namespace TimeEater
{
    public class Player
    {
        public string name;
        public string job;
        public int level = 1;
        public int hp;
        public int mp;
        public int nowHp;
        public int nowMp;
        public int attack;
        public int defence;
        public int gold = 5000;

        public int extarAck;
        public int extarDef;

        private Job jobObject; // 새로 추가된 필드

        public Player(string name, int job)
        {
            SetName(name);
            SetJob(job);
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
                    jobObject = new SlightBuild();
                    break;
                case 2:
                    jobObject = new Normal();
                    break;
                case 3:
                    jobObject = new MuscleMan();
                    break;
                default:
                    jobObject = null;
                    break;
            }
            if (jobObject != null)
            {
                job = jobObject.Name;
                hp = jobObject.BaseHP;
                attack = jobObject.BaseAttack;
                defence = jobObject.BaseDefence;
                mp = jobObject.BaseMP;
                nowHp = jobObject.NowHP;
                nowMp = jobObject.NowMP;
            }
        }

        public void UseSkill()
        {
            jobObject?.UseSkill(); // 직업별 스킬 실행
        }

        public void PlayerStatus(PlayerStatusDisplayMode mode)
        {
            if(mode == PlayerStatusDisplayMode.Normal)
                Console.Clear();

            Console.WriteLine("=== PLAYER STATUS ===");
            Console.WriteLine($"이름     : {name}");
            Console.WriteLine($"직업     : {job}");
            Console.WriteLine($"레벨     : {level}");
            Console.WriteLine($"HP       : {nowHp}/{hp}");
            Console.WriteLine($"MP       : {nowMp}/{mp}");
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