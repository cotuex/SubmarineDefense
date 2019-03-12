using UnityEngine;

public class MissileController : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedOfRotation;

    [SerializeField]
    GameObject Explotion;

    public bool inControlRange = true;

    PlayerController player;
    FollowCamera followCamera;
    Rigidbody2D rb;


	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        followCamera = Camera.main.GetComponent<FollowCamera>();
    }

    void FixedUpdate()
    {
        if(inControlRange)
        {
            //Missile Rotation
            if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
                addRotation(speedOfRotation);
            else
                addRotation(-speedOfRotation);
        }

        //Missile Movement
        transform.Translate(new Vector3(speed, 0));
    }

    private void addRotation(float rot)
    {
        rb.MoveRotation(rb.rotation + rot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = Instantiate(Explotion);
        go.transform.position = transform.position;
        player.missileAvailable = true;

        //set camera
        followCamera.target = go;

        Collider2D col = collision.collider;

        switch (col.tag)
        {
            case "Enemy":
                col.gameObject.GetComponent<EnemyController>().hit(1);
                break;

            case "Obstacle":
                Destroy(col.gameObject);
                break;

            case "Ally":
                player.gm.finishGame(GameManager.end.Loose);
                break;

            case "Player":
                player.showInsultText();
                break;
        }
        Destroy(gameObject);
    }
}
