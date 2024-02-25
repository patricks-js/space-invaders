namespace SpaceInvadersRetro.Components;

public static class SpaceshipHealthManager
{
    private static int _health = 3;
    public static int Health { get; set; }

    public static void DecreaseHealth()
    {
        _health--;
    }

    public static void IncreaseHealth()
    {
        if (_health <= 6)
        {
            _health++;
        }
    }
}
