using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTimer : MonoBehaviour
{
    public bool autoStart;
    public float time;
    public UnityEvent onTimerTock;

    private void Start()
    {
        if(autoStart)
        {
            StartTimer();
        }
    }

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
