using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMoveAtAngle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "PlayerBullet") {
            transform.position += transform.up*15f*Time.deltaTime;
        }
        else {
            transform.position += -transform.up*15f*Time.deltaTime;
        }
    }
}
