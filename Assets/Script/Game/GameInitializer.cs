using TMI.Core;
using TMI.AssetManagement;

public class GameInitializer : BaseCacheUIMiniInitializer {

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
    }

    protected override void OnDestroy() {
        uiManager.UnloadUIScene("ui_scene_game");
        base.OnDestroy();
    }

}
