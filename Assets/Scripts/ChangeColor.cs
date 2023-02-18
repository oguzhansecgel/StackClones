using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    List<Color32> chanceColor = new(){
        new Color32(255, 127, 127, 255),
        new Color32(255, 133, 127, 160),
        new Color32(255, 140, 127, 170),
        new Color32(255, 146, 127, 170),
        new Color32(255, 153, 127, 170),
        new Color32(255, 159, 127, 170),
        new Color32(255, 165, 127, 170),
        new Color32(255, 172, 127, 170),
        new Color32(255, 178, 127, 170),
        new Color32(255, 184, 127, 170),
        new Color32(255, 191, 127, 170),
        new Color32(255, 197, 127, 170),
        new Color32(255, 204, 127, 170),
        new Color32(255, 210, 127, 170),
        new Color32(255, 216, 127, 170),
        new Color32(255, 223, 127, 170),
        new Color32(255, 229, 127, 170),
        new Color32(255, 235, 127, 170),
        new Color32(255, 242, 127, 170),
        new Color32(255, 248, 127, 170),
        new Color32(255, 255, 127, 170),
        new Color32(248, 255, 127, 170),
        new Color32(242, 255, 127, 170),
        new Color32(235, 255, 127, 170),
        new Color32(229, 255, 127, 170),
        new Color32(223, 255, 127, 170),
        new Color32(216, 255, 127, 170),
        new Color32(210, 255, 127, 170),
        new Color32(204, 255, 127, 170),
        new Color32(197, 255, 127, 170),
        new Color32(204, 255, 127, 170),
        new Color32(210, 255, 127, 170),
        new Color32(216, 255, 127, 170),
        new Color32(223, 255, 127, 170),
        new Color32(229, 255, 127, 170),
        new Color32(235, 255, 127, 170),
        new Color32(242, 255, 127, 170),
        new Color32(248, 255, 127, 170),
        new Color32(255, 255, 127, 170),
        new Color32(255, 248, 127, 170),
        new Color32(255, 242, 127, 170),
        new Color32(255, 235, 127, 170),
        new Color32(255, 229, 127, 170),
        new Color32(255, 223, 127, 170),
        new Color32(255, 216, 127, 170),
        new Color32(255, 210, 127, 170),
        new Color32(255, 204, 127, 170),
        new Color32(255, 197, 127, 170),
        new Color32(255, 197, 127, 170),
        new Color32(255, 197, 127, 170),
        new Color32(255, 191, 127, 170),
        new Color32(255, 184, 127, 170),
        new Color32(255, 178, 127, 170),
        new Color32(255, 172, 127, 170),
        new Color32(255, 165, 127, 170),
        new Color32(255, 159, 127, 170),
        new Color32(255, 153, 127, 170),
        new Color32(255, 146, 127, 170),
        new Color32(255, 140, 127, 170),
        new Color32(255, 133, 127, 160),
        new Color32(255, 127, 127, 255),
    };
   
    public void BackColorChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.backgroundColor = getColor();

        }
    }
    private int colorIndex = 0;
    private Color32 getColor()
    {
    Color32 result = chanceColor[colorIndex];
    colorIndex = (colorIndex + 1) % chanceColor.Count;
    return result;
    }
}
