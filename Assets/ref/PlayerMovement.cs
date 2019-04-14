using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed1 = 10.0f;
    public float speed2 = 80.0f;
    public float speed = 5.0f;
    public char df = 'f';
    public char ds = 'l';
   // public GameObject topHead = null;
    public Vector3 playerPosition =  Vector3.zero;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = this.transform.position;
      //  topHead.transform.position = new Vector3(playerPosition.x, playerPosition.y + 0.4f, playerPosition.z);
       
        Movement();
       
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(0, 0, speed1 * Time.deltaTime));
            if (df == 'f')
            {
                //speed1 = speed1 + 0.1f;
            }
            else if (df == 'd')
            {
                speed1 = 1.0f;
                df = 'f';
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(new Vector3(0, 0, -speed1 * Time.deltaTime));
            if (df == 'd')
                speed1 = speed1 + 0.1f;
            else if (df == 'f')
            {
                //speed1 = speed1 + 0.1f;
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(new Vector3(0,speed2 * Time.deltaTime, 0));
            if (ds == 'r')
                speed2 = speed2 + 0.5f;
            else if (ds == 'l')
            {
                speed2 = 80.0f;
                ds = 'r';
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0,-speed2 * Time.deltaTime, 0));
            if (ds == 'l')
                speed2 = speed2 + 0.5f;
            else if (ds == 'r')
            {
                speed2 = 80.0f;
                ds = 'l';
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
