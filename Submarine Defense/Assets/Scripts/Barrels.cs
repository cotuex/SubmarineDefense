using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour {

    [SerializeField]
    private float amplitudeMovement = 1;
    [SerializeField]
    private float frequencyMovement = 1;
    public Sprite[] barrelsSprite;
    

    private float startY;
    private float startTime;

    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = barrelsSprite[Random.Range(0, (int)barrelsSprite.Length)];
        transform.Rotate(new Vector3(0,0,Random.Range(-10f, 10f)));
        startTime = Time.time + Random.value * 3;
        startY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, Mathf.Sin((startTime - Time.time) * frequencyMovement) * amplitudeMovement + startY);
    }
}
