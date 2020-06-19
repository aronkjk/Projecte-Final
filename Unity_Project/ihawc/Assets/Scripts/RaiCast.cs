using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiCast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
        }
    }
}
