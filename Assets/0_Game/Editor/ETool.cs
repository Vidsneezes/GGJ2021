using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.EventSystems;

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

}
