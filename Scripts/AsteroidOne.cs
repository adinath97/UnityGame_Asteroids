using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidOne : MonoBehaviour
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
            subAsteroidOne.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
            GameObject subAsteroidTwo = Instantiate(subAsteroidPrefab,this.transform.position,Quaternion.identity) as GameObject;
            subAsteroidTwo.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
            Destroy(this.gameObject);
        }
    }
}
