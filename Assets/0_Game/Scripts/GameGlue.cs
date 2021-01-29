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


    float inputDelay;
    private void Awake()
    {
        inputDelay = 0;
        activePair = null;
        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
        LoadGame();
        yield return new WaitForSeconds(5f/60f);

        currentScreen.onStateChange = new CallbackInt();
        currentScreen.onStateChange.AddListener(LookAtScreen);

        canMove.ChangeCustom(1);
        currentScreen.ChangeCustom(0);
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

        inputDelay = Mathf.Clamp(inputDelay - Time.deltaTime, -1,99);

        if (canMove.GetState() == 1 && inputDelay < 0)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (activePair.gameScreen.rightScreenNumber >= 0)
                {
                    inputDelay = 12f / 60f;
                    currentScreen.ChangeCustom(activePair.gameScreen.rightScreenNumber);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (activePair.gameScreen.leftScreenNumber >= 0)
                {
                    inputDelay = 12f / 60f;
                    currentScreen.ChangeCustom(activePair.gameScreen.leftScreenNumber);
                }
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
                activePair = screens[i];
                return;
            }
        }

        Debug.LogWarning("DID NOT FIND SCREEN : " + number);
        //currentScreen.ChangeCustom(prev);
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

