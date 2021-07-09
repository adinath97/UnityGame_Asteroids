using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidZero : MonoBehaviour
{
    [SerializeField] GameObject deathExplosion;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "EnemyBullet") {
            if(other.gameObject.tag == "PlayerBullet") {
                ScoreManager.score += 100f;
                ScoreManager.diffScore += 100f;
            }
            GameObject deathExplosionInstance = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
