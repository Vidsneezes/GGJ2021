using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TelephoneUI : MonoBehaviour
{
    public string magicNumber;
    public string currentNumber;

    public UnityEvent onCallSuccess;
    public UnityEvent onCallFailed;

    public Text numberText;

    public void EnterNumber(int number)
    {
        if(currentNumber.Length < 8)
        {
            currentNumber += number.ToString();
            numberText.text = currentNumber;
        }
    }

    public void ClearNumber()
    {
        currentNumber = "";
        numberText.text = currentNumber;
    }

    public void Call()
    {
        if(currentNumber == magicNumber)
        {
            onCallSuccess.Invoke();
        }else
        {
            onCallFailed.Invoke();
        }
    }

}
