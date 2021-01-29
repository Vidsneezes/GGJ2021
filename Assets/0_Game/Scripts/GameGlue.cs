using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGlue : MonoBehaviour
{
    public MessagePrompt prefab_messagePrompt;
    public GameVariable currentScreen;
    public GameVariable canMove;

    public List<ScreenPair> screens;
    [HideInInspector]
    public ScreenPair activePair;
   

    private void Awake()
    {
        activePair = null;
        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
        LoadGame();
        yield return new WaitForSeconds(5f/60f);
        LookAtScreen(0);
        canMove.ChangeCustom(1);
    }

    void LoadGame()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            SceneManager.LoadScene(screens[i].sceneName, LoadSceneMode.Additive);
        }
    }



    private void Update()
    {
        if (GameVarDictionary.dictionaryInstance != null)
        {
            GameVarDictionary.dictionaryInstance.DebugMenu();
        }

        if (canMove.GetState() == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                LookAtScreen(activePair.gameScreen.rightScreenNumber);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                LookAtScreen(activePair.gameScreen.leftScreenNumber);
            }
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

    void ClosePreviousScreen(int prev)
    {
        if(activePair == null)
        {
            return;
        }

        if(activePair != null)
        {
            activePair.gameScreen.Close();
        }
       
    }

    public void LookAtScreen(int number)
    {
        int prev = currentScreen.GetState();

        for (int i = 0; i < screens.Count; i++)
        {
            if(screens[i].screenNumber == number)
            {
                ClosePreviousScreen(prev);
                screens[i].gameScreen.LookAtScreen();
                currentScreen.ChangeCustom(0);
                activePair = screens[i];
                return;
            }
        }
    }

    public void ShowMessage(string message)
    {
        MessagePrompt mp = GameObject.Instantiate(prefab_messagePrompt);
        mp.ShowMessage(message);
    }
   
    public static void TryShowMessage(string message)
    {
        GameGlue gameGlue = GameObject.FindObjectOfType<GameGlue>();
        if (gameGlue != null)
        {
            gameGlue.ShowMessage(message);
        }
    }
}

