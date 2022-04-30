using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
   public float maxAcceleration;
    public float maxAngularAcceleration;
    public float drag;
    private Rigidbody rb;
    private Steering[] steerings;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;

    }

     void FixedUpdate()
    {
        Vector3 accelaration = Vector3.zero;
        float rotation = 0;
        foreach(Steering behavior in steerings)
        {
           SteeringData steeringData = behavior.GetSteering(this);
            accelaration += steeringData.linear * behavior.weigth;
            rotation += steeringData.angular * behavior.weigth;

        }
        if(accelaration.magnitude > maxAcceleration)
        {
            accelaration.Normalize();
            accelaration *= maxAcceleration;
        }

        /*if(rotation > maxAngularAcceleration)
        {
            rotation = maxAngularAcceleration;
        }*/

        rb.AddForce(accelaration);
        if(rotation != 0)
        {
            rb.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
}
