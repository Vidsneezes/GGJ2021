using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameVariable : MonoBehaviour
{
    public GameVariable refVariable;
    public int value = -1;
    public string getMessage;

    public void ChangeState()
    {
        if (value == -1)
        {

            if (refVariable.GetState() == GameVariable.OFF)
            {
                refVariable.TurnOn();
            }
            else if (refVariable.GetState() == GameVariable.ON)
            {
                refVariable.TurnOff();
            }
        }
        else
        {
            refVariable.ChangeCustom(value);
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
