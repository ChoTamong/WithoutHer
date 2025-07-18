using System.Numerics;
using System.Threading;
using TimeEater.UI;

namespace TimeEater
{
    public enum MonsterDisplayMode
    {
        Normal,
        Attack
    }

    public enum PlayerStatusDisplayMode
    {
        Normal,
        Info,
    }

    public class Battle
    {
        public int actNumber; // 행동번호
        public int targetNumber; // 타겟 번호

        public List<Monster> randomMonsterList = new List<Monster>();
        public int monsterCount; // 랜덤 몬스터 수 
        public int randomIndex; // 랜덤 인덱스 

        public DataManager dataManager;
        public Player player;

        public string monsterNumber; // 몬스터 레벨 앞에 붙는 문자(숫자나 빈문자열이 될 수 있음)

        public bool isAttackMode;
        public MonsterDisplayMode monsterDisplayMode = MonsterDisplayMode.Normal;

        public Monster targetMonster;

        // 공격 변수 
        public float attackVariance;
        public int min; // 기존 공격력 - 오차
        public int max; // 기존 공격력 + 오차
        public float finalAttack; // 최종 공격력

        public int originHealth;

        // UI
        public JSY_UI ui;

        public void InitPlayer()
        {
            dataManager = DataManager.Instance;
            player = dataManager.player;

            ui = JSY_UI.Instance;
        }

        public void EnterDungeon()
        {
            Console.Clear();
            Console.WriteLine("탈옥하시겠습니까?");
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 아니오");
            actNumber = Utility.readNum(1, 2);

            switch (actNumber)
            {
                case 1:
                    InitPlayer();
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

            DrawPlayer(); // 플레이어 아트 + 대사 
            
            GenerateRandomMonsters(); // 몬스터 랜덤 생성 

            PrintRandomMonsters(monsterDisplayMode); // 랜덤 몬스터 출력

            PrintPlayerInfo(); // 내정보 출력

            SetBattleActNumber(); // 원하는 행동 입력 
        }

        public void DrawPlayer()
        {
            ui.Art1();
            Console.WriteLine("~~~~~");
            Console.ReadKey();
        }

        public void GenerateRandomMonsters()
        {
            dataManager = DataManager.Instance;

            monsterCount = Utility.returnRandomNum(1, 5); // 1 ~ 4 사이 랜덤 숫자로 몬스터 개수를 설정

            for(int i = 0; i < monsterCount; i++)
            {
                randomIndex = Utility.returnRandomNum(0, 4); // 0 ~ 4 사이 인덱스 

                // 같은 인덱스 값 몬스터를 가져오면 똑같은 몬스터라서 똑같이 피가 깎임. 
                MonsterData data = dataManager.monsterList[randomIndex]; // 원본 데이터를 가져와서
                Monster monster = new Monster(data);
                randomMonsterList.Add(monster);
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
                    Console.WriteLine("적 그림");
                    Console.WriteLine($"{monsterNumber}Lv.{randomMonsterList[i].level} {randomMonsterList[i].name} Dead");
                }
                else
                {
                    //Console.ResetColor();
                    Console.WriteLine("적 그림");
                    Console.WriteLine($"{monsterNumber} Lv.{randomMonsterList[i].level} {randomMonsterList[i].name} HP {randomMonsterList[i].maxHp}");
                }

                Console.ResetColor(); // 다음 콘솔 출력 때 어두운 색상이 나오지 않게 다시 리셋 
            }
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine("\n플레이어 그림");
            Console.WriteLine("\n[내정보]");

            player.PlayerStatus(PlayerStatusDisplayMode.Info);

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
                    AttackMonster(player, targetMonster);
                    break;
            }
        }

