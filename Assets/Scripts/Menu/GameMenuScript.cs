using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuScript : MonoBehaviour
{
    [Header("Windows")]

    public GameObject RestartWindow;
    public void ShowRestart()
    {
        RestartWindow.SetActive(true);
    }

    public void Restart()
    {
        SceneLoader.LoadScene("SampleScene");
    }
}
