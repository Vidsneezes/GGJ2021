using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

public class RadioFrequUI : MonoBehaviour
{
    public AudioMixer mainMixer;

    public Canvas radioCanvas;
    public Button right;
    public Button left;
    public Text stationText;
    public GameVariable knowAboutGame;

    public AudioClip[] stationsClip;
    public AudioSource mainPlayer;
    public AudioSource FreqChanger;

    int[] stations;

    int currentStation;

    public UnityEvent onCorrectStation;

    float clickDelay;

    private void Awake()
    {
      
    }

    public void LeaveRadio()
    {
        mainMixer.SetFloat("radio_volume", -80);
        mainMixer.SetFloat("soundscape_volume", 6);
        mainMixer.SetFloat("lofi_volume", -15);
        mainPlayer.Stop();
    }

    private void OnEnable()
    {
        if (stations == null || stations.Length == 0)
        {
            currentStation = 1;
            stations = new int[]
            {
            88,90,92,94,96,110
            };

            right.onClick.AddListener(NextStation);
            left.onClick.AddListener(PrevStation);
         

        }

        stationText.text = $"FM {stations[currentStation]}";

        mainMixer.SetFloat("radio_volume", 4);
        mainMixer.SetFloat("soundscape_volume", -50);
        mainMixer.SetFloat("lofi_volume", -50);
        PlayStation();
    }

    public void PlayStation()
    {
        mainPlayer.Stop();
        mainPlayer.clip = stationsClip[currentStation];
        FreqChanger.Play();
        mainPlayer.Play();
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
                if (currentStation == 5)
                {
                    onCorrectStation.Invoke();
                }
            }
            PlayStation();

            stationText.text = $"FM {stations[currentStation]}";
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
                if (currentStation == 5)
                {
                    onCorrectStation.Invoke();
                }
            }
            PlayStation();

            stationText.text = $"FM {stations[currentStation]}";

        }
    }

    void Update()
    {
        clickDelay -= Time.deltaTime;    
    }
}
