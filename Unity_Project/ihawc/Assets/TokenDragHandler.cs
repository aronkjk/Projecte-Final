using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TokenDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public BoarManager Board;
	public Text Number;
	public GameObject highlightSelected;
    public int typeToken;

    public void OnDrag(PointerEventData eventData)
    {
			
	}

	public void OnEndDrag(PointerEventData eventData)
    {
		
		Board.spawnToken(typeToken, Number);
    }

	public void OnPointerDown(PointerEventData eventData)
	{
		Board.unselectToken();
		highlightSelected.SetActive(true);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		highlightSelected.SetActive(false);
	}
}
