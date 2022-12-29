using TMI.Core;
using TMI.AssetManagement;
using TMI.ConfigManagement.Unity.UI;
using TMI.Core.Unity;
using UnityEngine;
using TMI.Helper;

public class GameInitializer : Initializer {

    [SerializeField]
    private PaddleBehaviour paddleBehaviour;

    [SerializeField]
    private BallBehaviour ballBehaviour;

    [SerializeField]
    private BrickBehaviour brickPrefab;

    [SerializeField]
    private Transform brickContainerTransform;

    private IGameManager gameManager;

	protected override IGroup CreateUIAssetCacheGroup() {
        IUIConfig uiConfig = uiManagerDefault.GetConfig();
        
        UIConfigGroup assetGroup = new UIConfigGroup(uiConfig);
    //    assetGroup.Add("game_screen");
        return assetGroup;
	}

    protected override void RegisterManagers(IAcquirer acquirer) {
        base.RegisterManagers(acquirer);
        gameManager = acquirer.AcquireManager<GameManager, IGameManager>();
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

    public override void OnPreDestroy() {
     //   uiManagerDefault.Unload("game_screen");
        base.OnPreDestroy();
    }

}
