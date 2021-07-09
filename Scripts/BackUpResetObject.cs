using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUpResetObject : MonoBehaviour
{    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
            if(this.gameObject.tag == "TopEdgeBackUp" || this.gameObject.tag == "BottomEdgeBackUp") {
                other.gameObject.transform.position = new Vector3(other.transform.position.x,-other.transform.position.y,other.transform.position.z);
                if(other.gameObject.GetComponent<Player>().justWentThrough) {
                    other.gameObject.GetComponent<Player>().justWentThrough = false;
                }
            }
            else {
                other.gameObject.transform.position = new Vector3(-other.transform.position.x,other.transform.position.y,other.transform.position.z);
                if(other.gameObject.GetComponent<Player>().justWentThrough) {
                    other.gameObject.GetComponent<Player>().justWentThrough = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" 
            && other.gameObject.GetComponent<Player>().justWentThrough == true
            && other.gameObject.GetComponent<Player>().currentTriggerTag != this.gameObject.tag) {
                other.gameObject.GetComponent<Player>().justWentThrough = false;
        }
    }
}
