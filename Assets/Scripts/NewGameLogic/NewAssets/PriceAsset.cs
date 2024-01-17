using System;

namespace NewGameLogic.NewAssets
{
    [Serializable]
    public class PriceAsset
    {
        public PriceAsset()
        {
            InitializeClickUgradePrices();
            InitializeMultipliers();

            InitializePassiveIncomePrices();
            InitializePassiveIncome();
        }
        #region Click Upgrades
        private float[] m_ClickUpgradePrices;
        private float[] m_Multipliers;

        public float[] Prices => m_ClickUpgradePrices;
        public float[] Multipliers => m_Multipliers;

        private void InitializeClickUgradePrices()
        {
            m_ClickUpgradePrices = new float[5];
            m_ClickUpgradePrices[0] = 200f;
            m_ClickUpgradePrices[1] = 1000f;
            m_ClickUpgradePrices[2] = 2500f;
            m_ClickUpgradePrices[3] = 4500f;
            m_ClickUpgradePrices[4] = 6000f;
        }

        private void InitializeMultipliers()
        {
            m_Multipliers = new float[5];
            m_Multipliers[0] = 1.5f;
            m_Multipliers[1] = 2f;
            m_Multipliers[2] = 2.5f;
            m_Multipliers[3] = 4.5f;
            m_Multipliers[4] = 5f;
        }
        #endregion

        #region Passive Income Upgrades
        private float[] m_PassiveIncomePrices;
        private float[] m_PassiveIncome;

        public float[] PassiveIncomePrices => m_PassiveIncomePrices;
        public float[] PassiveIncome => m_PassiveIncome;

        private void InitializePassiveIncomePrices()
        {
            m_PassiveIncomePrices = new float[5];

            m_PassiveIncomePrices[0] = 1000f;
            m_PassiveIncomePrices[1] = 3000f;
            m_PassiveIncomePrices[2] = 5000f;
            m_PassiveIncomePrices[3] = 7000f;
            m_PassiveIncomePrices[4] = 10000f;
        }
        private void InitializePassiveIncome()
        {
            m_PassiveIncome = new float[5];

            m_PassiveIncome[0] = 5f;
            m_PassiveIncome[1] = 10f;
            m_PassiveIncome[2] = 30f;
            m_PassiveIncome[3] = 50f;
            m_PassiveIncome[4] = 100f;
        }
        #endregion
    }
}