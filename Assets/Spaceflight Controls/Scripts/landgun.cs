using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class landgun : MonoBehaviour
{
    public Transform weapon_hardpoint_1; //"Weapon Hardpoint", "Transform for the barrel of the weapon"
    public GameObject bullet; //"Projectile GameObject", "Projectile that will be fired from the weapon hardpoint."
    public GameObject healthbarPreFAb;
    public resorces res;
    public GereralGameSeetings gernalSeetings;
    public bullet Bull;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(res.Carbon>=5 && res.Metal >= 50)
            {
                res.Bullet += 30;
                res.Carbon -= 5;
                res.Metal -= 50;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (res.Bullet <= 0)
            {
                res.Bullet = 0;
            }
            else
            {
                fireShot();
                res.Bullet--;
            }
        }
        if (Input.GetMouseButton(1))
        {
            if(res.Bullet <= 0)
            {
                res.Bullet = 0;
            }
            else
            {
                fireShot();
                res.Bullet--;
            }
            
        }
    }
    public void fireShot()
    {

        if (weapon_hardpoint_1 == null)
        {
            Debug.LogError("(FlightControls) Trying to fire weapon, but no hardpoint set up!");
            return;
        }

        if (bullet == null)
        {
            Debug.LogError("(FlightControls) Bullet GameObject is null!");
            return;
        }

        //Shoots it in the direction that the pointer is pointing. Might want to take note of this line for when you upgrade the shooting system.
        if (Camera.main == null)
        {
            Debug.LogError("(FlightControls) Main camera is null! Make sure the flight camera has the tag of MainCamera!");
            return;
        }

        GameObject shot1 = (GameObject)GameObject.Instantiate(bullet, weapon_hardpoint_1.position, Quaternion.identity);

        Ray vRay;

        if (!CustomPointer.instance.center_lock)
            vRay = Camera.main.ScreenPointToRay(CustomPointer.pointerPosition);
        else
            vRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));


        RaycastHit hit;
        Debug.Log("in here");
        //If we make contact with something in the world, we'll make the shot actually go to that point.
        if (Physics.Raycast(vRay, out hit))
        {
            Debug.Log(" hit point " + hit.collider.name);
           
            shot1.transform.LookAt(hit.point);
            shot1.GetComponent<Rigidbody>().AddForce((shot1.transform.forward) * 9000f);
            HealthShow(hit.collider.name);
            //Otherwise, since the ray didn't hit anything, we're just going to guess and shoot the projectile in the general direction.
        }
        else
        {
            shot1.GetComponent<Rigidbody>().AddForce((vRay.direction) * 9000f);
        }

    }
    public void HealthShow(string objName)
    {
        GameObject obj = GameObject.Find(objName);
        if (objName.Contains("rockaa"))
        {
            HealthHelper(obj, 2,"rock");
        }
        if (objName.Contains("treeaa"))
        {
            HealthHelper(obj, 6,"tree");
        }


    }
    void HealthHelper(GameObject obj,int height,string typeobj)
    {
        int flag = 0;
        int pos = 0;
        if(height == 2)
        {
            pos = 3;
        }
        Transform canvas = obj.transform;
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (obj.transform.GetChild(i).name.Equals("healthbar"))
            {
                canvas = obj.transform.GetChild(i);
                flag = 1;
            }
        }
        if (flag == 0)
        {
             canvas = crehb(obj, height);
        }
        Transform empty = canvas.GetChild(0);
        GameObject healImaheBar = empty.GetChild(0).gameObject;
        Image bar = healImaheBar.GetComponent<Image>();

        float preHealth = bar.fillAmount;
        bar.fillAmount = preHealth - 0.2f;
        Debug.Log(obj + " " + bar.fillAmount + " " + preHealth);
        if (bar.fillAmount <= 0.15)
        {
           
            Destroy(obj, 0.2f);
            if (typeobj.Equals("tree"))
            {
                res.Carbon = res.Carbon + 50;
                res.Metal += 3;
            }
            if (typeobj.Equals("rock"))
            {
                res.Metal = res.Metal + 50;
                res.Carbon += 2;
            }
           
        }
    }
    public Transform crehb(GameObject obj, int height)
    {
        GameObject barrr = Instantiate(healthbarPreFAb);
        barrr.name = "healthbar";
        barrr.transform.position = new Vector3(obj.transform.position.x, height, obj.transform.position.z);
        barrr.transform.SetParent(obj.transform);
        return barrr.transform;
    }
}