        public void SetTarget()
        {
            Console.WriteLine("\n대상을 선택해주세요.");
            Console.Write(">> ");
            targetNumber = Utility.readNum(0, randomMonsterList.Count); // 랜덤 몬스터 수만큼 

            // 대상 몬스터들 내에서 선택하면
            if(1 <= targetNumber && targetNumber <= randomMonsterList.Count)
            {
                // 이미 죽은 몬스터를 공격했다면
                if (randomMonsterList[targetNumber - 1].isDead)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    SetTarget();
                }
                else
                {
                    // 타겟 몬스터 설정 
                    targetMonster = randomMonsterList[targetNumber - 1];
                    Console.WriteLine($"타겟 몬스터 : {targetMonster.name}"); // 확인용 
                }
            }
            else
            {
                if (targetNumber == 0)
                {
                    // 배틀로 돌아가기
                    monsterDisplayMode = MonsterDisplayMode.Normal;
                    PrintRandomMonsters(monsterDisplayMode); // 랜덤 몬스터 출력
                    PrintPlayerInfo(); // 내정보 출력
                    SetBattleActNumber(); // 원하는 행동 입력 
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    SetTarget();
                }
            }
        }

        public void AttackMonster(Player player, Monster targetMonster)
        {
            Console.Clear();
            Console.WriteLine("(배틀씬)");
            Console.WriteLine("플레이어, 적 그림");

            // 기존 공격력의 10% 
            attackVariance = (player.attack + player.extarAck) * 0.1f; 

            // 오차가 소수점이면 올림처리
            if (attackVariance % 1 != 0)
                attackVariance = MathF.Ceiling(attackVariance);

            min = (player.attack + player.extarAck) - (int)attackVariance;
            max = (player.attack + player.extarAck) + (int)attackVariance;
            finalAttack = Utility.returnRandomNum(min, max);

            // 몬스터 공격
            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player.name} 의 공격!");

            originHealth = targetMonster.maxHp;
            targetMonster.maxHp -= (int)finalAttack;

            Console.WriteLine($"Lv.{targetMonster.level} {targetMonster.name}을(를) 맞췄습니다. [데미지 : {finalAttack}]");

            Console.WriteLine($"Lv.{targetMonster.level} {targetMonster.name}");

            if (targetMonster.maxHp <= 0)
            {
                targetMonster.maxHp = 0;
                Console.WriteLine($"HP {originHealth} -> Dead");
                targetMonster.isDead = true; // isDead로 죽은 몬스터를 구분
            }
            else
            {
                Console.WriteLine($"HP {originHealth} -> {targetMonster.maxHp}");
            }

            // 적 턴으로 넘어가기 전에 적이 모두 죽었으면 
            if (randomMonsterList.All(monster => monster.isDead))
            {
                Finish(player, originHealth);
                return;
            }

            PlayerTurn();
        }

        public void PlayerTurn()
        {
            Console.WriteLine("0. 다음\n");
            Console.Write(">> ");

            actNumber = Utility.readNum(0, 0);

            if(actNumber != 0)
            {
                Console.WriteLine("잘못된 입력입니다.");
                PlayerTurn();
            }
            else
            {
                EnemyTurn();
            }
        }

        public void EnemyTurn()
        {
            Console.WriteLine("(배틀씬)");
            Console.WriteLine("플레이어, 적 그림");
            Console.WriteLine("Battle!!\n");

            // 위에 표시된 몬스터부터 공격
            for (int i = 0; i < randomMonsterList.Count; i++)
            {
                if (!randomMonsterList[i].isDead)
                {
                    Console.WriteLine($"Lv.{randomMonsterList[i].name} 의 공격!");
                    originHealth = player.hp;
                    player.hp -= randomMonsterList[i].attack;
                    if (player.hp < 0) player.hp = 0;

                    //Chad 을(를) 맞췄습니다.  [데미지: 6]
                    Console.WriteLine($"{player.name} 을(를) 맞췄습니다.  [데미지 : {randomMonsterList[i].attack}]");

                    //Lv.1 Chad
                    Console.WriteLine($"\nLv.{player.level} {player.name}");
                    //HP 100-> 94
                    Console.WriteLine($"HP {originHealth} -> {player.hp}");

                    Console.WriteLine("\n0. 다음");
                    Console.WriteLine("\n대상을 선택해주세요.");
                    Console.Write(">> ");
                    actNumber = Utility.readNum(0, 0);

                    
                }
            }
            // 몬스터 공격 끝

            // 플레이어 HP가 0보다 크면 (아직 플레이어가 살아있으면)
            if (player.hp > 0)
            {
                Console.WriteLine("플레이어의 턴입니다.");

                PrintRandomMonsters(MonsterDisplayMode.Attack); // 랜덤 몬스터 출력 
                PrintPlayerInfo(); // 내정보 출력 
                SetTarget(); // 대상 선택 
                AttackMonster(player, targetMonster); // 해당 몬스터 공격 
            }

            // 플레이어 HP가 0이면 (플레이어가 죽었으면)
            else
            {
                // hp가 음수면 0으로 만들어주기.
                if (player.hp < 0) player.hp = 0;

                Lose(player, originHealth);
                return;
            }

        }

        public void Finish(Player player, int originalHealth)
        {
            Console.WriteLine("승리 그림");
            Console.WriteLine("Battle!! - Result\n");

            Console.WriteLine("Victory\n");

            Console.WriteLine($"던전에서 몬스터 {monsterCount}마리를 잡았습니다.\n");

            Console.WriteLine($"Lv.{player.level} {player.name}");
            Console.WriteLine($"HP {player.hp}");

            Console.WriteLine("0. 다음\n");

            Console.Write(">> ");
            Environment.Exit(0); // 게임 종료 (프로그램 종료)
        }

        public void Lose(Player player, int originHealth)
        {
            Console.WriteLine("패배 그림");
            Console.WriteLine("Battle!! - Result\n");

            Console.WriteLine("You Lose\n");

            Console.WriteLine($"Lv.{player.level} {player.name}");

            Console.WriteLine($"{originHealth} -> {player.hp}");

            Console.WriteLine("0.다음\n");

            Console.Write(">> ");

            Console.WriteLine("게임이 종료됩니다.");
            Environment.Exit(0); // 게임 종료 (프로그램 종료)
        }
    }
}
