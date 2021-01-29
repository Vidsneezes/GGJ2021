using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameScreen : MonoBehaviour
{
    public Camera viewCamera;
    public GameVarDictionary gameVariables;
    public EventSystem eventSystem;
    public string sceneName;

    public List<GameObject> ruleObjects;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name !=  sceneName)
        {
            LoadIn();
            GameGlue gameGlue = GameObject.FindObjectOfType<GameGlue>();
            gameGlue.SetGameScreen(this);
        }
    }

    public void LoadIn()
    {
        if(eventSystem != null)
        {
            GameObject.Destroy(eventSystem.gameObject);
        }

        if(gameVariables != null)
        {
            GameObject.Destroy(gameVariables.gameObject);
        }

        viewCamera.gameObject.SetActive(false);

        for (int i = 0; i < ruleObjects.Count; i++)
        {
            ruleObjects[i].gameObject.SetActive(false);
        }

    }

    public void LookAtScreen()
    {
        viewCamera.gameObject.SetActive(true);

        for (int i = 0; i < ruleObjects.Count; i++)
        {
            ruleObjects[i].gameObject.SetActive(true);
        }
    }
}
