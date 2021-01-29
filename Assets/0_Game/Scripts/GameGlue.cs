using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGlue : MonoBehaviour
{
    public MessagePrompt prefab_messagePrompt;

    public List<ScreenPair> screens;

    private void Awake()
    {
        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
        LoadGame();
        yield return new WaitForSeconds(5f/60f);
        LookAtScreen(0);
    }

    void LoadGame()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            SceneManager.LoadScene(screens[i].sceneName, LoadSceneMode.Additive);
        }
    }

    public void SetGameScreen(GameScreen screen)
    {
        for (int i = 0; i < screens.Count; i++)
        {
            if(screen.sceneName == screens[i].sceneName)
            {
                Debug.Log("match screen");
                screens[i].gameScreen = screen;
                return;
            }
        }
    }

    public void LookAtScreen(int number)
    {
        for (int i = 0; i < screens.Count; i++)
        {
            if(screens[i].screenNumber == number)
            {
                screens[i].gameScreen.LookAtScreen();
            }
        }
    }

    public void ShowMessage(string message)
    {
        MessagePrompt mp = GameObject.Instantiate(prefab_messagePrompt);
        mp.ShowMessage(message);
    }
   
}

[System.Serializable]
public class ScreenPair
{
    public int screenNumber;
    public string sceneName;
    public GameScreen gameScreen;
}
