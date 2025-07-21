using System.Text.RegularExpressions;

namespace WithoutHer
{
    // 반복 메소드 집합:
    public class Utility
    {
        public static int returnRandomNum(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static int readNum(int min, int max)
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max)
            {
                Console.Write("잘못된 입력입니다, 다시 입력해주세요\n");
            }
            return number;
        }
        public static string readName()
        {
            string name = Console.ReadLine();
            Regex regex = new Regex(@"^[a-zA-Z가-핳]+$");
            while (string.IsNullOrWhiteSpace(name) || name.Length < 2 || name.Length > 10 || !regex.IsMatch(name))
            {
                Console.Write("잘못된 입력입니다, 다시 입력해주세요\n>>> ");
                name = Console.ReadLine();
            }
            return name;
        }
    }

}
