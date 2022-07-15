Character c1 = new Character("Player", 1, 100, 5, 1);
Enemy e1 = new Enemy();
Fight f1 = new Fight();

Console.WriteLine("Press random buttn to start\n");

char d = 'd';
char e = 'e';
char f = 'f';
char c = 'c';
char h = 'h';
char u = 'u';
char g = 'g';

int i = 0;
int lvlup = 0;
int godcounter = 0;
char button = (char)Console.Read();

while (true)
{
    if (i == 0)
        {
            Console.WriteLine("\nChoose Action: \nD - Display Player Info\nE - Display Enemy Info \nF - Fight With Enemy \nC - Change Enemy \n");
            
            i++;
        }
    button = (char)Console.Read();

    if (button == d)
    {
        Console.Clear();
        c1.DisplayInfo();
        i = 0;
        
    }else if(button == e)
    {
        Console.Clear();
        e1.DisplayEnemyInfo();
        i = 0;

    }
    else if(button == f)
    {
        Console.Clear();
        e1.DisplayEnemyInfo();
        f1.FightDisplay(c1.GetPlayerHP(),c1.GetPlayerDMG(),e1.GetEnemyHP(), e1.GetEnemyDMG(), e1.GetEnemyEXP());

        int level = c1.GetPlayerLevel();
        int playerEXP = c1.GetPlayerExp();
        int enemyEXP = e1.GetEnemyEXP();
        int playerHP = c1.GetPlayerHP();
        int playerDMG = c1.GetPlayerDMG();
        int ExpStage = level * 100;
        int ExpSum = playerEXP + enemyEXP;
       
        if (ExpStage <= ExpSum)
        {
            level++;
            playerEXP = ExpSum - ExpStage;
            playerHP = playerHP + 10;
            playerDMG = playerDMG + 2;

            Console.WriteLine("\nLevel Up!\nYou can add points: \nHP+10 -=- H \nDMG+2 -=- U\n");
            lvlup++;

            
        }
        else
        {
            playerEXP += enemyEXP;
            i = 0;
        }
        c1 = new Character(c1.GetPlayerName(), level, playerHP, playerDMG, playerEXP);
        c1.DisplayInfo();
        e1 = new Enemy();
    }
    else if(button == c)
    {
        Console.Clear();
        e1 = new Enemy();
        e1.DisplayEnemyInfo();
        i = 0;
    }
    else if (button == h && lvlup > 0)
    {
        Console.Clear();
        int hp = c1.GetPlayerHP();
        hp += 10;
        i = 0;
        lvlup--;
        c1 = new Character(c1.GetPlayerName(), c1.GetPlayerLevel(), hp, c1.GetPlayerDMG(), c1.GetPlayerExp());
        Console.WriteLine("\nYou have: {0} points to add.\n", lvlup);
    }
    else if (button == u && lvlup > 0)
    {
        Console.Clear();
        int dmg = c1.GetPlayerDMG();
        dmg += 2;
        i = 0;
        lvlup--;
        c1 = new Character(c1.GetPlayerName(), c1.GetPlayerLevel(), c1.GetPlayerHP(), dmg, c1.GetPlayerExp());
        Console.WriteLine("\nYou have: {0} points to add.\n", lvlup);
    }
    else if (button == g)
    {
        Console.Clear();
        int hp = c1.GetPlayerHP();
        int dmg = c1.GetPlayerDMG();
        hp += 10;
        dmg += 2;
        godcounter++;
        c1 = new Character(c1.GetPlayerName(), c1.GetPlayerLevel(), hp, dmg, c1.GetPlayerExp());
        Console.WriteLine("\nGod mode on points, you add {0} point.\n",godcounter);
    }

}

public interface ICharacter
{
    void DisplayInfo();
    
}

public class Character : ICharacter
{
    private string name;
    private int level;
    private int hitPoints;
    private int damage;
    private int exp;

    public Character()
    {
        name = "";
        level = 1;
        hitPoints = 100;
        damage = 5;
        exp = 1;
    }

    public Character(string name, int level, int hitPoints, int damage, int exp)
    {
        this.name = name;
        this.level = level;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.exp = exp;
    }

