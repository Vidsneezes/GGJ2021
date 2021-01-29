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

    public int leftScreenNumber;
    public int rightScreenNumber;

    public List<GameObject> ruleObjects;

    [HideInInspector]
    public AudioListener audioLs;

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

        audioLs = viewCamera.GetComponent<AudioListener>();
        if(audioLs != null)
        {
            audioLs.enabled = false;
        }

        for (int i = 0; i < ruleObjects.Count; i++)
        {
            ruleObjects[i].gameObject.SetActive(false);
        }



    }

    public void Close()
    {
        viewCamera.gameObject.SetActive(false);

        audioLs = viewCamera.GetComponent<AudioListener>();
        if (audioLs != null)
        {
            audioLs.enabled = false;
        }

        for (int i = 0; i < ruleObjects.Count; i++)
        {
            ruleObjects[i].gameObject.SetActive(false);
        }
    }

    public void LookAtScreen()
    {
        viewCamera.gameObject.SetActive(true);

        audioLs = viewCamera.GetComponent<AudioListener>();
        if (audioLs != null)
        {
            audioLs.enabled = true;
        }

        for (int i = 0; i < ruleObjects.Count; i++)
        {
            ruleObjects[i].gameObject.SetActive(true);
        }
    }
}
