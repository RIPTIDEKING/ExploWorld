using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejectScalling : MonoBehaviour
{
    public Vector3 originalScale = Vector3.zero;
    void Start()
    {
        
    }
    private void Awake()
    {
        originalScale = this.transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ScaleUp();
            //this.transform.localScale = Vector3.one * 5;
        }
        if (Input.GetKey(KeyCode.E))
        {
            ScaleDown();
        }
    }
    public void ScaleUp()
    {
        this.transform.localScale = new Vector3(5, 0.15f, 5);
        this.GetComponent<Renderer>().material.color = Color.black;
    }
    public void ScaleDown()
    {
        this.transform.localScale = originalScale;
        this.GetComponent<Renderer>().material.color = Color.red;
    }
}
