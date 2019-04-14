using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GereralGameSeetings : MonoBehaviour
{
    public int temp;
    public int pos;
    public GUIStyle guiStyle = new GUIStyle();

    private void OnGUI()
    {
        guiStyle.fontSize = 30;
        if(temp >= 50)
        {
            guiStyle.normal.textColor = Color.red;
        }else if (temp <= 5)
        {
            guiStyle.normal.textColor = Color.blue;
        }else
        {
            guiStyle.normal.textColor = Color.white;
        }
        int ftemp = temp + 273;
        GUI.Label(new Rect((Screen.width / 2)-pos/2,25, pos, 20),"Temperature: "+ftemp+"K",guiStyle);
        
    }
}
