using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemaras : MonoBehaviour
{
    public Transform pla = null;
    public GameObject target = null;
    public Vector3 nextPos = Vector3.one;
    public Vector3 timefollow = new Vector3(20.0f, 5.0f, 9.0f);
    void Update()
    {
        //Random ran = new Random();
        
        // int num = Mathf.FloorToInt( Random.Range(1.0f, 10.0f));
        //    Debug.Log(num);
    }
    private void LateUpdate()
    {
        this.transform.LookAt(pla.position);
        nextPos.x = Mathf.Lerp(this.transform.position.x, target.transform.position.x, timefollow.x * Time.deltaTime);
        nextPos.y = Mathf.Lerp(this.transform.position.y, target.transform.position.y, timefollow.y * Time.deltaTime);
        nextPos.z = Mathf.Lerp(this.transform.position.z, target.transform.position.z, timefollow.z * Time.deltaTime);
        this.transform.position = nextPos;
    }
}
