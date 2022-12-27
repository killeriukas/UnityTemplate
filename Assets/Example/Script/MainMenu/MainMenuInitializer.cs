using TMI.Core;
using TMI.AssetManagement;
using TMI.UI;

public class MainMenuInitializer : TMI.Core.Unity.BaseInitializer {

    protected override void OnUIAssetsCached() {
        LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>(false);
        loadingScreen.Hide();

        MainMenuUIController mainMenuUIController = uiManager.LoadUI<MainMenuUIController>();
        mainMenuUIController.Show();
    }

    protected override void OnDestroy() {
        uiManager.UnloadUIPrefab("main_menu_screen");
        base.OnDestroy();
    }

	protected override IGroup CreateUIAssetCacheGroup() {
        UIConfigGroup assetGroup = new UIConfigGroup();
        assetGroup.Add("main_menu_screen");
        return assetGroup;
	}

}
