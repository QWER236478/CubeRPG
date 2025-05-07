using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveDistanceMin = 2;

    [SerializeField]
    private float moveDistanceMax = 4;

    [SerializeField]
    private float moveDelay = 1;

    [SerializeField]
    private float moveSpeed = 1.5f;

    Vector3 pos;

    float spawnAreaHalfWidth;
    float spawnAreaHalfHeight; 

    void Start()
    {
        spawnAreaHalfWidth = GameManager.Instance.SpawnAreaHalfWidth;
        spawnAreaHalfHeight = GameManager.Instance.SpawnAreaHalfHeight;

        StartCoroutine(nameof(MoveEnemy));
    }

    void Update()
    {
        
    }

    IEnumerator MoveEnemy()
    {
        float randomMoveDistance = Random.Range(moveDistanceMin, moveDistanceMax);
        Vector2 randomCircle = Random.insideUnitCircle * randomMoveDistance;
        
        pos = transform.position;
        pos.x += randomCircle.x;
        pos.z += randomCircle.y;

        pos.x = Mathf.Clamp(pos.x, -spawnAreaHalfWidth, spawnAreaHalfWidth);
        pos.z = Mathf.Clamp(pos.y, -spawnAreaHalfHeight, spawnAreaHalfHeight);

        float duration = randomMoveDistance / moveSpeed;
        StartCoroutine(transform.Move(pos, duration));

        yield return new WaitForSeconds(randomMoveDistance + moveDelay);
    }

    void RotateEnemy()
    {
        Vector3 dir = (pos - transform.position).normalized;
        if (dir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 70 * Time.deltaTime);
        }
    }
}

