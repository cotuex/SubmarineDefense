using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySky : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Missile")
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10), ForceMode2D.Impulse);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Missile")
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }

}
