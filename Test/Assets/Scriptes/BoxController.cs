using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    public PlayerController ControllerPlayer;//Player Controller

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "BoxPoint" && !ControllerPlayer.GetValueIsGet()) {
            
            ControllerPlayer.SetValueIsGet(true);            

            ControllerPlayer.SetValueBox(gameObject);

            transform.position = other.transform.position;

            transform.parent=other.gameObject.transform;

        }

    }

}
