using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace TimeEater
{
    internal class MainScene
    {
        // 1. 함수 만들 때 "파스칼"로;
        // 2. 변수 만들 때 "카멜"로;
        // 3. 변수의 접근제한자 "public" 만
        static void Main(string[] args)
        {
            MainMenu game = new MainMenu();
            game.Run();
        }
    }
}
