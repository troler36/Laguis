using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public float Health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Dying
        if(Health <= 0)
        {
            OnDeath();
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    void OnDeath()
    { 
         Destroy(this.gameObject);        
    }
}
