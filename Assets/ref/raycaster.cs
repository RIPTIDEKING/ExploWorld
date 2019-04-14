using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycaster : MonoBehaviour
{
    // public Camera camera;
    public Transform player;
    private Ray ray;
   // public GameObject obj;
    private RaycastHit hit;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //ray = camera.ScreenPointToRay(Input.mousePosition);
     //       if (Physics.Raycast(ray))
       //     {
     //           Debug.Log("Hit Something");
      //      }
     // if(Physics.Raycast(ray,out hit))
      //      {
        //        if (hit.collider)
          //      {
            //        Debug.Log("Object Name: " + hit.collider.name);

              //      Instantiate(obj, hit.point, hit.transform.rotation);
                }
        //   RaycastHit hit = null;
     //   Debug.Log(player.transform.rotation.eulerAngles);
        if(Physics.Raycast(player.position,player.forward,out hit))
        {
            if (hit.collider)
            {
                Debug.Log("Object Name: " + hit.collider.name);
            }
        }
        

        Debug.DrawRay(player.position, player.forward*50.0f, Color.green);
        //Debug.DrawLine(ray.origin, hit.point, Color.green);
    }
}
