using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    public SpawnState state = SpawnState.COUNTING;

    [SerializeField] float timeBetweenWaves = 5f;
    float countDown = 2f;

    [SerializeField] List<GameObject> dinosaurs, raptors;

    [SerializeField] int raptorNumber;

    int waveIndex = 0;

    Transform spawnerPosition;

    void Start()
    {
        spawnerPosition = gameObject.transform;
        for (int i = 0; i < raptorNumber; i++)
        {
            GameObject temp = (GameObject)Instantiate(dinosaurs[0], 
                spawnerPosition.position, Quaternion.identity);
            temp.SetActive(false);
            raptors.Add(temp);
        }
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            WaveCompleted();
        }

        if (countDown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave());
                countDown = timeBetweenWaves;
            }
        }

        countDown -= Time.deltaTime;
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        countDown = timeBetweenWaves;
        SpawnWave();
    }

    IEnumerator SpawnWave()
    {
        state = SpawnState.SPAWNING;
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnDinosaur();
            yield return new WaitForSeconds(0.5f);

        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnDinosaur()
    {
        foreach(var dino in raptors)
        {
            if (!dino.activeInHierarchy)
            {
                dino.SetActive(true);
                dino.transform.position = spawnerPosition.position;
                break;
            }
        }
    }
}