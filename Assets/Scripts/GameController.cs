using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int deaths = 0;
    public static GameController instance;
    public Text scoreText;

    void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
        else if ( instance != this )
        {
            Destroy(gameObject);
        }
    }


    public void increaseDeath()
    {
        deaths++;
        scoreText.text = "Mortes: " + deaths;
    }
}
