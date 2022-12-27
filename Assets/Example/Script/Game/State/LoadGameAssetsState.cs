using System;
using TMI.AssetManagement;
using TMI.Core;
using TMI.State;
using TMI.UI;
using UnityEngine;

public class LoadGameAssetsState : BaseState {

	private readonly IAssetManager assetManager;
	private readonly IUIManager uiManager;

	public LoadGameAssetsState(IInitializer initializer) : base(initializer) {
		this.assetManager = initializer.GetManager<AssetManager, IAssetManager>();
		this.uiManager = initializer.GetManager<UIManager, IUIManager>();
	}

	public override void Enter() {
		base.Enter();


		FakeGroup fakeResourceGroup = new FakeGroup(TimeSpan.FromSeconds(2));
		IRequestHandler requestHandler = RequestHandler.Create(OnAssetsLoaded);
		IHandle handle = assetManager.LoadAsync(fakeResourceGroup, requestHandler);

		LoadingScreenUIController loadingScreenUIController = uiManager.LoadUI<LoadingScreenUIController>();
		loadingScreenUIController.Setup(handle);
		loadingScreenUIController.Show();
	}

	private void OnAssetsLoaded(ILoaderComplete asset) {
		LoadingScreenUIController loadingScreenUIController = uiManager.LoadUI<LoadingScreenUIController>(false);
		loadingScreenUIController.Hide();

		GameUIController gameUIController = uiManager.LoadUI<GameUIController>();
		gameUIController.Show();

		//go to the next state
	}

}
