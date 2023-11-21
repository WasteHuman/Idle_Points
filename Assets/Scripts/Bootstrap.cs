using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private Buttons _buttons;

    private IEnumerator Start()
    {
        _gameLogic.InitSaveGame();
        _gameLogic.OfflineEarnings();
        _buttons.InitLanguageFlag();
        yield return null;
    }
}
