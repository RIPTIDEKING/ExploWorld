using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighhtSwitch : MonoBehaviour
{
    public GameObject lightBulb = null;
    public GameObject wall = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            lightBulb.SetActive(true);
            wall.GetComponent<ObejectScalling>().ScaleUp();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        lightBulb.SetActive(false);
        wall.GetComponent<ObejectScalling>().ScaleDown();
    }
}
