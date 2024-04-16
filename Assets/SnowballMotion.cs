using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMotion : MonoBehaviour
{
    public float launchAngle = 50f;
    public float launchSpeed = 12f;
    private Vector3 targetPosition;
    private float gravity;
    
    // Start is called before the first frame update
    void Start()
    {
        gravity = Physics.gravity.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TravelTowards(Vector3 target)
    {
        targetPosition = target;

        Vector3 direction = targetPosition - this.transform.position;
        direction.y = 0f;
        //distance to target
        float distance = direction.magnitude;
        //initial velocity upon instantiation
        float initialVelocity = launchSpeed;
        float angle = launchAngle * Mathf.Deg2Rad;
        float yOffset = target.y - transform.position.y;
        //required velocity components
        float initialVelocityHorizontal = initialVelocity * Mathf.Cos(angle);
        float initialVelocityVertical = initialVelocity * Mathf.Sin(angle);

        float time = distance / initialVelocityHorizontal ;

        float verticalVelocity = (yOffset * 0.5f * gravity * Mathf.Pow(time, 2)) / time;

        Vector3 launchVelocity = direction.normalized * initialVelocityHorizontal;
        launchVelocity.y = verticalVelocity;
        
        //applying the caclculated velocity to the rigidbody to move the snowball
        GetComponent<Rigidbody>().velocity = launchVelocity;
    }
}
