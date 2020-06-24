using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> cardsP1;
    public List<GameObject> cardsP2;
    private List<GameObject> activeCards;
   

    void Start()
    {
        spawnCards();
    }


    void Update()
    {
        
    }

    private void SpawnCard(List<GameObject> cards, int i, float x, float y, float z, Vector2 rotation)
    {
        float r = Random.Range(rotation.x, rotation.y);
        GameObject instantiate = Instantiate(cards[i],new Vector3(x,y,z) , Quaternion.EulerAngles(0, r, 0)) as GameObject;
        instantiate.transform.SetParent(transform);
        
        //Tokens[(int)x, (int)y] = instantiate.GetComponent<Token>(); 
        //Tokens[(int)x, (int)y].setPosition((int)x, (int)y);
        activeCards.Add(instantiate);
    }

    private void spawnCards()
    {
        activeCards = new List<GameObject>();
        for (int i = 0; i < cardsP1.Count; i++)
        {
            SpawnCard(cardsP1, i, -3, i % 2f, 3, new Vector2(-1.12f, -1));
        }

        for (int i = 0; i < cardsP2.Count; i++)
        {
            SpawnCard(cardsP2, i, -3, i % 2f, 13, new Vector2(1, 1.12f));
        }
    }
}
