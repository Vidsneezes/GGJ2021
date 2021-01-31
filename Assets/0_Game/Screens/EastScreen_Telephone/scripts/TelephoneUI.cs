using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TelephoneUI : MonoBehaviour
{
    public string magicNumber;
    public string secretNumber;
    public string currentNumber;

    public UnityEvent onCallSuccess;
    public GameVariable secretEnd;

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
        if (currentNumber == magicNumber)
        {
            onCallSuccess.Invoke();
        } else if (currentNumber == secretNumber) {
            onCallSuccess.Invoke();
            secretEnd.ChangeCustom(1);
        } else
        {
            onCallFailed.Invoke();
        }
    }

}