    public int GetPlayerHP()
    {
        return hitPoints;
    }

    public int GetPlayerDMG()
    {
        return damage;
    }
    public string GetPlayerName()
    {
        return name;
    }
    public int GetPlayerLevel()
    {
        return level;
    }

    public int GetPlayerExp()
    {
        return exp;
    }


    public void DisplayInfo()
    {
        Console.WriteLine("Name: {0}\nLevel: {1}\nHP: {2}\nDMG: {3}\nExp: {4}/{5}\n", name, level, hitPoints, damage, exp, level*100);
    }

}

public interface IEnemy
{
    void DisplayEnemyInfo();
    
}

public class Enemy : IEnemy
{
    private string name;
    private int level;
    private int hitPoints;
    private int damage;
    private int exp;

    public Enemy()
    {
        name = "Enemy";
        Random rnd = new Random();
        level = rnd.Next(1, 10);
        hitPoints = level*50;
        damage = 2*level;
        exp = level*5;
    }

    public Enemy(string name, int hitPoints, int level, int damage, int exp)
    {
        this.name = name;
        this.hitPoints = hitPoints;
        this.level = level;
        this.damage = damage;
        this.exp = exp;
    }
    public int GetEnemyHP()
    {
        return hitPoints;
    }
    public int GetEnemyDMG()
    {
        return damage;
    }
    public int GetEnemyEXP()
    {
        return exp;
    }

    public void DisplayEnemyInfo()
    {
        Console.WriteLine("Name: {0}\nLevel: {1}\nHP: {2}\nDMG: {3}\nExp: {4}", name, level, hitPoints, damage, exp);
    }
}

public interface IFight
{
    void FightDisplay(int HP, int DMG, int EnemyHP, int EnemyDMG, int EnemyEXP);
}

public class Fight : IFight
{
    private string name;
    private int playerHP;
    private int playerDMG;
    private int enemyHP;
    private int enemyDMG;
    private int enemyEXP;

    public Fight()
    {
        name = "Fight";
        playerHP = 1;
        playerDMG = 1;
        enemyHP = 1;
        enemyDMG = 1;
    }

    public Fight(string name, int playerHP, int playerDMG, int enemyHP, int enemyDMG, int enemyEXP)
    {
        this.name = name;
        this.playerHP = playerHP;
        this.playerDMG = playerDMG;
        this.enemyHP = enemyHP;
        this.enemyDMG = enemyDMG;
        this.enemyEXP = enemyEXP;
    }

    public void FightDisplay(int HP, int DMG, int EnemyHP, int EnemyDMG, int EnemyEXP)
    {
        int temp = HP;
        Console.WriteLine("\nFight!\n");
        while(HP >= 0 || EnemyHP >= 0)
        {
            if(EnemyHP > 0 && HP > 0)
            {
                Random rnd = new Random();
                int hit = rnd.Next(1, 100);
                int dodgeScanner = 0;

                if (hit/2 > 25 || dodgeScanner == 1)
                {
                    EnemyHP -= DMG;
                    Console.WriteLine("Enemy get: {0} DMG", DMG);
                }
                else
                {
                    Console.WriteLine("Enemy dodge attack!");
                    dodgeScanner = 1;
                }

                //System.Threading.Thread.Sleep(500);
                rnd = new Random();
                hit = rnd.Next(1, 100);

                if(hit / 2 > 25 || dodgeScanner == 1)
                {
                    HP -= EnemyDMG;
                    Console.WriteLine("You get: {0} DMG", EnemyDMG);
                }
                else
                {
                    Console.WriteLine("You dodge attack!");
                    dodgeScanner = 1;
                }
                //System.Threading.Thread.Sleep(500);
                Console.WriteLine("Your HP: {0}, Enemy HP: {1}\n", HP, EnemyHP);
                //System.Threading.Thread.Sleep(1000);
            }
            else if(EnemyHP <= 0 && HP > 0)
            {
                Console.WriteLine("\nYou win!\n");
                HP = temp;
                break;
            }
            else
            {
                Console.WriteLine("\nYou lose!\nReset Game\n");
                System.Threading.Thread.Sleep(10000000);
                break;
                
            }
        }
    }
}