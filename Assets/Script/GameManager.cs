using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;

    Coroutine curCoroutine;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(nameof(CubeFalse), 2);

        StartCoroutine(CubeFalse(2, 3));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CubeFalse(float delay1, float delay2)
    {
        yield return new WaitForSeconds(delay1);

        cube1.SetActive(false);

        yield return new WaitForSeconds(delay2);

        cube2.SetActive(false);
    }

    IEnumerator CubeTure()
    {
        yield return new WaitForSeconds(2);

        cube1.SetActive(true);

        yield return new WaitForSeconds(3);

        cube2.SetActive(true);
    }

    public void Stop()
    {
        StopCoroutine(curCoroutine);

        StopAllCoroutines();
    }
}
