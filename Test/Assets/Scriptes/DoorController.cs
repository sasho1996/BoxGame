using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class DoorController : MonoBehaviour {

    public GameObject[] DoorPartes;

    public Transform EndPositionDoorPart;

    public Vector3[] StartPositionesDoorPartes;

    public bool OnPlace = false;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player" && !OnPlace) {            

            OnPlace = true;

            for (int i = 0; i < DoorPartes.Length; i++)  {                

                DoorPartes[i].transform.DOMove(new Vector3(EndPositionDoorPart.transform.position.x, EndPositionDoorPart.transform.position.y, EndPositionDoorPart.transform.position.z), 1);

            }

            StartCoroutine(WaitAndGetStartPosition());

        }

    }
    
    //Wait And Get Start Position
    IEnumerator WaitAndGetStartPosition() {

        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < DoorPartes.Length; i++) {

            DoorPartes[i].transform.DOMove(new Vector3(StartPositionesDoorPartes[i].x, StartPositionesDoorPartes[i].y, StartPositionesDoorPartes[i].z), 1);            

        }

        OnPlace = false;

    }

    private void Awake() {

        StartPositionesDoorPartes = new Vector3[16];
        
        for(int i = 0;i<StartPositionesDoorPartes.Length; i++) {

            StartPositionesDoorPartes[i] = DoorPartes[i].transform.position;

        }

    }

}
