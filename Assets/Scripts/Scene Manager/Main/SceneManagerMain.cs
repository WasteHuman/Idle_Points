namespace Architecture
{
    public sealed class SceneManagerMain : SceneManagerBase
    {
        public override void InitScenesMap()
        {
            this._sceneConfigMap[SceneConfigMain.SCENE_NAME] = new SceneConfigMain();
        }
    }

}