using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="Game Variable", menuName ="Game/Game Variable")]
public class GameVariable : ScriptableObject
{
    public const int OFF = 0;
    public const int ON = 1;

    //DO NOT READ THIS VALUE, USE GetState or STATE INSTEAD
    public int stateInternalNoRead;
    public CallbackInt onStateChange;


    public int STATE
    {
        get
        {
            return GetState();
        }
    }

    public void TurnOn()
    {
        if(GameVarDictionary.dictionaryInstance != null)
        {
            GameVarDictionary.dictionaryInstance.SetState(this,ON);
            if(onStateChange != null)
            {
                onStateChange.Invoke(ON);
            }
        }
    }

    public void TurnOff()
    {
        if (GameVarDictionary.dictionaryInstance != null)
        {
            GameVarDictionary.dictionaryInstance.SetState(this,OFF);
            if (onStateChange != null)
            {
                onStateChange.Invoke(OFF);
            }
        }
    }

    public void ChangeCustom(int value)
    {
        if (GameVarDictionary.dictionaryInstance != null)
        {
            GameVarDictionary.dictionaryInstance.SetState(this, value);
            if (onStateChange != null)
            {
                onStateChange.Invoke(value);
            }
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
