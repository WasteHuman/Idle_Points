using NewGameLogic.Data;
using NewStorage;

namespace NewGameLogic.NewRunnerNamespace
{
    public class NewPlayer
    {
        private CoinsData m_CoinsData;
        private ClickUpgradesData m_ClickUpgradesData;

        public CoinsData CoinsData => m_CoinsData;
        public ClickUpgradesData ClickUpgradesData => m_ClickUpgradesData;

        public NewPlayer(ISaveAndLoad coinsData, ISaveAndLoad clickUpgradesData)
        {
            m_CoinsData = coinsData as CoinsData;
            m_ClickUpgradesData = clickUpgradesData as ClickUpgradesData;
        }
    }
}
