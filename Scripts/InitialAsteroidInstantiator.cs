using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialAsteroidInstantiator : MonoBehaviour
{
    public BoxCollider2D gridArea;
    [SerializeField] List<GameObject> asteroidPrefabs;
    [SerializeField] LayerMask gameLayer;
    private int numberOfInitialAsteroids;

    void Start()
    {
        numberOfInitialAsteroids = Mathf.RoundToInt(Random.Range(15f,25f));
        int x = 0;
        for(int i = 0; i < numberOfInitialAsteroids; i++) {
            RandomPosition();
        }
    }

    private void RandomPosition() {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x,bounds.max.x);
        float y = Random.Range(bounds.min.y,bounds.max.y);
        Vector3 pos = new Vector3(Mathf.RoundToInt(x),Mathf.RoundToInt(y),0);
        Collider2D[] intersections = Physics2D.OverlapCircleAll(new Vector2(pos.x,pos.y),3f,gameLayer);
        if(intersections.Length == 0) {
            int rand1 = Random.Range(0,asteroidPrefabs.Count);
            GameObject asteroidInstance = Instantiate(asteroidPrefabs[rand1],pos,Quaternion.identity);
            if(asteroidInstance.gameObject.tag == "AsteroidTwo") {
                asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            }
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
        }
    }
}
