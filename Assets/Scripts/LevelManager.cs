using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int playerHealth;
    public int health;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("Do not destroy");
        }
        else
        {
            print("Do destroy");
            Destroy(gameObject);
        }
    }
    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
    }
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
}
