using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacles : MonoBehaviour {

    public float[] positionsX;
    public float startPositionX;
    public int quantity;
    public float distanceX = 40;
    
    private float offsetY = -5.96f;
    public GameObject[] startParts;
    public GameObject[] normalParts;

	// Use this for initialization
	void Start () {
        GameObject go = Instantiate(startParts[Random.Range(0, startParts.Length)], transform);
        go.transform.localPosition = new Vector3(positionsX[0], offsetY);

        for(int i = 1; i < positionsX.Length; i++)
        {
            go = Instantiate(normalParts[Random.Range(0, normalParts.Length)], transform);
            go.transform.localPosition = new Vector3(positionsX[i], offsetY);
        }
	}
}
