using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikapController : MonoBehaviour {

    public int IdPosition = 0;//Id Position

    public Transform[] PointesBox;//Point Box

    public PlayerController ControllerPlayer;//Player Controller

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "BoxPoint" && ControllerPlayer.GetValueIsGet()) {

            ControllerPlayer.GetValueBox().transform.position = PointesBox[IdPosition].transform.position;

            ControllerPlayer.GetValueBox().transform.parent = transform;

            ControllerPlayer.SetValueIsGet(false);

            IdPosition++;

        }

    }

}
