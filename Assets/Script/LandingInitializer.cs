﻿using TMI.AssetManagement;
using TMI.ConfigManagement;
using TMI.Core;
using TMI.Helper;
using TMI.LogManagement;
using TMI.Operation;
using TMI.UI;
using UnityEngine;

public class LandingInitializer : BaseCacheUIMiniInitializer {

    protected override void Awake() {

        //config and logging initialize first, before anything else
        ConfigManager.AddConfig<LoggingConfig>();

        LoggingConfig logConfig = ConfigManager.GetConfig<LoggingConfig>();
        Logging.output = new UnityConditionalLogOutput(logConfig);

        base.Awake();
    }

    protected override void RegisterManagers(IAcquirer acquirer) {

        //TODO: put this into the config file
#if UNITY_EDITOR
        SerializationHelper.currentFormatting = Newtonsoft.Json.Formatting.Indented;
#endif

        base.RegisterManagers(acquirer);
    }

    protected override ISceneGroup CreateUIScenesCache() {
        ISceneGroup sceneGroup = SceneGroup.Create();
        sceneGroup.Add("ui_scene_loading");
        return sceneGroup;
    }

    protected override void OnUIScenesCached() {
        LoadingScreenUIController loadingScreen = uiManager.LoadUI<LoadingScreenUIController>();
        loadingScreen.version = "Version: " + Application.version;
        loadingScreen.Show();

        sceneManager.LoadScene(SceneConstant.main_menu);
    }

}
