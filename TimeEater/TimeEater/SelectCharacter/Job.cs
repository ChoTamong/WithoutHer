using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeEater
{
    public abstract class Job
    {
        public abstract string Name { get; }
        public abstract int BaseHP { get; }
        public abstract int NowHP { get; }
        public abstract int BaseMP { get; }
        public abstract int NowMP { get; }
        public abstract int BaseAttack { get; }
        public abstract int BaseDefence { get; }

        // 나중에 확장을 위한 메서드
        public virtual void UseSkill(Player player, Monster target) // Player player, Monster target 매개변수 추가.
        {
            Console.WriteLine($"{Name}은(는) 아무 스킬도 없습니다.");
        }
    }

    public class MuscleMan : Job
    {
        public override string Name => "다부짐";
        public override int BaseHP => 120;
        public override int NowHP => BaseHP; // 현재 HP는 기본 HP와 동일
        public override int BaseMP => 70;
        public override int NowMP => BaseMP; // 현재 MP는 기본 MP와 동일
        public override int BaseAttack => 15;
        public override int BaseDefence => 10;
    }

    public class SlightBuild : Job
    {
        public override string Name => "왜소함";
        public override int BaseHP => 70;
        public override int NowHP => BaseHP; // 현재 HP는 기본 HP와 동일
        public override int BaseMP => 120;
        public override int NowMP => BaseMP; // 현재 MP는 기본 MP와 동일
        public override int BaseAttack => 8;
        public override int BaseDefence => 6;
    }

    public class Normal : Job
    {
        public override string Name => "도적";
        public override int BaseHP => 100;
        public override int NowHP => BaseHP;
        public override int BaseMP => 50;
        public override int NowMP => BaseMP;
        public override int BaseAttack => 10;
        public override int BaseDefence => 5;
    }
}
