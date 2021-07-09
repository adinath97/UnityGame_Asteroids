using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    public float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
       transform.position += transform.up*moveSpeed*Time.deltaTime;
    }
}
