using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class TransformExtensionLibrary 
{

    public static IEnumerator Move(this Transform transform, Vector3 pos, float duration)
    {

        float startTime = 0;
        Vector3 startPos = transform.position;

        while (true)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;

            transform.position = Vector3.Lerp(startPos, pos, t);

            yield return null;
        }
    }

}
