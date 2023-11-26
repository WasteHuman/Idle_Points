using UnityEngine;

namespace PointsData
{
    public class PointsView : MonoBehaviour
    {
        private PointsData m_PointsData;

        public PointsData PointsData => m_PointsData;

        public void AttachData(PointsData data)
        {
            m_PointsData = data;
        }
    }
}
