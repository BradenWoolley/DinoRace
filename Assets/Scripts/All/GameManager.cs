using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int playerScore = 0;

    bool isPaused = false;

    [SerializeField]UnityEvent PauseGame;

    [SerializeField] WaveSpawner[] spawners;

    private void Start()
    {
        
    }

    private void Update()
    {

    }
}
