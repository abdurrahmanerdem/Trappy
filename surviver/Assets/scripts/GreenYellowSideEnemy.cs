using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenYellowSideEnemy : MonoBehaviour
{
    public Transform[] Spots;
    public Transform player;
    [SerializeField] private float MoveSpeed, smashSpeed,waitForSec;
    private int randomspot;
    private float dist;
    public bool canPatrol,canForwardMove,canSmash;

    private void Start()
    {
        canPatrol = false;
        canForwardMove = false;
        canSmash = false;
        randomspot = Random.Range(0, Spots.Length - 1);
        transform.LookAt(Spots[randomspot].position);
        StartCoroutine(StartToMoveTimer());
    }

    private void Update()
    {
        DistanceMeasurer();
    }

    private void FixedUpdate()
    {
        if (canPatrol) Patrolling();
        if (canForwardMove) ForwardMove();
        if (canSmash) Smash();
    }

    private void DistanceMeasurer()
    {
        dist = Vector3.Distance(transform.position, Spots[randomspot].position);

        if (dist < 0.5f)
        {
            canPatrol = false;
            canForwardMove = true;
        }
    }

    private void Patrolling()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        transform.LookAt(Spots[randomspot].position);

    }

    void ForwardMove()
    {
        transform.position += MoveSpeed * Time.deltaTime * Vector3.forward;
    }

    private void Smash()
    {
        transform.position += smashSpeed * Time.deltaTime * transform.forward;
        transform.LookAt(player);
    }

    IEnumerator StartToMoveTimer()
    {
        yield return new WaitForSeconds(waitForSec);
        canPatrol = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canForwardMove = false;
            canSmash = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") canSmash = false;
        if (collision.gameObject.tag == "FinishLine") Destroy(gameObject);
    }
}
