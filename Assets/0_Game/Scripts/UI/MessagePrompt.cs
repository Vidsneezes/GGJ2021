using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagePrompt : MonoBehaviour
{
    public Text textDisplay;

    public void ShowMessage(string text)
    {
        textDisplay.text = text;
        StartCoroutine(DisplayMessage());
    }

    IEnumerator DisplayMessage(float aliveTime = 1f)
    {
        yield return new WaitForSeconds(aliveTime);
        GameObject.Destroy(gameObject);
    }
}
