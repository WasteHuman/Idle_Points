using NewGameLogic;
using UnityEngine;

namespace Assets.Scripts.NewGameLogic.NewRunnerNamespace
{
    public class NewGameStarter : MonoBehaviour
    {
        private void Awake()
        {
            NewGame.StartGame();
        }
    }
}