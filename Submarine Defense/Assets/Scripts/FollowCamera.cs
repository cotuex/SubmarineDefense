using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    public bool limitPositionX;
    public bool limitPositionY;
    public Vector2 limitPositionMax;
    public Vector2 limitPositionMin;

    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if(limitPositionX)
                pos.x = Mathf.Clamp(transform.position.x, limitPositionMin.x, limitPositionMax.x);
            if(limitPositionY)
                pos.y = Mathf.Clamp(transform.position.y, limitPositionMin.y, limitPositionMax.y);

            transform.position = pos;
            
        }
    }
}
