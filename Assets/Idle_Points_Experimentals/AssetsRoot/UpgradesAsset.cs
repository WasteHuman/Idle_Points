using PointsData;
using UnityEngine;

namespace AssetsRoot
{
    [CreateAssetMenu(menuName = "Assets/Upgrades Asset", fileName = "Upgrades Asset")]
    public class UpgradesAsset : ScriptableObject
    {
        public float ClickAddingPoints;

        public PointsView PointsPrefab;
    }
}