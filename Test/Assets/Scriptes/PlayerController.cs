using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject ChoosedBox;//ChoosedBox

    public Image IconLadder;//Icon Ladder

    public float PlayerPosY = 0.0f;//Player PosY

    public bool IsPositionShefle = false;//Is Position Shefle

    public int PositionShefle = 1;//Position Shefle 1-4    

    public bool IsGet = false;//Check Is Get

    public float PlayerSpeed = 5.0f;//Player Speed

    public float RotationX = 0f;//Rotation X

    public float RotationY = 0f;//Rotation Y

    public float SensitivityRotation = 5.0f;//Senesitivity Roatation           

    //Set Value Position Shefle
    public void SetValuePositionShefle(int positionShefle) {

        PositionShefle = positionShefle;      

    }

    //Get Value Position Shefle
    public int GetValuePositionShefle() {

        return PositionShefle;

    }

    //SetValue Box
    public void SetValueBox(GameObject box) {

        ChoosedBox = box;

    }

    //Get Value Box
    public GameObject GetValueBox() {

        return ChoosedBox;

    }

    //Set Value IsGet
    public void SetValueIsGet(bool isGet) {

        IsGet = isGet;

    }
    
    //Get Value IsGet
    public bool GetValueIsGet() {

        return IsGet;

    }

    //Player Roatation
    public void PlayerRotation() {

        RotationY += Input.GetAxis("Mouse X") * SensitivityRotation;
        RotationX += Input.GetAxis("Mouse Y") * -1 * SensitivityRotation;

        transform.localEulerAngles = new Vector3(0.0f, RotationY, 0);

    }

    //Player Move
    public void PlayerMove() {

        //Take the ladder
        if (Input.GetKeyDown(KeyCode.R)) {

            if (IsPositionShefle) {

                IconLadder.color = Color.white;

                PositionShefle = 1;

                transform.position = new Vector3(transform.position.x, PlayerPosY, transform.position.z);

                IsPositionShefle = false;

                transform.GetComponent<Rigidbody>().isKinematic = false;

            } else {

                IconLadder.color = Color.red;

                IsPositionShefle = true;

                transform.GetComponent<Rigidbody>().isKinematic = true;

            }

        }

        //Up
        if (Input.GetKeyDown(KeyCode.E)) {

            if (GetValuePositionShefle() != 3 && IsPositionShefle) {

                PositionShefle++;

                transform.position = new Vector3(transform.position.x, transform.position.y+1.0f, transform.position.z);

            }

        }

        //Down
        if (Input.GetKeyDown(KeyCode.Q) && IsPositionShefle) {

            if (GetValuePositionShefle() != 0) {

                PositionShefle--;                

                transform.position = new Vector3(transform.position.x, transform.position.y-1.0f, transform.position.z);

            }

        }

        if (Input.GetKey(KeyCode.W)) {                           

            transform.position += transform.forward * PlayerSpeed * Time.deltaTime;

        }
        
        if (Input.GetKey(KeyCode.S)) {            

            transform.position -= transform.forward * PlayerSpeed * Time.deltaTime;

        }        
       
        if (Input.GetKey(KeyCode.A)) {

            transform.position -= transform.right * PlayerSpeed * Time.deltaTime;

        }
        
        if (Input.GetKey(KeyCode.D)) {

            transform.position += transform.right * PlayerSpeed * Time.deltaTime;

        }        

    }

    // Update is called once per frame
    void Update() {

        PlayerRotation();
        PlayerMove();

    }

    private void Awake() {
    
        PlayerPosY=transform.position.y;

    }

}
