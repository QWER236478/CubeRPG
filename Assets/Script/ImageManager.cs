using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField]
    private Image uilmage;
    [SerializeField]
    private Image uilmage2;
    [SerializeField]
    private Image uilmage3;

    [SerializeField]
    private Image uilmage4;
    [SerializeField]
    private Image uilmage5;

    [SerializeField] private Color color;
    [SerializeField] private float duration;

    void Start()
    {
        StartCoroutine(ChangeColor(uilmage, Color.red, 2));
        StartCoroutine(ChangeColor(uilmage2, Color.blue, 2));
        StartCoroutine(ChangeColor(uilmage3, Color.green, 2));

        StartCoroutine(Fade(uilmage4, 0, 2));
        StartCoroutine(Fade(uilmage5, 1, 2));
    }

    IEnumerator ChangeColor (Image img, Color changeColor, float duration)
    {
        float startTime = 0;
        Color startColor = img.color;

        while (startTime < duration)
        {
            startTime += Time.deltaTime;
            float t = startTime/duration;

            img.color = Color.Lerp(startColor, changeColor, t);
            yield return null;
        }        
    }

    IEnumerator Fade(Image img, float fade, float duration)
    {
        float startTime = 0;
        Color startColor = img.color;
        Color fadeColor = img.color;
        fadeColor.a = fade;

        while (startTime < duration)
        {
            startTime += Time.deltaTime;
            float t = startTime/duration;

            img.color = Color.Lerp (startColor, fadeColor, t);
            yield return null;
        }

        yield return null;
    }
}
