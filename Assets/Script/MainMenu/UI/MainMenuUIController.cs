using System;
using TMI.Core;
using TMI.SceneManagement;
using TMI.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuUIController : BaseUIController {

	[SerializeField]
	private UIButton quitButton;

	[SerializeField]
	private UIButton startButton;

	private ISceneManager sceneManager;

	public override void Setup(IInitializer initializer) {
		base.Setup(initializer);
		sceneManager = initializer.GetManager<ISceneManager>();

		quitButton.onButtonClick += OnQuitClicked;
		startButton.onButtonClick += OnStartClicked;
	}

	private void OnStartClicked(PointerEventData data) {
		LoadingScreenUIController loadingScreenUIController = uiManager.LoadUI<LoadingScreenUIController>();
		loadingScreenUIController.Show();

		sceneManager.LoadScene(SceneConstant.game);
	}

	private void OnQuitClicked(PointerEventData data) {
		Application.Quit();
	}

	protected override void OnDestroy() {
		quitButton.onButtonClick -= OnQuitClicked;
		base.OnDestroy();
	}
}
