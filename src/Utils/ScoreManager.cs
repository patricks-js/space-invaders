namespace SpaceInvadersRetro.Utils;

public class ScoreManager
{
    public static int Score { get; private set; }

    public static void Increment(int points)
    {
        Score += points;
    }

    public static void Reset()
    {
        Score = 0;
    }
}
