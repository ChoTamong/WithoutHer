namespace WithoutHer
{
    // 기본 씬 클래스:
    public class MainMenu
    {
        Player player;
        Inventory inventory;
        Shop shop;
        Battle battle;
        UI ui;

        public void Run()
        {
            Init();
            StartGameSceneOne();
            StartGameSceneTwo();
            StartGameSceneThird();
            StartGameSceneFour();
            EnterNameAndJob();
            while (true)
            {
                ShowMenu();
            }
        }

        public void Init()
        {
            shop = new Shop();
            battle = new Battle();
            ui = UI.Instance;
        }

        public void StartGameSceneOne()
        {
            Console.Clear();
            ui.SceneOne();
            Console.WriteLine("");
            Console.ReadKey();
        }
        public void StartGameSceneTwo()
        {
            Console.Clear();
            ui.SceneTwo();
            Console.WriteLine("");
            Console.ReadKey();
        }
        public void StartGameSceneThird()
        {
            Console.Clear();
            ui.SceneThird();
            Console.WriteLine("");
            Console.ReadKey();
        }
        public void StartGameSceneFour()
        {
            Console.Clear();
            ui.SceneFour();
            Console.WriteLine("");
            Console.ReadKey();
        }

        public void EnterNameAndJob()
        {
            Console.Clear();
            ui.FirstLine();
            Console.WriteLine("[이름 입력]");
            Console.Write("이름을 입력해주세요.\n>>> ");

            string inputName = Utility.readName();

            Console.Clear();
            ui.Miorror();
            Console.WriteLine("[나의 모습]\n");
            Console.WriteLine("거울에 비친 내 모습을 바라본다.\n");
            Console.WriteLine("1. 왜소하다");
            Console.WriteLine("2. 평범하다");
            Console.WriteLine("3. 다부지다");
            Console.Write("\n선택하기...\n>>> ");

            int inputJob = Utility.readNum(1, 3);

            player = new Player(inputName, inputJob);
            inventory = new Inventory();

            DataManager.Instance.player = player;

            //player.SetName(inputName); // 이름 설정
            //player.SetJob(inputJob); // 직업 설정
        }

        public void ShowMenu()
        {
            Console.Clear();
            ui.Title();
            Console.WriteLine("[메인 메뉴]\n");
            Console.WriteLine("환영합니다.\n");
            Console.WriteLine("1. 상태 확인");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 밀거래상");
            Console.WriteLine("4. 탈옥하기");
            Console.WriteLine("0. 게임 종료");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");

            int inputNum = Utility.readNum(0, 4);

            switch (inputNum)
            {
                case 1:
                    player.PlayerStatus(PlayerStatusDisplayMode.Normal);
                    break;
                case 2:
                    inventory.FirstShowInventory();
                    break;
                case 3:
                    shop.FirstItemShop();
                    break;
                case 4:
                    battle.EnterDungeon();
                    break;
                case 0:
                    Console.WriteLine("게임을 종료합니다, 감사합니다.");
                    Environment.Exit(0);
                    break; 
            }
        }
    }

}
