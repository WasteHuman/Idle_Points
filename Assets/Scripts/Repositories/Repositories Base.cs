using System;
using System.Collections.Generic;

namespace Architecture
{
    public class RepositoriesBase
    {

        private Dictionary<Type, Repository> _repositorysMap;
        private SceneConfig _sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            this._sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
            this._repositorysMap = this._sceneConfig.CreateAllRepositories();
        }

        public void SendOnCreateToAllRepositories()
        {
            var allRepositoryes = this._repositorysMap.Values;
            foreach (var repository in allRepositoryes)
            {
                repository.OnCreate();
            }
        }

        public void InitializeAllRepositories()
        {
            var allRepositories = this._repositorysMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.Inizialize();
            }
        }

        public void SendOnStartToAllRepositories()
        {
            var allRepositories = this._repositorysMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)this._repositorysMap[type];
        }

    }
}
