using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum end { Loose, Win }
    public int enemiesRemaining;
    public PlayerController player;

    public void addEnemy()
    {
        enemiesRemaining++;
    }
    public void deleteEnemy()
    {
        enemiesRemaining--;
        if(enemiesRemaining <= 0)
        {
            finishGame(end.Win);
        }
    }

    public void finishGame(end typeofEnd)
    {
        if(typeofEnd == end.Loose)
        {
            GetComponent<goToScene>().goTo(3);
        }
        else if(typeofEnd == end.Win)
        {
            PlayerPrefs.SetInt("missilesLaunched", player.missilesLaunched);
            PlayerPrefs.SetFloat("timeTaken", Time.time - player.startTime);
            GetComponent<goToScene>().goTo(2);
        }
    }
}
