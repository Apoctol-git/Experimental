using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private void OnMouseDown()
    {
        var coord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(new Vector3(coord.x, coord.y, 1), new Vector3(coord.x, coord.y, 10));
        Physics.Raycast(ray, out hit);
        if (hit.collider==null)
        {
            NewObject(coord);
        }
        else
        {
            var script = hit.collider.gameObject.GetComponent<GOScript>();
            script.SwitchColor();
        }
    }
    private void NewObject(Vector3 coord)
    {
        coord.z = 2;
        CreateObject(PrimitiveType.Sphere, coord);
    }
    
    private void CreateObject(PrimitiveType type, Vector3 coord)
    {
        var go = GameObject.CreatePrimitive(type);
        go.AddComponent<GOScript>();
        go.transform.position = coord;
    }
}
