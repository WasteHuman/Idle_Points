using System;

namespace Architecture
{
    public static class Points
    {
        public static event Action OnPointsInizializedEvent;

        public static float score
        {
            get
            {
                CheckClass();
                return _interactor.score;
            }
            set
            {

            }
        }

        public static float clickScore
        {
            get
            {
                CheckClass();
                return _interactor.clickScore;
            }
            set
            {

            }
        }

        public static bool isInizialized { get; private set; }

        private static PointsInteractor _interactor;

        public static void Inizialize(PointsInteractor interactor)
        {
            _interactor = interactor;
            isInizialized = true;

            OnPointsInizializedEvent?.Invoke();
        }

        public static bool IsEnoughtPoints(float value)
        {
            CheckClass();
            return _interactor.IsEnoughtPoints(value);
        }

        public static void AddPoints(object sender, float value)
        {
            CheckClass();
            _interactor.AddPoints(sender, value);
        }

        public static void Spend(object sender, float value)
        {
            CheckClass();
            _interactor.Spend(sender, value);
        }

        private static void CheckClass()
        {
            if (!isInizialized)
            {
                throw new Exception("Points is not inizialized yet");
            }
        }
    }

}