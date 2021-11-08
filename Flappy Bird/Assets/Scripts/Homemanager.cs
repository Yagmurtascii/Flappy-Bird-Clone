using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Homemanager : MonoBehaviour
{
    public GameObject InfoPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void BackHome()     
    {
        SceneManager.LoadScene("HomeScene");
    }
    public void OutInfo()
    {
        InfoPanel.SetActive(false);
    }
    public void OpenInfo()
    {
        InfoPanel.SetActive(true);
    }

}
