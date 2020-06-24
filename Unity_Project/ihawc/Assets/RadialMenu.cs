using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    public int index;


    void OnMouseOver()
    {
        GetComponentInParent<Animator>().SetInteger("Selection", index);
    }

    void OnMouseExit()
    {
       GetComponentInParent<Animator>().SetInteger("Selection", 0);
    }
}
