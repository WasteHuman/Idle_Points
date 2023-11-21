namespace Architecture
{
    public class PointsInteractor : Interactor
    {
        private PointsRepository _pointsRepository;

        public float score => this._pointsRepository.Score;
        public float clickScore => this._pointsRepository.ClickScore;

        public override void OnCreate()
        {
            base.OnCreate();
            this._pointsRepository = StartGame.GetRepository<PointsRepository>();
        }

        public override void Inizialize()
        {
            Points.Inizialize(this);
        }

        public bool IsEnoughtPoints(float value)
        {
            return score >= value;
        }

        public void AddPoints(object sender, float value)
        {
            this._pointsRepository.Score += value;
        }

        public void Spend(object sender, float value)
        {
            this._pointsRepository.Score -= value;
        }
    }

}