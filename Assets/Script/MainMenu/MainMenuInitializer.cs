using TMI.Core;
using TMI.AssetManagement;
using TMI.UI;

public class MainMenuInitializer : BaseCacheUIMiniInitializer {

    protected override void OnUIAssetsCached() {
        LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>(false);
        loadingScreen.Hide();

        MainMenuUIController mainMenuUIController = uiManager.LoadUI<MainMenuUIController>();
        mainMenuUIController.Show();
    }

    protected override void OnDestroy() {
        uiManager.UnloadUIPrefab("MainMenu/prefab_ui_main_menu");
        base.OnDestroy();
    }

	protected override IAssetGroup CreateUIAssetCache() {
        IAssetGroup assetGroup = AssetGroup.Create();
        assetGroup.AddGameObject("MainMenu/prefab_ui_main_menu");
        return assetGroup;
	}

}
