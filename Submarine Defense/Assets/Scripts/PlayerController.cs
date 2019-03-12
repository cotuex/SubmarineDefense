using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform CannonPlace;
    public GameObject Missile;

    [SerializeField]
    private float amplitudeMovement = 1;
    [SerializeField]
    private float frequencyMovement = 1;

    [SerializeField]
    GameObject insultText;
    public GameManager gm;

    public int missilesLaunched;
    FollowCamera followCamera;
    public float startTime;
    private float startY;

    public bool missileAvailable = true;

    private void Start()
    {
        startTime = Time.time;
        followCamera = Camera.main.GetComponent<FollowCamera>();
        startY = transform.position.y;
    }

    void Update()
    {
        //Move Player
        transform.position = new Vector3(0, Mathf.Sin((startTime - Time.time) * frequencyMovement) * amplitudeMovement + startY);

        //Check if missile is available to see if it's necesary to check if spacebar is pressed
        if (!missileAvailable)
            return;

        //Fire Missile
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            fireMissile();
    }

    private void fireMissile()
    {
        GameObject go = Instantiate(Missile);
        go.transform.position = CannonPlace.transform.position;
        missileAvailable = false;

        missilesLaunched++;

        followCamera.target = go;
    }

    public void showInsultText()
    {
        GameObject go = Instantiate(insultText, transform, true);
        go.transform.localPosition = new Vector3(1, 1.5f);
        Destroy(go.gameObject, .8f);
    }
}
