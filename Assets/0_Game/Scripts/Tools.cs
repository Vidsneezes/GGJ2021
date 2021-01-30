using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tools : MonoBehaviour
{
    public void SwitchScene(string destination)
    {
        SceneManager.LoadScene(destination);
    }

    public void QuiGame()
    {
        Application.Quit();
    }

    public void DestroyObject(GameObject objm)
    {
        GameObject.Destroy(objm);
    }

}
