using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stat")]
    public int curHP,
    maxHP,
    ScoreToGive;

    [Header("Movement")]
    public float moveSpeed,
    attackRange,
    yPathOffset;
    
    private List<Vector3> path;

    private Weapon weapon;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //gather components 
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerControler>().GameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHP = maxHP;
    }

    void UpdatePath()
    {
        // calculate a path to the target 
        NavMeshPath navMeshPath = new NavMeshPath();

        navMeshPath.CalculatePath(transform.position, target.transform.position, navMeshPath.AllAreas, navMesh);

        //SaVe calculated
        path = navMeshPath.corners.ToList();

    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;
        // Move towards closest path
        transform.position = Vector3.MoveToward(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0));
            path.RemoveAt(0);
    }


    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Die();
    }

    void Die()
    {
        Destroy(GameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;

        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist <= attackRange)
        {
            if(Weapon.CanShoot())
                weapon.Shoot();     
        }
    
        else
        {
            ChaseTarget();
        }
    }

}
