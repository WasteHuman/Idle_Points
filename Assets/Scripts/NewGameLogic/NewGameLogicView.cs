using UnityEngine;
using UnityEngine.UI;


namespace NewGameLogic
{
    public class NewGameLogicView : MonoBehaviour
    {
        [SerializeField]
        private Text m_TotalPointsViewText;
        [SerializeField]
        private Text m_PointsPerClickViewText;


        [SerializeField]
        private Text[] m_PricesTextView;
        [SerializeField]
        private Text[] m_MultipliersTextView;

        private void Start()
        {
            UpdateStoreTextValues();
            UpdatePointsPerClickText();
            UpdatePointsViewText();
        }

        public void OnClick()
        {
            NewGame.NewPlayer.CoinsData.IncreaseCoins();
            UpdatePointsViewText();
        }

        public void BuyFirstUpgrade()
        {
            NewGame.NewPlayer.CoinsData.IncreaseCoinsPerClick(NewGame.NewPlayer.ClickUpgradesData.CostUpgrades, 0, NewGame.NewPlayer.ClickUpgradesData.MultiplierUpgrades, 0);
            UpdateStoreTextValues();
        }

        public void BuySecondUpgrade()
        {
            NewGame.NewPlayer.CoinsData.IncreaseCoinsPerClick(NewGame.NewPlayer.ClickUpgradesData.CostUpgrades, 1, NewGame.NewPlayer.ClickUpgradesData.MultiplierUpgrades, 1);
            UpdateStoreTextValues();
        }

        public void BuyThirdUpgrade()
        {
            NewGame.NewPlayer.CoinsData.IncreaseCoinsPerClick(NewGame.NewPlayer.ClickUpgradesData.CostUpgrades, 2, NewGame.NewPlayer.ClickUpgradesData.MultiplierUpgrades, 2);
            UpdateStoreTextValues();
        }

        public void BuyFourthUpgrade()
        {
            NewGame.NewPlayer.CoinsData.IncreaseCoinsPerClick(NewGame.NewPlayer.ClickUpgradesData.CostUpgrades, 3, NewGame.NewPlayer.ClickUpgradesData.MultiplierUpgrades, 3);
            UpdateStoreTextValues();
        }

        public void BuyFifthUpgrade()
        {
            NewGame.NewPlayer.CoinsData.IncreaseCoinsPerClick(NewGame.NewPlayer.ClickUpgradesData.CostUpgrades, 4, NewGame.NewPlayer.ClickUpgradesData.MultiplierUpgrades, 4);
            UpdateStoreTextValues();
        }

        private void UpdateStoreTextValues()
        {
            UpdatePointsPerClickText();

            for (int i = 0; i < NewGame.NewPlayer.ClickUpgradesData.CostUpgrades.Length; i++)
            {
                m_PricesTextView[i].text = FormatNumbers.FormatNumber(NewGame.NewPlayer.ClickUpgradesData.CostUpgrades[i]);
                m_MultipliersTextView[i].text = "Increase income by " + FormatNumbers.FormatNumber(NewGame.NewPlayer.ClickUpgradesData.MultiplierUpgrades[i]);
            }
        }

        private void UpdatePointsViewText()
        {
            m_TotalPointsViewText.text = FormatNumbers.FormatNumber(NewGame.NewPlayer.CoinsData.Coins);
        }

        private void UpdatePointsPerClickText()
        {
            if (LanguageManager.Instance.language == 1)
            {
                m_PointsPerClickViewText.text = FormatNumbers.FormatNumber(NewGame.NewPlayer.CoinsData.CoinsPerClick) + " ќчк/клик";
            }
            else if (LanguageManager.Instance.language == 0)
            {
                m_PointsPerClickViewText.text = FormatNumbers.FormatNumber(NewGame.NewPlayer.CoinsData.CoinsPerClick) + " P/Click";
            }
        }

        private void OnApplicationQuit()
        {
            NewGame.StopPlayer();
        }
    }
}