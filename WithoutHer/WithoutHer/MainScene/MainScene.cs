using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace WithoutHer
{
    internal class MainScene
    {
        // 1. 함수 만들 때 "파스칼케이스"로;
        // 2. 변수 만들 때 "카멜케이스"로;
        // 3. 변수의 접근제한자는 "public"으로 통일 
        static void Main(string[] args)
        {
            MainMenu game = new MainMenu();
            game.Run();
        }
    }
}
