using System;
using System.Collections;
using Architecture;

public static class StartGame
{
    public static event Action OnGameInizializedEvent;

    public static SceneManagerBase sceneManager { get; private set; }

    public static void RunGame()
    {
        sceneManager = new SceneManagerMain();
        Points.clickScore = 1f;
        Coroutines.StartRoutine(InizializeGameRoutine());
    }

    private static IEnumerator InizializeGameRoutine()
    {
        sceneManager.InitScenesMap();
        yield return sceneManager.LoadCurrentSceneAsync();
        OnGameInizializedEvent?.Invoke();
    }

    public static T GetRepository<T>() where T : Repository
    {
        return sceneManager.GetRepository<T>();
    }

    public static T GetInteractor<T>() where T : Interactor
    {
        return sceneManager.GetInteractor<T>();
    }
}
