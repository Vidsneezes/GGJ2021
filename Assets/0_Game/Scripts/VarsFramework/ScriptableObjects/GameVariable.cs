using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Game Variable", menuName ="Game/Game Variable")]
public class GameVariable : ScriptableObject
{
    public const int OFF = 0;
    public const int ON = 1;


    public int state;

    public void TurnOn()
    {
        if(GameVarDictionary.dictionaryInstance != null)
        {
            GameVarDictionary.dictionaryInstance.SetState(this,ON);
        }
    }

    public void TurnOff()
    {
        if (GameVarDictionary.dictionaryInstance != null)
        {
            GameVarDictionary.dictionaryInstance.SetState(this,ON);
        }
    }

    public int GetState()
    {
        if(GameVarDictionary.dictionaryInstance != null)
        {
            return GameVarDictionary.dictionaryInstance.GetState(this);
        }
        else
        {
            Debug.LogError($"Game Variable Missing {name}");
            return -1;
        }
    }

}
