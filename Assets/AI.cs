using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent Self;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Self = gameObject.GetComponent<NavMeshAgent>();
        Self.speed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Self.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
