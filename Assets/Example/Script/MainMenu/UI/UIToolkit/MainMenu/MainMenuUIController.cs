using System;
using TMI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace TMI.Temporary {
	public class MainMenuUIController : MonoBehaviour {

		private class OptionScreenController : IDisposable {

			private readonly VisualElement root;
			
			private readonly Button closeButton;
			private readonly Label descriptionText;

			public OptionScreenController(VisualElement rootVisualElement, OptionScreenDataSO optionScreenData) {
				descriptionText = rootVisualElement.Q<Label>(optionScreenData.descriptionTextId);
				descriptionText.text = optionScreenData.descriptionText;
				
				closeButton = rootVisualElement.Q<Button>(optionScreenData.closeButtonId);
				closeButton.clicked += Hide;
				
				root = rootVisualElement;
			}

			public void Show() {
				root.style.display = DisplayStyle.Flex;
			}

			public void Hide() {
				root.style.display = DisplayStyle.None;
			}
			
			public void Dispose() {
				closeButton.clicked -= Hide;
			}

		}

		[SerializeField]
		private MainMenuScreenDataSO mainMenuScreenData;

		[SerializeField]
		private OptionScreenDataSO optionScreenData;

		private OptionScreenController optionScreenController;
		
		private Button startButton;
		private Button optionButton;
		private Button quitButton;
		
		public void Setup(VisualElement rootVisualElement) {
			startButton = rootVisualElement.Q<Button>(mainMenuScreenData.startButtonId);
			optionButton = rootVisualElement.Q<Button>(mainMenuScreenData.optionButtonId);
			quitButton = rootVisualElement.Q<Button>(mainMenuScreenData.quitButtonId);

			VisualElement optionScreenVisualElement = rootVisualElement.Q<VisualElement>(mainMenuScreenData.optionScreenId);
			optionScreenController = new OptionScreenController(optionScreenVisualElement, optionScreenData);

			startButton.clicked += OnStartButtonClicked;
			optionButton.clicked += OnOptionButtonClicked;
			quitButton.clicked += OnQuitButtonClicked;
		}
		private void OnStartButtonClicked() {
			Debug.Log("OnStartButtonClicked() Clicked");
		}

		private void OnOptionButtonClicked() {
			optionScreenController.Show();
		}

		private void OnQuitButtonClicked() {
			Debug.Log("OnQuitButtonClicked() Clicked");
			//Application.Quit();
		}

		private void OnDestroy() {
			optionScreenController.Dispose();
			
			startButton.clicked -= OnStartButtonClicked;
			quitButton.clicked -= OnQuitButtonClicked;
			optionButton.clicked -= OnOptionButtonClicked;
		}
		
		
		// [SerializeField]
		// private UIButton quitButton;
		//
		// [SerializeField]
		// private UIButton startButton;
		//
		// private ISceneManager sceneManager;
		//
		// public override void Setup(IInitializer initializer) {
		// 	base.Setup(initializer);
		// 	sceneManager = initializer.GetManager<ISceneManager>();
		//
		// 	quitButton.onButtonClick += OnQuitClicked;
		// 	startButton.onButtonClick += OnStartClicked;
		// }
		//
		// private void OnStartClicked(PointerEventData data) {
		// 	LoadingScreenUIController loadingScreenUIController = uiManager.LoadUI<LoadingScreenUIController>();
		// 	loadingScreenUIController.Show();
		//
		// 	sceneManager.LoadScene(SceneConstant.game);
		// }
		//
		// private void OnQuitClicked(PointerEventData data) {
		// 	Application.Quit();
		// }
		//
		// protected override void OnDestroy() {
		// 	quitButton.onButtonClick -= OnQuitClicked;
		// 	base.OnDestroy();
		// }
	}
	
}


