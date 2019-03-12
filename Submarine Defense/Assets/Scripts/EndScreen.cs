using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {
    public Text timeText;
    public Text highscoreTimeText;
    public Text missilesText;
    public Text highscoreMissilesText;

    private int timeTaken;
    private int missilesLaunched;
    private int hMissiles;
    private int hTime;

    // Use this for initialization
    void Start () {
        timeTaken = Mathf.FloorToInt(PlayerPrefs.GetFloat("timeTaken"));
        missilesLaunched = PlayerPrefs.GetInt("missilesLaunched");


        timeText.text += timeTaken.ToString();
        missilesText.text += missilesLaunched.ToString();

        //if there are highscores
        if(PlayerPrefs.HasKey("highscoreMissiles") && PlayerPrefs.HasKey("highscoreTime"))
        {
            hMissiles = PlayerPrefs.GetInt("highscoreMissiles");
            hTime = Mathf.FloorToInt(PlayerPrefs.GetInt("highscoreTime"));

            if(timeTaken < hTime)
            {
                hTime = timeTaken;
                PlayerPrefs.SetInt("highscoreTime",hTime);
            }
            if(missilesLaunched < hMissiles)
            {
                hMissiles = missilesLaunched;
                PlayerPrefs.SetInt("highscoreMissiles", hMissiles);
            }

            highscoreTimeText.text += hTime.ToString();
            highscoreMissilesText.text += hMissiles.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("highscoreTime", timeTaken);
            PlayerPrefs.SetInt("highscoreMissiles", missilesLaunched);
            highscoreTimeText.text += timeTaken.ToString();
            highscoreMissilesText.text += missilesLaunched.ToString();
        }

    }
}
