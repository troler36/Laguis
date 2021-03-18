using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Spear : MonoBehaviour
{
    public int damage = 30;
    public Transform attackPoint;
    public float range = 0.5f;
    public LayerMask enemyMask;
    public Animator attackAnim;
    // Start is called before the first frame update
    void Start()
    {
        attackAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackAnim == null)
        {
            attackAnim = null;
        }
        if (Input.GetButtonDown("Fire1"))
        {

            
            attackAnim.SetTrigger("Kick");
            Attack();
            

        }
    }

    void Attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyMask);
        
        foreach(Collider2D enemy in hitEnemies)
        {

            Debug.Log(enemy.name);
            enemy.GetComponent<HealthEnemy>().TakeDamage(damage);
            Debug.Log(enemy.GetComponent<HealthEnemy>().Health);

        }

        

    }

    void OnDrawGizmosSelected()
    {

        if(attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
