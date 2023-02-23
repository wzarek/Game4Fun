using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    public void Damage(int amountOfDamege)
    {

        health = health - amountOfDamege;
         Debug.Log($"Current health: {health}");
        if (health < 0)
        {
            Debug.LogWarning($"Current health: {health}");
            health = 0;
        }

        if (health == 0)
        {
            Destroy(gameObject);

        }

    }
}
