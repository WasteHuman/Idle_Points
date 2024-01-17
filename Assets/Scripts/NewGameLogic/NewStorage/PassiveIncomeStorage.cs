using NewGameLogic.NewAssets;
using System;

namespace NewGameLogic.NewStorage
{
    [Serializable]
    public class PassiveIncomeStorage
    {
        private PriceAsset m_PriceAsset;

        private float m_MaximumOfflineTime;

        public PassiveIncomeStorage()
        {
            m_PriceAsset = new();
        }
    }
}
