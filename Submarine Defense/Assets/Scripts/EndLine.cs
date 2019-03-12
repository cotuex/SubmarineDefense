using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.finishGame(GameManager.end.Loose);
        }
    }
}
