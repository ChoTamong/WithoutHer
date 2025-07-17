using System.Threading;

namespace TimeEater
{
    public enum MonsterDisplayMode
    {
        Normal,
        Attack
    }

    public class Battle
    {
        public int actNumber; // 행동번호

        public List<Monster> randomMonsterList = new List<Monster>();
        public int monsterCount; // 랜덤 몬스터 수 
        public int randomIndex; // 랜덤 인덱스 

        public DataManager dataManager = DataManager.Instance;

        public string monsterNumber; // 몬스터 레벨 앞에 붙는 문자(숫자나 빈문자열이 될 수 있음)

        public bool isAttackMode;
        public MonsterDisplayMode monsterDisplayMode = MonsterDisplayMode.Normal;

        public void EnterDungeon()
        {
            Console.Clear();
            Console.WriteLine("던전에 입장하시겠습니까?");
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 아니오");
            actNumber = Utility.readNum(1, 2);

            switch (actNumber)
            {
                case 1:
                    EnterBattle();
                    break;
                case 2:
                    // 이전 씬으로 돌아가기 
                    break;
            }
        }

        public void EnterBattle()
        {
            Console.Clear();
            
            GenerateRandomMonsters(); // 몬스터 랜덤 생성 

            PrintRandomMonsters(monsterDisplayMode); // 랜덤 몬스터 출력

            PrintPlayerInfo(); // 내정보 출력

            SetBattleActNumber(); // 원하는 행동 입력 
        }

        public void GenerateRandomMonsters()
        {
            monsterCount = Utility.returnRandomNum(1, 5); // 1 ~ 4 사이 랜덤 숫자로 몬스터 개수를 설정

            for(int i = 0; i < monsterCount; i++)
            {
                randomIndex = Utility.returnRandomNum(0, 4); // 0 ~ 4 사이 인덱스 
                randomMonsterList.Add(dataManager.monsterList[randomIndex]); // 랜덤 몬스터 리스트에 랜덤 몬스터 추가
            }
        }

        public void PrintRandomMonsters(MonsterDisplayMode displayMode)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n");

            for(int i = 0; i < randomMonsterList.Count; i++)
            {
                monsterNumber = displayMode == MonsterDisplayMode.Attack ? (i + 1).ToString() : "";

                // 죽은 몬스터
                if (randomMonsterList[i].isDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray; // 죽은 몬스터 색상을 어둡게 설정 
                    Console.WriteLine($"{monsterNumber}Lv.{randomMonsterList[i].level} {randomMonsterList[i].name} Dead");
                }
                else
                {
                    //Console.ResetColor();
                    Console.WriteLine($"{monsterNumber} Lv.{randomMonsterList[i].level} {randomMonsterList[i].name} HP {randomMonsterList[i].maxHp}");
                }

                Console.ResetColor(); // 다음 콘솔 출력 때 어두운 색상이 나오지 않게 다시 리셋 
            }
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine("\n[내정보]");
            //dataManager.player.PrintInfo();

            if(monsterDisplayMode == MonsterDisplayMode.Attack)
                Console.WriteLine("\n0. 취소");
            else
                Console.WriteLine("\n1. 공격\n");
        }

        public void SetBattleActNumber()
        {
            Console.WriteLine("원하시는 행동을 입력해주세요."); // 1. 공격 (나머지는 아직 없음)
            Console.Write(">> ");
            actNumber = Utility.readNum(1, 1);

            switch (actNumber)
            {
                // 공격 
                case 1: 
                    monsterDisplayMode = MonsterDisplayMode.Attack;
                    PrintRandomMonsters(monsterDisplayMode);
                    PrintPlayerInfo();
                    SetTarget();
                    //AttackMonster(warrior, _targetMonster);
                    break;
            }
        }

        public void SetTarget()
        {

        }

        public void PlayerTurn()
        {
            Console.Clear();
        }

        public void EnemyTurn()
        {
            Console.Clear();
        }
    }
}
