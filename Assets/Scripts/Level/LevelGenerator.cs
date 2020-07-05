using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    int groundPool = 3;

    [SerializeField]
    GameObject ground;

    List<GameObject> groundToSpawn;

    [SerializeField]
    Vector3 spawnPosition = new Vector3(-3, 0, 0);
    [SerializeField]
    Vector3 endPosition = new Vector3(1, 0, 0);
    [SerializeField]
    Vector3 deletePoint = new Vector3(2, 0, 0);

    float posX, posY, posZ;

    //Vector3 worldZero;

    GameObject currentGround;
    GameObject oldGround;

    /// <summary>
    /// Mode will not workd in AR!! make seperate AR Mode and use Infinite runner as a seperate scene!
    /// </summary>

    void Awake()
    {
       
        posX = GameObject.Find("World").transform.position.x;
        posY = GameObject.Find("World").transform.position.y;
        posZ = GameObject.Find("World").transform.position.z;

        var world = GameObject.Find("World");

        //worldZero = new Vector3(posX, posY, posZ);


        groundToSpawn = new List<GameObject>();
        for (int i = 0; i < groundPool; i++)
        {
            GameObject temp = (GameObject)Instantiate(ground);
            temp.transform.SetParent(world.transform);
            temp.SetActive(false);
            groundToSpawn.Add(temp);
        }
    }

    void Start()
    {
        spawnPosition = new Vector3((posX - 3), posY, posZ);
        endPosition = new Vector3((posX + 1), posY, posZ);
        deletePoint = new Vector3((posX + 2), posY, posZ);

        for (int i = 0; i <1; i++)
        {
            currentGround = groundToSpawn[i];

           //spawnPosition = new Vector3((posX-3), posY, posZ);
            currentGround.transform.position = spawnPosition;

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
