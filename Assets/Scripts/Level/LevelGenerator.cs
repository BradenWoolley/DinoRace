using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    int groundPool = 3;

    [SerializeField]
    GameObject ground;

    List<GameObject> groundToSpawn;

    [SerializeField]
    Vector3 spawnPosition = new Vector3(-45, 0, 0);
    [SerializeField]
    Vector3 endPosition = new Vector3(30, 0, 0);
    [SerializeField]
    Vector3 deletePoint = new Vector3(60, 0, 0);

    GameObject currentGround;
    GameObject oldGround;

    void Awake()
    {

        groundToSpawn = new List<GameObject>();
        for (int i = 0; i < groundPool; i++)
        {
            //Instantiate(ground, spawnPosition, Quaternion.identity);
            GameObject temp = (GameObject)Instantiate(ground);
            temp.SetActive(false);
            groundToSpawn.Add(temp);
        }
    }

    void Start()
    {
        for(int i = 0; i <1; i++)
        {
            currentGround = groundToSpawn[i];
            currentGround.transform.position = new Vector3(-45,0,0);
            groundToSpawn[i].SetActive(true);
        }
    }

    void Update()
    {

        if(currentGround.transform.position.x >= endPosition.x)
        {
            foreach (var newGround in groundToSpawn)
            {
                if (!newGround.activeInHierarchy)
                {
                    oldGround = currentGround;
                    newGround.transform.position = spawnPosition;
                    newGround.SetActive(true);
                    currentGround = newGround;
                    break;
                }
            }
        }

        if (oldGround != null)
        {
            if(oldGround.transform.position.x >= deletePoint.x)
            {
                oldGround.SetActive(false);
            }        
        }      
    }
}
