using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTakeOff : MonoBehaviour
{
    public PlayerFlightControl pfc;
    public SimpleCameraController groundCameraScript;
    public CustomPointer cpointer;
    public CameraFlightFollow airCameraScript;
    public float landSpeed = 10;
    public float landRotSpeed = 10;
    public GameObject player = null;
    public GameObject landPlayer = null;
    public float minAlt = 10.0f;
    public int insideVechile = 1;
    public float breakspeed = 1;
    public GameObject oeng = null;
    public GameObject oeng2 = null;

    void Start()
    {
        groundCameraScript = GetComponent<SimpleCameraController>();
        cpointer = GetComponent<CustomPointer>();
        airCameraScript = GetComponent<CameraFlightFollow>();
    }
    int flag = 0;
    int enginei = 0;
    int exectefirst = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            flag = 1;
        }
        if (flag == 1)
        {
            LandVechile();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            VechileChange();
        }
    }
    
    void LandVechile()
    {
        Debug.Log("Inside Function");
            GameObject ship = pfc.actual_model;
            Rigidbody shipbody = ship.GetComponent<Rigidbody>();
            if (exectefirst == 1)
            {
            //  shipbody.constraints = RigidbodyConstraints.FreezePosition;
                shipbody.constraints = RigidbodyConstraints.FreezeAll;
                insideVechile = 0;
                flag = 2;
                enginei = 0;
                exectefirst = 0;
                return;
            }
            if (insideVechile == 1)
            {
                pfc.enabled = false;
               // cpointer.enabled = false;
                shipbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ| RigidbodyConstraints.FreezePositionY;
                Vector3 nextPos = Vector3.one;
                CorrectRot();
            if (pfc.speed >= 6)
            {
                pfc.speed = Mathf.Lerp(pfc.speed, 0, breakspeed * Time.deltaTime);
                return;
            }
                nextPos.x = player.transform.position.x;
                nextPos.y = Mathf.Lerp(player.transform.position.y, 0.0f, landSpeed * Time.deltaTime);
                nextPos.z = player.transform.position.z;
                if (player.transform.position.y <= 2.0f)
                {
                player.transform.position = new Vector3(player.transform.position.x, 1.0f, player.transform.position.z);
                exectefirst = 1;
                return;
                }
                player.transform.position = nextPos;

            
            }

            if (insideVechile == 0)
            {
            if (enginei == 0)
            {
                
                    GameObject obj = Instantiate(oeng);
                    obj.name = "engine0";
                    obj.transform.parent = player.transform;
                    obj.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 5.0f);
                GameObject obj1 = Instantiate(oeng2);
                obj1.name = "engine1";
                obj1.transform.parent = player.transform;
                obj1.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 5.0f);
                pfc.speed = 20.0f;
                enginei = 1;
            }
            Vector3 nextPos = Vector3.one;
                nextPos.x = player.transform.position.x;
                nextPos.y = Mathf.Lerp(player.transform.position.y, minAlt, landSpeed * Time.deltaTime);
                nextPos.z = player.transform.position.z;
                Debug.Log("Up ! UP!");
                if (player.transform.position.y >= 9.5f)
                {
                    shipbody.constraints = RigidbodyConstraints.None;
                    insideVechile = 1;
                    pfc.enabled = true;
                    cpointer.enabled = true;
                    flag = 2;
                    Debug.Log("Finished");
                }
                player.transform.position = nextPos;
            }
        
    }
    void CorrectRot()
    {
        GameObject ship = pfc.actual_model;
        Rigidbody shipbody = ship.GetComponent<Rigidbody>();
       // bool retVal = false;
        //  Quaternion nextrot = player.transform.rotation;
        bool cx=false, cy=false, cz=false;
        Vector3 nextrot = player.transform.eulerAngles;
        if (nextrot.x >=0.4 || nextrot.x <= -0.4) {
            nextrot.x = Mathf.LerpAngle(player.transform.eulerAngles.x, 0, landRotSpeed * Time.deltaTime);
        }
        if (nextrot.y >= 0.4 || nextrot.y <= -0.4)
        {
            nextrot.y = Mathf.LerpAngle(player.transform.eulerAngles.y, 0, landRotSpeed * Time.deltaTime);
        }
        if (nextrot.z >= 0.4 || nextrot.z <= -0.4)
        {
            nextrot.z = Mathf.LerpAngle(player.transform.eulerAngles.z, 0, landRotSpeed * Time.deltaTime);
        }
        if (nextrot.x <= 0.4)
        {           
            nextrot.x = 0;          
        }
        if (nextrot.y <= 0.4)
        {
            nextrot.y = 0;
        }
        if (nextrot.z <= 0.4)
        {
            nextrot.z = 0;
        }

        player.transform.eulerAngles = nextrot;
       // Debug.Log(nextrot +"  "+ Vector3.zero);
        if (player.transform.eulerAngles == Vector3.zero)
        {
            shipbody.constraints = RigidbodyConstraints.FreezeRotation;
            Debug.Log(player.transform.eulerAngles+" finsihed");
          //  retVal = true;
        }
        //return retVal;
    }
    void VechileChange()
    {
        if(insideVechile == 0)
        {
            groundCameraScript.enabled = true;
            airCameraScript.enabled = false;
            landPlayer.SetActive(true);
            landPlayer.transform.position = new Vector3(player.transform.position.x+3, player.transform.position.y+1, player.transform.position.z+3);
            insideVechile = 1;
            return;
        }
        if (insideVechile == 1)
        {
            groundCameraScript.enabled = false;
            airCameraScript.enabled = true;
            landPlayer.SetActive(false);
            //landPlayer.transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y + 1, player.transform.position.z + 3);
            insideVechile = 0;
            return;
        }
    }
}
