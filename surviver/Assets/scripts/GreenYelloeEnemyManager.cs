using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenYelloeEnemyManager : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float MoveSpeed, smashSpeed;
    private bool canMove, canSmash;

    private void Awake()
    {
        canMove = true;
        canSmash = false;
    }

    private void FixedUpdate()
    {
        if (canMove) Move();
        if (canSmash) Smash();
    }

    private void Smash()
    {
        transform.position += smashSpeed * Time.deltaTime * transform.forward;
        transform.LookAt(player);
    }

    private void Move()
    {
        transform.position += MoveSpeed * Time.deltaTime * Vector3.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = false;
            canSmash = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") canSmash = false;
        if (collision.gameObject.tag == "FinishLine") Destroy(gameObject);
    }
}
