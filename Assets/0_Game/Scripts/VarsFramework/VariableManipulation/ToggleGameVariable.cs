using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameVariable : MonoBehaviour
{
    public GameVariable refVariable;
    public string getMessage;

    public void ChangeState()
    {
        if(refVariable.GetState() == GameVariable.OFF)
        {
            refVariable.TurnOn();
        }
        else if(refVariable.GetState() == GameVariable.ON)
        {
            refVariable.TurnOff();
        }

        if(getMessage.Length > 0)
        {
            GameGlue.TryShowMessage(getMessage);
        }
    }

    public void HideWorldObject()
    {
        gameObject.SetActive(false);
    }

   
}
