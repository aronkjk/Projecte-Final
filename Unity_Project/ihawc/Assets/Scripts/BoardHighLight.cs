using System.Collections.Generic;
using UnityEngine;

public class BoardHighLight : MonoBehaviour
{
    public static BoardHighLight Instance { set; get; }

    public GameObject highlightPrefabMove, highlightPrefabAttack, highlightPrefabFusion,
		highlightsPrefabMovePattern, highlightsPrefabAttackPattern, highlightsPrefabFusionPattern,
		highlightCurrentPos;
    private List<GameObject> highlightsMove, highlightsAttack, highlightsFusion, 
		highlightsMovePattern, highlightsAttackPattern, highlightsFusionPattern;

    private void Start()
    {
        Instance = this;		
        highlightsMove = new List<GameObject>();
        highlightsAttack = new List<GameObject>();
        highlightsFusion = new List<GameObject>();

		highlightsMovePattern = new List<GameObject>();
		highlightsAttackPattern = new List<GameObject>();
		highlightsFusionPattern = new List<GameObject>();
	}

    private GameObject GetHighlightObjectMove()
    {
        GameObject go = highlightsMove.Find(g => !g.activeSelf);

        if(go == null)
        {
            go = Instantiate(highlightPrefabMove);
            highlightsMove.Add(go);
        }

        return go;
    }

    private GameObject GetHighlightObjectAttack()
    {
        GameObject go = highlightsAttack.Find(g => !g.activeSelf);

        if (go == null)
        {
            go = Instantiate(highlightPrefabAttack);
            highlightsAttack.Add(go);
        }

        return go;
    }

    private GameObject GetHighlightObjectFusion()
    {
        GameObject go = highlightsFusion.Find(g => !g.activeSelf);

        if (go == null)
        {
            go = Instantiate(highlightPrefabFusion);
            highlightsFusion.Add(go);
        }

        return go;
    }

	private GameObject GetHighlightObjectPatternMove()
	{
		GameObject go = highlightsMovePattern.Find(g => !g.activeSelf);

		if (go == null)
		{
			go = Instantiate(highlightsPrefabMovePattern);
			highlightsMovePattern.Add(go);
		}

		return go;
	}

	private GameObject GetHighlightObjectPatternAttack()
	{
		GameObject go = highlightsAttackPattern.Find(g => !g.activeSelf);

		if (go == null)
		{
			go = Instantiate(highlightsPrefabAttackPattern);
			highlightsAttackPattern.Add(go);
		}

		return go;
	}

	private GameObject GetHighlightObjectPatternFusion()
	{
		GameObject go = highlightsFusionPattern.Find(g => !g.activeSelf);

		if (go == null)
		{
			go = Instantiate(highlightsPrefabFusionPattern);
			highlightsFusionPattern.Add(go);
		}

		return go;
	}

	public void HighlightAllowedMoves(bool[,] moves)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (moves[i, j])
                {
                    GameObject go = GetHighlightObjectMove();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);
                }
            }
        }
    }

    public void HighlightAllowedAttack(bool[,] attack)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (attack[i, j])
                {
                    GameObject go = GetHighlightObjectAttack();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);
                }
            }
        }
    }

    public void HighlightAllowedFusion(bool[,] fusion)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (fusion[i, j])
                {
                    GameObject go = GetHighlightObjectFusion();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);
                }
            }
        }
    }

	public void HighlightAllowedMovesPattern(bool[,] movesPattern)
	{
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				if (movesPattern[i, j])
				{
					GameObject go = GetHighlightObjectPatternMove();
					go.SetActive(true);
					go.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);
				}
			}
		}
	}

	public void HighlightAllowedAttackPattern(bool[,] attackPattern)
	{
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				if (attackPattern[i, j])
				{
					GameObject go = GetHighlightObjectPatternAttack();
					go.SetActive(true);
					go.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);
				}
			}
		}
	}

	public void HighlightAllowedFusionPattern(bool[,] fusionPattern)
	{
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				if (fusionPattern[i, j])
				{
					GameObject go = GetHighlightObjectPatternFusion();
					go.SetActive(true);
					go.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);
				}
			}
		}
	}
	
	public void HideHighlights()
    {
        foreach (GameObject go in highlightsMove)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in highlightsAttack)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in highlightsFusion)
        {
            go.SetActive(false);
        }

		foreach (GameObject go in highlightsMovePattern)
		{
			go.SetActive(false);
		}

		foreach (GameObject go in highlightsAttackPattern)
		{
			go.SetActive(false);
		}

		foreach (GameObject go in highlightsFusionPattern)
		{
			go.SetActive(false);
		}
	}

}
