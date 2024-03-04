using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarnessController : MonoBehaviour
{
    public bool Aware { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float AwareDistance;
    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<movement>().transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        DirectionToPlayer = enemyToPlayer.normalized;

        if (enemyToPlayer.magnitude <= AwareDistance)
        {
            Aware = true;
        }
        else 
        {
            Aware = false;
        }
    }
}
