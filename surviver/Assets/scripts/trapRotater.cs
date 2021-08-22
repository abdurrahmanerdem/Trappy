using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRotater : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]private Vector3 turnSpeed;

    private void FixedUpdate()
    {
        Rotater();
    }

    private void Rotater()
    {
        Quaternion deltaRotation = Quaternion.Euler(turnSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
