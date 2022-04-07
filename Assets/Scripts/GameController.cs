using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int deaths = 0;
    public static GameController instance;
    public Text scoreText;
    private string nextLevelName;

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

        if ( deaths > 5 )
        {
            scoreText.text = "Mortes: " + deaths +" hahahaha";
        }
    }

    public void nextLevel()
    {

        switch( SceneManager.GetActiveScene().name )
        {
            case "Level1": nextLevelName = "Level2"; break;
            case "Level2": nextLevelName = "Level3"; break;
        }

        SceneManager.LoadScene(nextLevelName);
    }
}
