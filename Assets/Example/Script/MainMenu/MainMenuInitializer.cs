using TMI.AssetManagement;
using TMI.UI;

public class MainMenuInitializer : TMI.Core.Unity.BaseInitializer {

    protected override void OnUIAssetsCached() {
        LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>(false);
        loadingScreen.Hide();

        MainMenuUIController mainMenuUIController = uiManager.LoadUI<MainMenuUIController>();
        mainMenuUIController.Show();
    }

    public override void Shutdown() {
        uiManager.UnloadUIPrefab("main_menu_screen");
        base.Shutdown();
    }

    protected override IGroup CreateUIAssetCacheGroup() {
        UIConfigGroup assetGroup = new UIConfigGroup();
        assetGroup.Add("main_menu_screen");
        return assetGroup;
	}

}
