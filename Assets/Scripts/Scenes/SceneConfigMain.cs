using System;
using System.Collections.Generic;

namespace Architecture
{
    public class SceneConfigMain : SceneConfig
    {
        public const string SCENE_NAME = "Main";

        public override string sceneName => SCENE_NAME;

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();

            //�������� �����������
            this.CreateInteractor<PointsInteractor>(interactorsMap);

            return interactorsMap;
        }

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();

            //�������� �����������
            this.CreateRepository<PointsRepository>(repositoriesMap);

            return repositoriesMap;
        }
    }
}
