using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public TMP_Text buttonText;
    public GameObject Player;

    public void ButtonMethod()
    {
        buttonText.text = "Respawn";
        Player.transform.position = new Vector3(8, 1, -3);
    }
}
