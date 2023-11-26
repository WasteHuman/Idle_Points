namespace PointsData
{
    public class PointsData
    {
        private PointsView m_PointsView;

        public PointsView PointsView => m_PointsView;

        public void AttachView(PointsView view)
        {
            m_PointsView = view;
            view.AttachData(this);
        }
    }
}
