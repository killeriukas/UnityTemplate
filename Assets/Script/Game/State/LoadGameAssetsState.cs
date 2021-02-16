using TMI.AssetManagement;
using TMI.Core;
using TMI.LogManagement;
using TMI.Operation;
using TMI.State;
using TMI.TimeManagement;
using UnityEngine;

public class LoadGameAssetsState : BaseState {

	private readonly IAssetManager assetManager;

	public LoadGameAssetsState(IInitializer initializer) : base(initializer) {
		this.assetManager = initializer.GetManager<IAssetManager>();
	}

	public override void Enter() {
		base.Enter();

		//Logging.Log(this, "Asset started loading: " + MonotonicTime.now);
		Debug.LogError("Asset started loading: " + MonotonicTime.now);

		IAsyncOperation<Object> asyncOperation = DefaultAsyncOperation<Object>.Create(OnAssetsLoaded);
		assetManager.LoadFakeAsset(System.TimeSpan.FromSeconds(1), asyncOperation);
	}

	private void OnAssetsLoaded(Object asset) {
		//Logging.Log(this, "Asset loaded: " + MonotonicTime.now);
		Debug.LogError("Asset loaded: " + MonotonicTime.now);
	}

}
