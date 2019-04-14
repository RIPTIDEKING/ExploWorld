using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeSpawner : MonoBehaviour
{
    public GameObject originalTree = null;
    public int count = 100,i=0;
    int xPos = 0, yPos = 0, zPos = 0;
    public Vector3 ntreePlace =Vector3.zero;
    public GameObject cpyTree = null;
     void Start()
    {
       
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            i = 0;
            while (i <= count)
            {
                xPos = Mathf.FloorToInt(Random.Range(-500.0f, 500.0f));
                zPos = Mathf.FloorToInt(Random.Range(-500.0f, 500.0f));
                cpyTree = Instantiate(originalTree);
                ntreePlace = new Vector3(xPos, 0, zPos);
                cpyTree.name = "tree " + i;
            cpyTree.transform.position = ntreePlace;
                i++;
            }

        }
    }
}
