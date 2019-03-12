using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public void DestroyThis()
    {
        FollowCamera followCamera = Camera.main.GetComponent<FollowCamera>();

        //set camera
        if (followCamera.target.name == gameObject.name)
        {
            followCamera.target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().gameObject;
        }
        Destroy(gameObject);
    }
}
