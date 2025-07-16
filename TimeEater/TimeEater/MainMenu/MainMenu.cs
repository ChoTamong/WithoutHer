namespace TimeEater
{
    // 기본 씬 클래스:
    public class MainMenu
    {
        Player player = new Player();
        Inventory inventory = new Inventory();
        Shop shop = new Shop();
        Battle battle = new Battle();

        public void Run()
        {
            EnterNameAndJob();
            while (true)
            {
                ShowMenu();
            }
        }

        public void EnterNameAndJob()
        {
            Console.Clear();
            Console.WriteLine("[이름 입력]");
            Console.Write("이름을 입력해주세요.\n>>> ");

            string inputName = Utility.readName();
            // 이름 입력 후 플레이어 객체 이름에 저장 (메소드 불러오기)

            Console.Clear();
            Console.WriteLine("[직업 선택]\n");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 궁수");
            Console.WriteLine("4. 도적");
            Console.Write("\n원하는 직업을 입력해주세요.\n>>> ");

            int inputJob = Utility.readNum(1, 4);
            // 직업 선택 후 플레이어 객체 이름에 저장 (메소드 불러오기) 
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("[메인 메뉴]\n");
            Console.WriteLine("환영합니다.\n");
            Console.WriteLine("1. 상태 확인");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 진입");
            Console.WriteLine("0. 게임 종료");
            Console.Write("\n원하는 행동을 입력해주세요.\n>>> ");

            int inputNum = Utility.readNum(0, 4);

            switch (inputNum)
            {
                case 1:
                    player.PlayerStatus();
                    break;
                case 2:
                    inventory.ShowInventory();
                    break;
                case 3:
                    shop.ShowShop();
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
