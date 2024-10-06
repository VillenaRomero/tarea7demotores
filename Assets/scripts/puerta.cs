using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class puerta : MonoBehaviour
{
    [SerializeField] private Color currentColor;
    [SerializeField] private Color targetColor;
    [SerializeField] private Color startColor;

    private IEnumerator FadeExit()
    {
        for (float alpha = 1f; alpha >= 0; alpha -= 0.5f)
        {
            currentColor.a = alpha;
            yield return new WaitForSeconds(0.2f);
        }
    }
    private IEnumerator FadeEnter()
    {;
        for (float alpha = 0f; alpha >= 0; alpha -= 0.5f)
        {
            currentColor.a = alpha;
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeEnter());
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(FadeExit());
    }
}
