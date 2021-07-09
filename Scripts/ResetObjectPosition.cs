using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectPosition : MonoBehaviour
{
    [SerializeField] float correctionFactor = .3f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "EnemyBullet") {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>().justWentThrough == false) {
            //other.gameObject.GetComponent<Player>().currentTriggerTag = this.gameObject.tag;
            //other.gameObject.GetComponent<Player>().justWentThrough = true;
            other.gameObject.SetActive(false);
            if(this.gameObject.tag == "LeftEdge") {
                other.gameObject.transform.position = new Vector3(-other.transform.position.x - correctionFactor,other.transform.position.y,other.transform.position.z);
            }
            else if(this.gameObject.tag == "RightEdge") {
                other.gameObject.transform.position = new Vector3(-other.transform.position.x + correctionFactor,other.transform.position.y,other.transform.position.z);
            }
            else if (this.gameObject.tag == "TopEdge") {
                other.gameObject.transform.position = new Vector3(other.transform.position.x,-other.transform.position.y + correctionFactor,other.transform.position.z);
            }
            else if (this.gameObject.tag == "BottomEdge") {
                other.gameObject.transform.position = new Vector3(other.transform.position.x,-other.transform.position.y - correctionFactor,other.transform.position.z);
            }
            other.gameObject.SetActive(true);
            Player.checkFiring = true;
        }
    }
}
