using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverButtonMenu : MonoBehaviour
{
    void OnMouseOver()
    {
        GetComponent<Animator>().SetBool("selected", true);
    }

    void OnMouseExit()
    {
        GetComponent<Animator>().SetBool("selected", false);
    }
}
