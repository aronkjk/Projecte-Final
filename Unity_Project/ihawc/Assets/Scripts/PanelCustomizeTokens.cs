using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCustomizeTokens : MonoBehaviour
{
	public List<GameObject> tokens;
	// Start is called before the first frame update
	void Start()
    {

		//Para que este for se realice correctamente se tienen que introducir los tokens de la lista en el orden en que estan los botones del menu 
		//para editar su respectivo token
		for(int i = 0; i < tokens.Count; i++)
		{
			transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = tokens[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
