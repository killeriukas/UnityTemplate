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

    private GameManager gameManager;

	protected override IAssetGroup CreateUIAssetCache() {
        IAssetGroup assetGroup = AssetGroup.Create();
        assetGroup.AddGameObject("prefab_ui_game");
        return assetGroup;
	}

    protected override void RegisterManagers(IAcquirer acquirer) {
        base.RegisterManagers(acquirer);
        gameManager = acquirer.AcquireManager<GameManager>();
    }

    protected override void OnUIAssetsCached() {
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
        uiManager.UnloadUIPrefab("prefab_ui_game");
        base.OnDestroy();
    }

}
