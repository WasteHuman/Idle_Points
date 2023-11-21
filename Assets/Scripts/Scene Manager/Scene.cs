using System.Collections;
using UnityEngine;

namespace Architecture
{
    public class Scene
    {
        private InteractorsBase _interactorsBase;
        private RepositoriesBase _repositoriesBase;
        private SceneConfig _sceneConfig;

        public Scene(SceneConfig config)
        {
            this._sceneConfig = config;
            this._interactorsBase = new InteractorsBase(config);
            this._repositoriesBase = new RepositoriesBase(config);
        }

        public Coroutine InizializeAsync()
        {
            return Coroutines.StartRoutine(this.InizializeRoutine());
        }

        private IEnumerator InizializeRoutine()
        {
            _interactorsBase.CreateAllInteractors();
            _repositoriesBase.CreateAllRepositories();
            yield return null;

            _interactorsBase.SendOnCreateToAllInteractors();
            _repositoriesBase.SendOnCreateToAllRepositories();
            yield return null;

            _interactorsBase.InitializeAllInteractors();
            _repositoriesBase.InitializeAllRepositories();
            yield return null;

            _interactorsBase.SendOnStartToAllInteractors();
            _repositoriesBase.SendOnStartToAllRepositories();
            yield return null;
        }

        public T GetRepository<T>() where T : Repository
        {
            return this._repositoriesBase.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return this._interactorsBase.GetInteractor<T>();
        }
    }

}