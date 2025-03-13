class Enemy
{
    private string Name;
    public int Hp;
    public int MinDmg;
    public int MaxDmg;
    public Enemy () { }
    public Enemy(string name, int hp, int minimumDmg, int maximumDmg)
    {
        Name = name;
        Hp = hp;
        MinDmg = minimumDmg;
        MaxDmg = maximumDmg;
    }

}