using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resorces : MonoBehaviour
{

    public int Carbon = 100;
    public int Metal = 100;
    public int Bullet = 20;
    public GUIStyle gstyle = new GUIStyle();
    void OnGUI()
    {
        gstyle.fontSize = 40;
        gstyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 100), "Carbon: " + Carbon + "\nOre: " + Metal+"\nBullets: "+Bullet,gstyle);
    }
}
