using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet = null;
    public float BulletSpeed = 5.0f;
    public GameObject cbull = null;
    public int bno = 1;
    public int force1 = 1000;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
             cbull = Instantiate(bullet) as GameObject;
            cbull.transform.position = this.transform.position;
            cbull.AddComponent<Rigidbody>();
            //cbull.GetComponent<Rigidbody>().useGravity = false;
            cbull.GetComponent<Rigidbody>().mass = 0.1f;
            cbull.GetComponent<Rigidbody>().AddRelativeForce( new Vector3(force1, 0, 0));
            cbull.name = "bullet" + bno;
            bno++;
          // 
        }
       // Tranbull();
    }
    void Tranbull()
    {
        if(cbull!=null)
        cbull.transform.Translate(new Vector3(BulletSpeed * Time.deltaTime, 0, 0));
    }
}
