using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    private Transform cube;

    [SerializeField]
    private float moveSpeed = 4;

    [SerializeField]
    private float rotateSpeed = 4;

    [SerializeField]
    private float scaleSpeed = 4;

    private Image img;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(nameof(CubeMove));
        //StartCoroutine(nameof(CubeRotate));
        //StartCoroutine(nameof(CubeScale));

        StartCoroutine(img.ChangeColor(Color.green, 3));
        
    }

    float duration =5;
    float goalPosX = 5;
    float goalPosY = 5;
    float startTime;

    IEnumerator CubeMove()
    {

        startTime = 0;

        while (true)
        {
            startTime += Time.deltaTime;
            float t = startTime/ duration;

            cube.position = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(goalPosX, 0, 0), t);

            yield return null;

            if (t >=  1)
                break;
        }
    }

    IEnumerator CubeRotate()
    {
        
        startTime = 0;

        while (true)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;

            cube.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, goalPosY, 0), t);

            yield return null;

            if (t >= 1)
                break;
        }
    }



    IEnumerator CubeScale()
    {
        float scale = 1;

        while (true)
        {
            cube.localScale = new Vector3(scale, scale, scale);
            scale += 0.1f * scaleSpeed;

            yield return null;

            if (scale > 2.2f)
                break;
        }

        while (true)
        {
            cube.localScale = new Vector3(scale, scale, scale);
            scale -= 0.1f * scaleSpeed;

            yield return null;

            if (scale < 2)
                break;
        }
    }
}
