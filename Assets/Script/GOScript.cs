using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOScript : MonoBehaviour
{
    //private void OnMouseDown()
    //{
    //    var sr = gameObject.GetComponent<SpriteRenderer>();
    //    sr.color = Color.green;
    //}
    Color[] TotalColors;
    DateTime timeCreation;
    private void Start()
    {
        TotalColors = new Color[] { Color.white, Color.grey, Color.red, Color.blue, Color.green, Color.cyan, Color.magenta, Color.yellow, Color.gray };
        timeCreation = DateTime.Now;
    }
    private void Update()
    {
        var currentTimeSpan = DateTime.Now - timeCreation;
        var conditionTimeSpan = new TimeSpan(0, 0, 10);
        if (currentTimeSpan>=conditionTimeSpan)
        {
            timeCreation = DateTime.Now;
            SwitchColor();
        }
    }
    public void SwitchColor()
    {
        var color = GetRandomColor(gameObject.name);
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
    private Color GetRandomColor(string name)
    {
        if (name == "Sphere")
        {
            return TotalColors[UnityEngine.Random.Range(2, 5)];
        }
        return new Color(UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255));
    }
}
