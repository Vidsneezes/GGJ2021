using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class GameVarDictionary : MonoBehaviour
{
    public static GameVarDictionary dictionaryInstance;

    public List<GameVariable> refVariables;

    public Dictionary<string, int> runtimeVars;
    [HideInInspector]
    public bool init = false;

    bool showDebug = false;

    public void Fill()
    {
        if (GameVarDictionary.dictionaryInstance == null)
        {
            GameVarDictionary.dictionaryInstance = this;
            
            if (init == false)
            {
                runtimeVars = new Dictionary<string, int>();
                for (int i = 0; i < refVariables.Count; i++)
                {
                    runtimeVars.Add(refVariables[i].name, refVariables[i].stateInternalNoRead);
                }
            }
        }
        
    }

    private void Start()
    {
        Fill();
    }

    public void DebugMenu()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            showDebug = !showDebug;
        }
    }

    private void OnGUI()
    {
        if (GameVarDictionary.dictionaryInstance.showDebug && GameVarDictionary.dictionaryInstance == this)
        {
            foreach (var item in runtimeVars)
            {
                GUILayout.Label($"{item.Key} : {item.Value}");
            }
        }
    }

    public int GetState(GameVariable variable)
    {
        int value;
        if(dictionaryInstance.runtimeVars.TryGetValue(variable.name, out value))
        {
            return value;
        }
        else
        {
            Debug.LogWarning($"Game Variable Missing {variable.name}");
        }
        return -1;
    }

    public void SetState(GameVariable variable, int state)
    {
        int value;
        if (dictionaryInstance.runtimeVars.TryGetValue(variable.name, out value))
        {
            dictionaryInstance.runtimeVars[variable.name] = state;
        }
        else
        {
            Debug.LogWarning($"Game Variable Missing {variable.name}");
        }
    }


}


public class CallbackInt: UnityEvent<int>
{

}