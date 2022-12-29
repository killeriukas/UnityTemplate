using System;
using Example.UI.UIToolkit;
using TMI.AssetManagement;
using TMI.Core;
using TMI.State;
using TMI.UI;
using UIManager = TMI.UI.UIToolkit.UIManager;

public class LoadGameAssetsState : BaseState {

	private readonly IAssetManager assetManager;
	private readonly IUIManager uiManager;

	public LoadGameAssetsState(IInitializer initializer) : base(initializer) {
		this.assetManager = initializer.GetManager<AssetManager, IAssetManager>();
		this.uiManager = initializer.GetManager<UIManager, IUIManager>();
	}

	public override void Enter() {
		base.Enter();

		//TODO: bet this one will crash when trying to load directly from GameScene
		LoadingScreenUIController loadingScreenUIController = uiManager.Load<LoadingScreenUIController>(false);
		loadingScreenUIController.Hide();
		

		// FakeGroup fakeResourceGroup = new FakeGroup(TimeSpan.FromSeconds(2));
		// IRequestHandler requestHandler = RequestHandler.Create(OnAssetsLoaded);
		// IHandle handle = assetManager.LoadAsync(fakeResourceGroup, requestHandler);
		//
		// LoadingScreenUIController loadingScreenUIController = uiManager.Load<LoadingScreenUIController>();
		// loadingScreenUIController.Setup(handle);
		// loadingScreenUIController.Show();
	}

	private void OnAssetsLoaded(ILoaderComplete asset) {
		LoadingScreenUIController loadingScreenUIController = uiManager.Load<LoadingScreenUIController>(false);
		loadingScreenUIController.Hide();

		// GameUIController gameUIController = uiManager.Load<GameUIController>();
		// gameUIController.Show();

		//go to the next state
	}

}
