using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    int i = 0;
    
    private void Start()
    {
        Spawner();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log(collision.name);
            
            i++;
            if (i<5)
            {
                Debug.Log("spawner"+i);
                Spawner();
            }
            else
            {
                gameObject.SetActive(false);
            }
                
            
            
        }
    }
    private void Spawner()
    {
            
            Vector3 newPos = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0); // It adjusted according to area size.
            this.transform.position = newPos;
        
       
    }
}
