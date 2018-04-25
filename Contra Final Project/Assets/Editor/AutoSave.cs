using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;

public class AutoSave : EditorWindow
{

    private bool autoSaveScene = true;
    private bool showMessage = true;
    private bool isStarted = false;
    private int intervalScene;
    private DateTime lastSaveTimeScene = DateTime.Now;

    private string projectPath;
    private string scenePath;
    private Scene scene;

    [MenuItem("Window/AutoSave")]
    public static void ShowWindow()
    {
        GetWindow<AutoSave>();
    }

    private void OnEnable()
    {
        projectPath = Application.dataPath;
    }

    private void OnGUI()
    {
        GUILayout.Label("Info:", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Saving to:", "" + projectPath);
        EditorGUILayout.LabelField("Saving scene:", "" + scene.path);
        GUILayout.Label("Options:", EditorStyles.boldLabel);
        autoSaveScene = EditorGUILayout.BeginToggleGroup("Auto save", autoSaveScene);
        intervalScene = EditorGUILayout.IntSlider("Interval (minutes)", intervalScene, 1, 15);
        if (isStarted)
        {
            EditorGUILayout.LabelField("Last save:", "" + lastSaveTimeScene);
        }
        EditorGUILayout.EndToggleGroup();
        showMessage = EditorGUILayout.BeginToggleGroup("Show Message", showMessage);
        EditorGUILayout.EndToggleGroup();
    }

    private void Update()
    {
        scene = EditorSceneManager.GetActiveScene();
        if (autoSaveScene)
        {
            if (DateTime.Now.Minute >= (lastSaveTimeScene.Minute + intervalScene) || DateTime.Now.Minute == 59 && DateTime.Now.Second == 59)
            {
                SaveScene();
            }
        }
        else
        {
            isStarted = false;
        }
    }

    private void SaveScene()
    {
        EditorSceneManager.SaveScene(scene, scene.path);
        lastSaveTimeScene = DateTime.Now;
        isStarted = true;
        if (showMessage)
        {
            Debug.Log("AutoSave saved: " + scene.path + " on " + lastSaveTimeScene);
        }
        GetWindow<AutoSave>().Repaint();
    }
}
