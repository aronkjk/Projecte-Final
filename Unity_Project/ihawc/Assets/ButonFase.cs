using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonFase : MonoBehaviour
{
    public GameObject board;

    private void OnMouseDown()
    {
        board.GetComponent<BoarManager>().endTurn();
        transform.GetComponentInParent<Animator>().SetTrigger("MouseDown");
    }
}
