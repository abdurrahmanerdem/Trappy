using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterManagerwithourCursor : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private float MoveSpeed,turnSpeed;
    private bool canMove = true;
    private float sliderValue;
    public bool GameOver,LevelFinish;

    private void Update()
    {
        sliderValue = slider.value;
    }

    private void FixedUpdate()
    {
        if (canMove) Move();
    }

    private void Move()
    {
        transform.position += MoveSpeed * Time.deltaTime * Vector3.forward;
        SliderMovement();
    }

    void SliderMovement()
    {
        if (sliderValue > transform.position.x)
            transform.position += turnSpeed * Time.deltaTime * Vector3.right;
        if (sliderValue < transform.position.x)
            transform.position += turnSpeed * Time.deltaTime * Vector3.left;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            canMove = false;
            GameOver = true;
        }
        if (other.gameObject.tag == "Ground")
        {
            canMove = false;
            GameOver = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "trap") canMove = false;

        if (collision.gameObject.tag == "FinishLine")
        {
            LevelFinish = true;
            StartCoroutine(ForFinish());
        }
    }

    IEnumerator ForFinish()
    {
        yield return new WaitForSeconds(1.5f);
        canMove = false;
    }
}
