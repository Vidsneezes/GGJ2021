using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTimer : MonoBehaviour
{
    public float time;
    public UnityEvent onTimerTock;

    public void StartTimer()
    {
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        yield return new WaitForSeconds(time);
        onTimerTock.Invoke();
    }
}
