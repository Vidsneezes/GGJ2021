using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CheckGameVariable : MonoBehaviour
{
    public GameVariable refVariable;
    public string failedMessage;

    public int conditionNeed;

    public UnityEvent onConditionMet;
    public UnityEvent onConditionFailed;

    public bool autoStart;

    public void OnLookedAt()
    {
        if (autoStart)
        {
            TryCondition();
        }
    }

    public void TryCondition()
    {
        if (refVariable.GetState() == conditionNeed)
        {
            onConditionMet.Invoke();
        }
        else
        {
            onConditionFailed.Invoke();
            if (failedMessage.Length > 0)
            {
                GameGlue.TryShowMessage(failedMessage);
            }
        }
    }


}
