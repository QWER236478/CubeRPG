using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score;

    [Header("플레이어")]
    [SerializeField]
    private GameObject PlayerPrefabs;

    [Header("적")]
    [SerializeField]
    private int MonsterSpawnCount = 10;
    [SerializeField]
    private GameObject EnemyPrefabs;
    [SerializeField]
    private float spawnAreaWidth = 40;
    [SerializeField]
    private float spawnAreaHeight = 40;
    [SerializeField]
    private float spawnAreaMargin = 2;

    private float spawnAreaHalfWidth = 40;
    private float spawnAreaHalfHeight = 2;

    public float SpawnAreaHalfWidth => spawnAreaHalfWidth;
    public float SpawnAreaHalfHeight => spawnAreaHalfHeight;

    private GameObject Player;
    private List<GameObject> Enemies = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnPlayer();
        SpawnEnemy();
    }

    void SpawnPlayer()
    {
        Player = Instantiate(PlayerPrefabs);
    }

    void SpawnEnemy()
    {
        spawnAreaHalfWidth = (spawnAreaWidth / 2) - spawnAreaMargin;
        spawnAreaHalfHeight = (spawnAreaHeight / 2) - spawnAreaMargin;

        for (int i = 0; i < MonsterSpawnCount; i++)
        {
            float spawnPosX = Random.Range(-spawnAreaHalfWidth, spawnAreaHalfWidth);
            float spawnPosZ = Random.Range(-spawnAreaHalfHeight, spawnAreaHalfHeight);

            float spawnRotY = Random.Range(0, 360);

            Vector3 spawnPos = new Vector3(spawnPosX, EnemyPrefabs.transform.position.y, spawnPosZ);
            Quaternion spawnRot = Quaternion.Euler(0, spawnRotY, 0);

            GameObject enemy = Instantiate(EnemyPrefabs, spawnPos, spawnRot);
            Enemies.Add(enemy);
        }
    }
}
