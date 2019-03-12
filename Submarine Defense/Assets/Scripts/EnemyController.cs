using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float speed;

    public int health;

    [SerializeField]
    Sprite broken;
    [SerializeField]
    GameManager gm;

    private void Start()
    {
        gm.addEnemy();
    }

    void Update () {
        transform.Translate(new Vector3(-speed, 0));
    }

    public void hit(int damage)
    {
        health -= damage;

        if (health == 1)
            GetComponent<SpriteRenderer>().sprite = broken;

        if (health <= 0)
        {
            gm.deleteEnemy();
            Destroy(gameObject);
        }
    }
}
