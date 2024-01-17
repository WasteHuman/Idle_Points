using NewGameLogic.NewRunnerNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGameLogic
{
    public static class NewGame
    {
        private static NewGameLogicView s_NewGameLogic;
        private static NewRunner s_NewRunner;
        private static NewPlayer s_NewPlayer;

        public static NewGameLogicView NewGameLogic => s_NewGameLogic;
        public static NewPlayer NewPlayer => s_NewPlayer;
        public static NewRunner NewRunner => s_NewRunner;

        public static void StartGame()
        {
            s_NewRunner = Object.FindObjectOfType<NewRunner>();
            s_NewRunner.StartRunning();

            s_NewPlayer = new NewPlayer(s_NewRunner.GetDataFromList(0), s_NewRunner.GetDataFromList(1));
            s_NewRunner.LoadDatas();
            SceneManager.LoadScene(1);

            if (s_NewRunner.IsRunning)
            {
                Debug.Log("Started!");
            }
        }

        public static void StopPlayer()
        {
            s_NewRunner.SaveDatas();
            s_NewRunner.StopRunning();
        }
    }
}
