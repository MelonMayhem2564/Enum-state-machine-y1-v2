using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public TMP_Text buttonText;
    public GameObject Player;
    public ScoreCounter targetScript;

    public void ButtonMethodRespawn()
    {
        buttonText.text = "Respawn";
        Player.transform.position = new Vector3(8, 1, -3);
    }
    public void ButtonMethodLevel1()
    { 
        SceneManager.LoadScene("Level 1");
        AudioManager.instance.PlayClip(3);
    }
    public void ButtonMethodLevel2()
    {
        SceneManager.LoadScene("Level 2");
        AudioManager.instance.PlayClip(3);
    }
    public void ButtonMethodQuit()
    {
        SceneManager.LoadScene("Front end");
        AudioManager.instance.PlayClip(4);
    }
    public void ButtonMethodQuitGame()
    {
        Application.Quit();
    }
    public void IncreasingScore()
    {
        targetScript.GainingPoints();
    }
    public void DecreasingScore()
    {
        targetScript.LosingPoints();
    }
}
