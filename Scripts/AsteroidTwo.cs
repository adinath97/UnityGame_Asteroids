using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTwo : MonoBehaviour
{
    [SerializeField] GameObject subAsteroidPrefab;
    [SerializeField] GameObject deathExplosion;
    private bool divided = false;

    void Start()
    {
        divided = false;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "EnemyBullet") && !divided) {
            if(other.gameObject.tag == "PlayerBullet") {
                ScoreManager.score += 100f;
                ScoreManager.diffScore += 100f;
            }
            Destroy(other.gameObject);
            divided = true;
            GameObject deathExplosionInstance = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
            GameObject subAsteroidOne = Instantiate(subAsteroidPrefab,this.transform.position,Quaternion.identity) as GameObject;
            subAsteroidOne.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
            GameObject subAsteroidTwo = Instantiate(subAsteroidPrefab,this.transform.position,Quaternion.identity) as GameObject;
            subAsteroidTwo.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
            Destroy(this.gameObject);
        }
    }
}
