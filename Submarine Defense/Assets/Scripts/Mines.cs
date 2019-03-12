using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour {

    [SerializeField]
    private float ampMoveX = 1;
    [SerializeField]
    private float frqMoveX = 1;
    [SerializeField]
    private float ampMoveY = 1;
    [SerializeField]
    private float frqMoveY = 1;
    public Sprite[] minesSprite;

    private float startX;
    private float startY;
    private float startTime;
    Rigidbody2D rb;

    void Start()
    {
        startTime = Time.time + Random.value * 3;
        startX = transform.position.x;
        startY = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = minesSprite[Random.Range(0, (int)minesSprite.Length)];
    }

    void Update()
    {
        rb.position = new Vector3(Mathf.Sin((startTime - Time.time) * frqMoveX) * ampMoveX + startX, Mathf.Sin((startTime - Time.time) * frqMoveY) * ampMoveY + startY);
    }

}
