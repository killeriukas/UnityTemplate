using TMI.AssetManagement;
using TMI.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class LandingInitializer : TMI.Core.Unity.BaseInitializer {

	[SerializeField]
	private UIDocument uiDocument;
	
    protected override IGroup CreateUIAssetCacheGroup() {
	    UIConfigGroup assetGroup = new UIConfigGroup();
	    assetGroup.Add("loading_screen");
        return assetGroup;
    }

    protected override void OnUIAssetsCached() {

	 //   TMI.Temporary.MainMenuUIController mainMenu = uiDocument.GetComponent<TMI.Temporary.MainMenuUIController>();
	//	mainMenu.Setup(uiDocument.rootVisualElement);
	    
	    LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>();
	    loadingScreen.version = "Version: " + Application.version;
	    loadingScreen.Show();
	    
	    sceneManager.LoadAsync(SceneConstant.main_menu);
    }

}
