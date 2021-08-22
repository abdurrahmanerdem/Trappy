using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public Rigidbody rb;
    public Renderer cubeRenderer;
    [SerializeField] private Color startColor, endColor;
    [SerializeField] private float duration;
    private bool startChanging, isGrounded, wasGrounded;
    private float t;

    private void Awake()
    {
        wasGrounded = false;
        startChanging = false;
        t = 0f;
    }

    private void Update()
    {
        if (wasGrounded && isGrounded == false)
        {
            StartCoroutine(RemoveKinematicTimer());
            StartCoroutine(DestroyTimer());
        }

        if (startChanging)  ColorChanger();
    }

    void ColorChanger()
    {
         t += Time.deltaTime/duration;
        cubeRenderer.material.color = Color.Lerp(startColor, endColor, t);
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    IEnumerator RemoveKinematicTimer()
    {
        yield return new WaitForSeconds(0.25f);
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            startChanging = true;
            wasGrounded = true;
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player") isGrounded = false;
    } 
}
