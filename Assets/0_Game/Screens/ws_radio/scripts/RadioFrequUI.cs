using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RadioFrequUI : MonoBehaviour
{
    public Canvas radioCanvas;
    public Button right;
    public Button left;
    public Text stationText;
    public GameVariable knowAboutGame;

    int[] stations;
    int currentStation;

    public UnityEvent onCorrectStation;

    float clickDelay;

    private void Awake()
    {
      
    }

    private void OnEnable()
    {
        if (stations == null || stations.Length == 0)
        {
            currentStation = 1;
            stations = new int[]
            {
            70,80,90,94,99,100,110
            };

            right.onClick.AddListener(NextStation);
            left.onClick.AddListener(PrevStation);
            stationText.text = $"mz:{stations[currentStation]}";
        }
    }

    public void OpenRadio()
    {
        radioCanvas.gameObject.SetActive(true);
    }

    public void NextStation()
    {
        if (clickDelay < 0)
        {
            clickDelay = 0.3f;
            currentStation = Mathf.Clamp(currentStation + 1, 0, stations.Length -1);
            if (knowAboutGame.GetState() == GameVariable.OFF)
            {
                if (currentStation == 6)
                {
                    onCorrectStation.Invoke();
                }
            }
            stationText.text = $"mz:{stations[currentStation]}";
        }
    }

    public void PrevStation()
    {
        if (clickDelay < 0)
        {
            clickDelay = 0.3f;
            currentStation = Mathf.Clamp(currentStation - 1, 0, stations.Length - 1);
            if (knowAboutGame.GetState() == GameVariable.OFF)
            {
                if (currentStation == 6)
                {
                    onCorrectStation.Invoke();
                }
            }
            stationText.text = $"mz:{stations[currentStation]}";

        }
    }

    void Update()
    {
        clickDelay -= Time.deltaTime;    
    }
}
