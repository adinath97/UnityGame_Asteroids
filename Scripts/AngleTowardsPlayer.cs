using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTowardsPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float correctionFactor = 90f;
    Rigidbody2D Rb;
    public static bool angleEnemy;
    public float randX,randY;

    
    // Start is called before the first frame update
    void Start()
    {
        Rb = this.GetComponent<Rigidbody2D>();
        angleEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(angleEnemy) {
            Vector3 direction = player.position - this.transform.position;
            float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg;
            Rb.rotation = -angle + 180f;
        }
    }
}
