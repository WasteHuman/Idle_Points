using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : Sounds
{
    public static GameLogic Instance;

    private float points;
    private float clickScore = 1f;

    private int _maxOfflineTime = 2 * 60 * 60;

    [SerializeField] public float totalBonusIncome;
    [SerializeField] public float totalClickPoints;
    [SerializeField] private int _clicksBeforeShowAd;
    [SerializeField] private float _totalOfflineBonus;

    public int ClicksForShowAd { get; private set; }

    [SerializeField] private float[] _multiplier;
    [SerializeField] private float[] _costUpgrade;
    [SerializeField] private float[] costBonus;
    [SerializeField] private float costUpgradeOffline;
    [SerializeField] private float pointsPerSecond;

    public Text scoreText;
    public Text totalBonusIncomeText;
    public Text totalClickPointsText;
    public Text[] upgradeCostText;
    public Text[] bonusCostText;
    public Text nowMaxOfflineTime;

    [HideInInspector]
    public static bool isBonusPurchased;

    private GameData sv;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(BonusIncomePerSec());
        StartCoroutine(ScaleChanger.Instance.SpawnPoints());

        if (totalBonusIncome != 0f)
        {
            isBonusPurchased = true;
        }
    }

    public void InitSaveGame()
    {
        sv = new GameData();

        //Загрузка сохранения
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<GameData>(PlayerPrefs.GetString("SV"));
            points = sv.score;
            clickScore = sv.clickScore;
            pointsPerSecond = sv.pointsPerSecond;
            totalBonusIncome = sv.totalBonusIncome;
            isBonusPurchased = sv.isBonusPurchased;
            _maxOfflineTime = sv.maxOfflineTime;

            bonusCostText[5].text = FormatNumbers.FormatNumber(costUpgradeOffline);
            TimeSpan t = TimeSpan.FromSeconds(_maxOfflineTime);

            string answer = string.Format("{0}", t.Hours);

            nowMaxOfflineTime.text = answer;

            for (int i = 0; i < _costUpgrade.Length; i++)
            {
                _costUpgrade[i] = sv.costUpgrade[i];
                upgradeCostText[i].text = FormatNumbers.FormatNumber(sv.costUpgrade[i]);
            }
            for (int i = 0; i < costBonus.Length; i++)
            {
                costBonus[i] = sv.costBonus[i];
                bonusCostText[i].text = FormatNumbers.FormatNumber(sv.costBonus[i]);
            }
            for (int m = 0; m < _multiplier.Length; m++)
            {
                _multiplier[m] = sv.multiplier[m];
            }

            if (_maxOfflineTime == 16*60*60)
            {
                bonusCostText[5].text = "Max";
            }
        }
        else
        {
            InitArrays();
        }
    }

    void Update()
    {

        if (LanguageManager.Instance.language == 1)
        {
            totalClickPointsText.text = FormatNumbers.FormatNumber(totalClickPoints) + " Очк/клик";
            totalBonusIncomeText.text = FormatNumbers.FormatNumber(totalBonusIncome) + " О/сек";
        }
        else if (LanguageManager.Instance.language == 0)
        {
            totalClickPointsText.text = FormatNumbers.FormatNumber(totalClickPoints) + " P/click";
            totalBonusIncomeText.text = FormatNumbers.FormatNumber(totalBonusIncome) + " P/sec";
        }

        scoreText.text = FormatNumbers.FormatNumber(points);

        totalClickPoints = clickScore;

        totalBonusIncome = pointsPerSecond;
    }

    public void OfflineEarnings()
    {
        DateTime lastsavetime = Utils.GetDateTime("lastsavetime", DateTime.UtcNow);
        TimeSpan timepassed = DateTime.UtcNow - lastsavetime;
        int secondspassed = (int)timepassed.TotalSeconds;
        secondspassed = Math.Clamp(secondspassed, 0, _maxOfflineTime);
        points += secondspassed * totalBonusIncome;
        print($"total earning: {secondspassed * totalBonusIncome}");
    }

    private void InitArrays()
    {
        for (int i = 0; i < _costUpgrade.Length; i++)
        {
            _costUpgrade[i] = _costUpgrade[i];
            upgradeCostText[i].text = FormatNumbers.FormatNumber(_costUpgrade[i]);
        }
        for (int i = 0; i < costBonus.Length; i++)
        {
            costBonus[i] = costBonus[i];
            bonusCostText[i].text = FormatNumbers.FormatNumber(costBonus[i]);
        }
        for (int i = 0; i < _multiplier.Length; i++)
        {
            _multiplier[i] = _multiplier[i];
        }

        bonusCostText[5].text = FormatNumbers.FormatNumber(costUpgradeOffline);
        TimeSpan t = TimeSpan.FromSeconds(_maxOfflineTime);

        string answer = string.Format("{0}", t.Hours);

        nowMaxOfflineTime.text = answer;
    }

    public void ClickOnClickCircle()
    {
        points += clickScore;

        PlaySound(sounds[0]);

        if (ClicksForShowAd < _clicksBeforeShowAd)
        {
            ClicksForShowAd++;
        }

        ShowAdsRate();
    }

    private void ShowAdsRate()
    {
        if (_clicksBeforeShowAd == ClicksForShowAd)
        {
            ClicksForShowAd = 0;
            float adShowPercent = 0.35f;
            float tempPercent = UnityEngine.Random.Range(0f, 1f);

            if (tempPercent < adShowPercent)
            {
                YandexAds.instance.ShowAd();
            }
        }
    }

    public void FirstUpgrade()
    {
        if (points >= _costUpgrade[0])
        {
            points -= _costUpgrade[0];
            clickScore *= _multiplier[1];
            _costUpgrade[0] *= 2f;
            upgradeCostText[0].text = FormatNumbers.FormatNumber(_costUpgrade[0]);
        }

        PlaySound(sounds[0]);
    }

    public void SecondUpgrage()
    {
        if (points >= _costUpgrade[1])
        {
            points -= _costUpgrade[1];
            clickScore *= _multiplier[1];
            _costUpgrade[1] *= 2f;
            upgradeCostText[1].text = FormatNumbers.FormatNumber(_costUpgrade[1]);
        }

        PlaySound(sounds[0]);
    }

    public void ThirdUpgrade()
    {
        if (points >= _costUpgrade[2])
        {
            points -= _costUpgrade[2];
            clickScore *= _multiplier[2];
            _costUpgrade[2] *= 2f;
            upgradeCostText[2].text = FormatNumbers.FormatNumber(_costUpgrade[2]);
        }

        PlaySound(sounds[0]);
    }

    public void FourthUpgrade()
    {
        if (points >= _costUpgrade[3])
        {
            points -= _costUpgrade[3];
            clickScore *= _multiplier[3];
            _costUpgrade[3] *= 2f;
            upgradeCostText[3].text = FormatNumbers.FormatNumber(_costUpgrade[3]);
        }

        PlaySound(sounds[0]);
    }

    public void FifthUpgrade()
    {
        if (points >= _costUpgrade[4])
        {
            points -= _costUpgrade[4];
            clickScore *= _multiplier[4];
            _costUpgrade[4] *= 2f;
            upgradeCostText[4].text = FormatNumbers.FormatNumber(_costUpgrade[4]);
        }

        PlaySound(sounds[0]);
    }

    public void BuyBonus2PerSec()
    {
        if (points >= costBonus[0])
        {
            points -= costBonus[0];

            isBonusPurchased = true;

            costBonus[0] *= 2f;
            pointsPerSecond += 2f;
            bonusCostText[0].text = FormatNumbers.FormatNumber(costBonus[0]);
        }

        PlaySound(sounds[0]);
    }
    public void BuyBonus6PerSec()
    {
        if (points >= costBonus[1])
        {
            points -= costBonus[1];

            isBonusPurchased = true;

            costBonus[1] *= 2f;
            pointsPerSecond += 6f;
            bonusCostText[1].text = FormatNumbers.FormatNumber(costBonus[1]);
        }

        PlaySound(sounds[0]);
    }

    public void BuyBonus12PerSec()
    {
        if (points >= costBonus[2])
        {
            points -= costBonus[2];

            isBonusPurchased = true;

            costBonus[2] *= 2f;
            pointsPerSecond += 12f;
            bonusCostText[2].text = FormatNumbers.FormatNumber(costBonus[2]);
        }

        PlaySound(sounds[0]);
    }

    public void BuyBonus24PerSec()
    {
        if (points >= costBonus[3])
        {
            points -= costBonus[3];

            isBonusPurchased = true;

            costBonus[3] *= 2f;
            pointsPerSecond += 24f;
            bonusCostText[3].text = FormatNumbers.FormatNumber(costBonus[3]);
        }

        PlaySound(sounds[0]);
    }

    public void BuyBonus48PerSec()
    {
        if (points >= costBonus[4])
        {
            points -= costBonus[4];

            isBonusPurchased = true;

            costBonus[4] *= 2f;
            pointsPerSecond += 48f;
            bonusCostText[4].text = FormatNumbers.FormatNumber(costBonus[4]);
        }

        PlaySound(sounds[0]);
    }

    public void UpgradeMaxOfflineTime()
    {
        if (points >= costUpgradeOffline && _maxOfflineTime != 16*60*60)
        {
            _maxOfflineTime *= 2;
            points -= costUpgradeOffline;
            costUpgradeOffline *= 5;
            bonusCostText[5].text = FormatNumbers.FormatNumber(costUpgradeOffline);

            TimeSpan t = TimeSpan.FromSeconds(_maxOfflineTime);

            string answer = string.Format("{0}", t.Hours);

            nowMaxOfflineTime.text = answer;

            if (_maxOfflineTime == 16*60*60)
            {
                bonusCostText[5].text = "Max";
            }
        }

        PlaySound(sounds[0]);
    }

    IEnumerator BonusIncomePerSec()
    {
        while (!isBonusPurchased)
        {
            yield return null;
        }
        while (isBonusPurchased)
        {
            points += pointsPerSecond;
            PlaySound(sounds[0]);
            yield return new WaitForSeconds(1f);
        }
    }

    //Сохранение на Android
#if UNITY_ANDROID && !UNITY_EDITOR
    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }
    }
#else
    //Сохранение вне Android
    public void OnApplicationQuit()
    {
        //Save();
    }
#endif

    private void Save()
    {
        sv.score = points;
        sv.clickScore = clickScore;
        sv.multiplier = new float[5];
        sv.costUpgrade = new float[5];
        sv.costBonus = new float[5];
        sv.pointsPerSecond = pointsPerSecond;
        sv.totalBonusIncome = totalBonusIncome;
        sv.isBonusPurchased = isBonusPurchased;
        sv.maxOfflineTime = _maxOfflineTime;

        for (int i = 0; i < _costUpgrade.Length; i++)
        {
            sv.costUpgrade[i] = _costUpgrade[i];
        }
        for (int i = 0; i < costBonus.Length; i++)
        {
            sv.costBonus[i] = costBonus[i];
        }

        Utils.SetDateTime("LastSaveTime", DateTime.UtcNow);

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
    }
}