using TMI.Core;
using TMI.AssetManagement;
using TMI.UI;

public class MainMenuInitializer : BaseCacheUIMiniInitializer {

  //  private MetagameManager metagameManager;

   // private IAssetManager assetManager;

    protected override ISceneGroup CreateUIScenesCache() {
        ISceneGroup sceneGroup = SceneGroup.Create();
        
        sceneGroup.Add("ui_scene_main_menu");

        return sceneGroup;
    }

    protected override void RegisterManagers(IAcquirer acquirer) {
        base.RegisterManagers(acquirer);

   //     assetManager = acquirer.AcquireManager<AssetManager, IAssetManager>();

       // metagameManager = acquirer.AcquireManager<MetagameManager>();
    }

    protected override void OnUIScenesCached() {
        LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>(false);
        loadingScreen.Hide();

        MainMenuUIController mainMenuUIController = uiManager.LoadUI<MainMenuUIController>();
        mainMenuUIController.Show();
    }

    protected override void OnDestroy() {
        uiManager.UnloadUIScene("ui_scene_main_menu");
        base.OnDestroy();
    }

}
