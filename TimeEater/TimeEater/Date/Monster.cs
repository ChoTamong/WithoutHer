namespace TimeEater
{
    public class Monster
    {
        public string name;
        public int level;
        public int type;
        public int maxHp;
        public int attack;
        public int defense;
        public bool isDead;

        public Monster(MonsterData monsterData)
        {
            this.name = monsterData.name;
            this.level = monsterData.level;
            this.type = monsterData.type;
            this.maxHp = monsterData.maxHp;
            this.attack = monsterData.attack;
            this.defense = monsterData.defense;
            this.isDead = monsterData.isDead;
        }
    }

    public class MonsterData
    {
        public string name;
        public int level;
        public int type;
        public int maxHp;
        public int attack;
        public int defense;
        public bool isDead;

        public MonsterData(string name, int level, int type, int maxHp, int attack, int defense)
        {
            this.name = name;
            this.level = level;
            this.type = type;
            this.maxHp = maxHp;
            this.attack = attack;
            this.defense = defense;
            this.isDead = false;
        }
    }
}
