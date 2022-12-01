using TMI.AssetManagement;
using TMI.UI;
using UnityEngine;

public class LandingInitializer : TMI.Core.Unity.BaseInitializer {

    protected override IAssetGroup CreateUIAssetCache() {
        IAssetGroup assetGroup = AssetGroup.Create();
        assetGroup.AddGameObject("Misc/prefab_loading_screen");
        return assetGroup;
    }

    protected override void OnUIAssetsCached() {
		LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>();
		loadingScreen.version = "Version: " + Application.version;
		loadingScreen.Show();

		sceneManager.LoadScene(SceneConstant.main_menu);
	}

}
