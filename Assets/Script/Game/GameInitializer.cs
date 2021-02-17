using TMI.Core;
using TMI.AssetManagement;
using UnityEngine;
using TMI.Helper;

public class GameInitializer : BaseCacheUIMiniInitializer {

    [SerializeField]
    private PaddleBehaviour paddleBehaviour;

    [SerializeField]
    private BallBehaviour ballBehaviour;

    [SerializeField]
    private BrickBehaviour brickPrefab;

    [SerializeField]
    private Transform brickContainerTransform;

    private IAssetManager assetManager;
    private GameManager gameManager;

    protected override ISceneGroup CreateUIScenesCache() {
        ISceneGroup sceneGroup = SceneGroup.Create();
        sceneGroup.Add("ui_scene_game");
        return sceneGroup;
    }

    protected override void RegisterManagers(IAcquirer acquirer) {
        base.RegisterManagers(acquirer);

        gameManager = acquirer.AcquireManager<GameManager>();
        assetManager = acquirer.AcquireManager<AssetManager, IAssetManager>();
    }

    protected override void OnUIScenesCached() {
        gameManager.Initialize();

        ballBehaviour.Setup(this);
        ballBehaviour.Initialize();

        paddleBehaviour.Setup(this);
        paddleBehaviour.Initialize();

        //initialize loads of bricks.
        //later move this code elsewhere

        for(int i = 0; i < 10; ++i) {
            for(int j = 0; j < 22; ++j) {
                Vector3 position = new Vector3(j * 3, -i, 0);
                BrickBehaviour brick = HierarchyHelper.InstantiateAndSetupBehaviour(this, brickPrefab, brickContainerTransform, false);
                brick.transform.localPosition = position;
            }
        }

    }

    protected override void OnDestroy() {
        uiManager.UnloadUIScene("ui_scene_game");
        base.OnDestroy();
    }

}
