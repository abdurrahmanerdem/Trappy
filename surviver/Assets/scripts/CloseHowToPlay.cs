using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHowToPlay : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ClosePanel());
    }
    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }
}
