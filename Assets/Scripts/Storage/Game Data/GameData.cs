[System.Serializable]
public class GameData
{
    public float score;
    public float clickScore;

    public bool isBonusPurchased;

    public float[] multiplier;
    public float[] costUpgrade;
    public float[] costBonus;
    public float pointsPerSecond;
    public float totalBonusIncome;
    public int maxOfflineTime;
}