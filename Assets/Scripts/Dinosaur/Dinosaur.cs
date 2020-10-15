using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    int maxHealth = 20;

    private int health = 20;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }    
    }

    public void ResetDino() => health = maxHealth;

    private void OnDisable() => ResetDino();
}
