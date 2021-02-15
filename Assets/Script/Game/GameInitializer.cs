using TMI.Core;
using TMI.AssetManagement;
using TMI.UI;

public class GameInitializer : BaseCacheUIMiniInitializer {

    private GameManager gameManager;

    protected override ISceneGroup CreateUIScenesCache() {
        ISceneGroup sceneGroup = SceneGroup.Create();
        
        //sceneGroup.Add("ui_scene_main_menu");

        return sceneGroup;
    }

    protected override void RegisterManagers(IAcquirer acquirer) {
        base.RegisterManagers(acquirer);

        gameManager = acquirer.AcquireManager<GameManager>();

   //     assetManager = acquirer.AcquireManager<AssetManager, IAssetManager>();

       // metagameManager = acquirer.AcquireManager<MetagameManager>();
    }

    protected override void OnUIScenesCached() {
        gameManager.Initialize();

        //LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>(false);
        //loadingScreen.Hide();

        //MainMenuUIController mainMenuUIController = uiManager.LoadUI<MainMenuUIController>();
        //mainMenuUIController.Show();
    }

    protected override void OnDestroy() {
      //  uiManager.UnloadUIScene("ui_scene_main_menu");
        base.OnDestroy();
    }

}
