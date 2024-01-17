using NewGameLogic.NewAssets;
using System;

namespace NewGameLogic.NewStorage
{
    [Serializable]
    public class ClickUpgradesStorage
    {
        public float[] costUpgrades; 
        public float[] multiplierUpgrades;

        private PriceAsset m_PriceAsset;

        public ClickUpgradesStorage()
        {
            m_PriceAsset = new();
            InitializeStorage();
        }

        private void InitializeStorage()
        {
            costUpgrades = new float[5];
            multiplierUpgrades = new float[5];

            for (int i = 0; i < costUpgrades.Length; i++)
            {
                costUpgrades[i] = m_PriceAsset.Prices[i];
            }
            for (int j = 0; j < multiplierUpgrades.Length; j++)
            {
                multiplierUpgrades[j] = m_PriceAsset.Multipliers[j];
            }
        }
    }
}
