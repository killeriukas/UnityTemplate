using TMI.Core;
using TMI.AssetManagement;
using TMI.UI;

public class MainMenuInitializer : BaseCacheUIMiniInitializer {

    protected override ISceneGroup CreateUIScenesCache() {
        ISceneGroup sceneGroup = SceneGroup.Create();       
        sceneGroup.Add("ui_scene_main_menu");
        return sceneGroup;
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
