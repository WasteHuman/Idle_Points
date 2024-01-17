using UnityEngine;

namespace NewGameLogic.NewAssets
{
    [CreateAssetMenu(menuName = "Assets/Coins Asset", fileName = "Coins Asset")]
    public class CoinsAsset : ScriptableObject
    {
        public float CoinsPerClick;
    }
}