using System;

namespace NewGameLogic.NewStorage
{
    [Serializable]
    public class CoinsStorage
    {
        public float coinsStored;
        public float coinsPerClick;

        public CoinsStorage()
        {
            InizializeCoinsPerClick();
        }

        private void InizializeCoinsPerClick()
        {
            if (coinsPerClick == 0f)
            {
                coinsPerClick = 1f;
            }
        }
    }
}
