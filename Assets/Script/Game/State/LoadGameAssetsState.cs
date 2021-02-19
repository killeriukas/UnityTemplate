using TMI.AssetManagement;
using TMI.Core;
using TMI.LogManagement;
using TMI.Operation;
using TMI.State;
using TMI.TimeManagement;
using TMI.UI;
using UnityEngine;

public class LoadGameAssetsState : BaseState {

	private readonly IAssetManager assetManager;
	private readonly IUIManager uiManager;

	public LoadGameAssetsState(IInitializer initializer) : base(initializer) {
		this.assetManager = initializer.GetManager<IAssetManager>();
		this.uiManager = initializer.GetManager<IUIManager>();
	}

	public override void Enter() {
		base.Enter();

		IAsyncOperation<Object> asyncOperation = DefaultAsyncOperation<Object>.Create(OnAssetsLoaded);
		IHandle handle = assetManager.LoadFakeAsset(System.TimeSpan.FromSeconds(1), asyncOperation);

		LoadingScreenUIController loadingScreenUIController = uiManager.LoadUI<LoadingScreenUIController>();
		loadingScreenUIController.Setup(handle);
	}

	private void OnAssetsLoaded(Object asset) {
		LoadingScreenUIController loadingScreenUIController = uiManager.LoadUI<LoadingScreenUIController>(false);
		loadingScreenUIController.Hide();

		//GameUIController gameUIController = uiManager.LoadUI<GameUIController>();
		//gameUIController.Show();

		//go to the next state
	}

}
