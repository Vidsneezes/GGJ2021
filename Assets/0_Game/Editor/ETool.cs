using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ETool : Editor
{

    [MenuItem("Tool/Screenify")]
    static void Screenify()
    {
        GameScreen gameScreen = GameObject.FindObjectOfType<GameScreen>();

        if(gameScreen == null)
        {
            gameScreen = new GameObject().AddComponent<GameScreen>();
        }

        gameScreen.name = "##GAME SCREEN##";


        Camera cam = GameObject.FindObjectOfType<Camera>();
        if(cam != null)
        {
            gameScreen.viewCamera = cam;
            cam.transform.parent = gameScreen.transform;
        }

        EventSystem evs = GameObject.FindObjectOfType<EventSystem>();
        if(evs != null)
        {
            gameScreen.eventSystem = evs;
        }

        GameVarDictionary vars = GameObject.FindObjectOfType<GameVarDictionary>();
        
        if(vars != null)
        {
            gameScreen.gameVariables = vars;
        }

        GameObject[] rules = GameObject.FindGameObjectsWithTag("rule");
        gameScreen.ruleObjects = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < rules.Length; i++)
        {
            gameScreen.ruleObjects.Add(rules[i]);
        }

        gameScreen.sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        Undo.RecordObject(gameScreen, "Updated Game Screen");
        EditorUtility.SetDirty(gameScreen);

    }

    [MenuItem("Tool/BuildVariables")]

    static void BuildVariables()
    {
        if (SceneManager.GetActiveScene().name == "GameGlue")
        {
            string core = "Assets/0_Game/GameVariables/CoreLoop";
            string system = "Assets/0_Game/GameVariables/System";

            string[] val = AssetDatabase.FindAssets("l:GameVariable", new[] { core, system });

            GameVarDictionary varDict = GameObject.FindObjectOfType<GameVarDictionary>();

            varDict.refVariables = new System.Collections.Generic.List<GameVariable>();
            EditorUtility.DisplayProgressBar("Building Indexes", "wait", 0.3f);

            foreach (string guid2 in val)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid2);
                GameVariable var = AssetDatabase.LoadAssetAtPath<GameVariable>(path);
                varDict.refVariables.Add(var);
            }
            EditorUtility.ClearProgressBar();

            EditorUtility.SetDirty(varDict);
            Undo.RecordObject(varDict, "Added game variables");

            UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }
        else
        {
            Debug.LogWarning("In Wrong Scene");
        }
    }


    [MenuItem("Tool/Update Prefabs")]

    static void UpdatePrefabs()
    {
        string fbxPath = "Assets/0_Game/AssetImport";
        string piecesPath = "Assets/0_Game/Prefabs/Pieces";

        string[] val = AssetDatabase.FindAssets("l:fbx", new[] { fbxPath });

        //val = HighestVersion(val)
       
        for (int i = 0; i < val.Length; i++)
        {
            GameObject modelImp = (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(val[i]), typeof(GameObject));

            Debug.Log(modelImp.name);
            string prefabName = modelImp.name;
            string[] split = modelImp.name.Split('_');
            if (split.Length == 3)
            {
                prefabName = $"piece_{split[1]}_0";
            }
            else if (split.Length == 4)
            {

            }

            GameObject prefabCreated = GameObject.Instantiate(modelImp);
            prefabCreated.name = prefabName;
            EditorUtility.DisplayProgressBar("Generating", $"Object {prefabName}", (float)i / (float)val.Length);

            PrefabUtility.SaveAsPrefabAsset(prefabCreated, $"{piecesPath}/{prefabCreated.name}.prefab");
            GameObject.DestroyImmediate(prefabCreated);

            EditorUtility.ClearProgressBar();
        }
       

        return;
    }

    public string[] HighestVersion(string[] all)
    {
        return null;
    }

}
