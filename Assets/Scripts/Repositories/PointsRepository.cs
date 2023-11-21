namespace Architecture
{
    public class PointsRepository : Repository
    {

        private GameData _gameData = new GameData();

        public float Score { get; set; }
        public float ClickScore { get; set; }

        public override void Inizialize()
        {
            this.Score = _gameData.score;
            this.ClickScore = _gameData.clickScore;
        }

        public override void Save()
        {
            _gameData.score = this.Score;
            _gameData.clickScore = this.ClickScore;
        }
    }

}