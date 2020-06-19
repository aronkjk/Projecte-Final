using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

public class BoarManager : MonoBehaviour
{
    public static BoarManager Instance { set; get; }
    private bool[,] allowedMoves { set; get; }
    private bool[,] allowedAttack { set; get; }
    private bool[,] allowedFusion { set; get; }

	private bool[,] movementPattern { set; get; }
	private bool[,] attackPattern { set; get; }
	private bool[,] fusionPattern { set; get; }

	//Tamaño de cada cuadro
	private const float TILE_SIZE = 1.0f;
    //Centro del cuadro
    private const float TILE_OFFSET = 0.5f;

    //Variables que indican que cuadro esta seleccionado (-1 es no seleccionado)
    private int selectionX = -1;
    private int selectionY = -1;

	public bool spawnPosLock { get; set; }
	public bool spawnLimitLock { get; set; }
	public bool spawnPoolLock { get; set; }

	public List<GameObject> tokensBuilderP1;
    public List<GameObject> tokensInfantryP1;
    public List<GameObject> tokensWizardP1;
    public List<GameObject> tokensArcherP1;
    public List<GameObject> tokensHorseP1;

    public List<GameObject> tokensWallP1;
    public List<GameObject> tokensDefenseTowerP1;
    public List<GameObject> tokensRamP1;
    public List<GameObject> tokensMagicCauldronP1;
    public List<GameObject> tokensCatapultP1;
    public List<GameObject> tokensCentaurP1;
    public List<GameObject> tokensVulcanP1;
    public List<GameObject> tokensGolemP1;
    public List<GameObject> tokensAngelP1;
    public List<GameObject> tokensDragonP1;

    public List<GameObject> tokensBuilderP2;
    public List<GameObject> tokensInfantryP2;
    public List<GameObject> tokensWizardP2;
    public List<GameObject> tokensArcherP2;
    public List<GameObject> tokensHorseP2;

    public List<GameObject> tokensWallP2;
    public List<GameObject> tokensDefenseTowerP2;
    public List<GameObject> tokensRamP2;
    public List<GameObject> tokensMagicCauldronP2;
    public List<GameObject> tokensCatapultP2;
    public List<GameObject> tokensCentaurP2;
    public List<GameObject> tokensVulcanP2;
    public List<GameObject> tokensGolemP2;
    public List<GameObject> tokensAngelP2;
    public List<GameObject> tokensDragonP2;

    private List<GameObject> activeTokens;
    private List<GameObject> inactiveTokens;

	public List<GameObject> txtRestTokens;

    public Token[,] TokensInBoard { set; get; }
    private Token[,] DeadTokens { set; get; }

    private Token selectedToken;

    public GameObject cam, tokenMenu, bkg_p1, bkg_p2, PanelPauseMenu;

    private int spawnLimit;

	private bool turn;

    public void Start()
    {
        activeTokens = new List<GameObject>();
        inactiveTokens = new List<GameObject>();
        TokensInBoard = new Token[8, 16];
		restartGame();
		//SpawnAllTokens();
	}

    private void Update()
    {
        UpdateSelection(Camera.main);
        DrawBoard();

        if (Input.GetMouseButtonDown(0))
        {
            if (selectionX >= 0 && selectionY >= 0)
            {
                if (selectedToken == null)
                {
                    //Seleccionar token;
                    selectToken(selectionX, selectionY);
                }
                else
                {
					if (turn && TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY].isEnemy)
					{
						unselectToken();
						return;
					}
					if (!turn && !TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY].isEnemy)
					{
						unselectToken();
						return;
					}
					//Accion sobre la casilla
					switch (selectedToken.action)
                    {
                        case 0:							

							Attack(selectionX, selectionY);
                            break;
                        case 1:
                            FusionateToken(selectionX, selectionY);
                            break;
                        case 2:
                            MoveToken(selectionX, selectionY);
                            break;
                    }
					unselectToken();
				}
            }
        }
    }

	public void restartGame()
	{
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				TokensInBoard[i, j] = null;
			}
		}

		for (int i = 0; i < 3; i++)
		{
			PanelPauseMenu.transform.GetChild(i).GetComponent<Toggle>().isOn = false;
		}

		foreach (GameObject token in activeTokens)
		{
			Destroy(token);
		}

		foreach (GameObject item in txtRestTokens)
		{
			item.GetComponent<Text>().text = "5";
		}

		cam.GetComponent<Animator>().SetInteger("Win", 0);

		if (turn == false)
		{
			bkg_p2.SetActive(false);
			bkg_p1.SetActive(true);
			turn = true;
		}
	
		Instance = this;
		spawnLimit = 0;
		spawnPosLock = true;
		spawnLimitLock = true;
		spawnPoolLock = true;
	}

    private void selectToken(int x, int y)
    {
        if (TokensInBoard[x, y] == null) return;        

		if (TokensInBoard[x, y].movedOnce) return;		

		selectedToken = TokensInBoard[x, y];

		selectedToken.action = 3;

		tokenMenu.SetActive(true);

		tokenMenu.transform.GetChild(3).GetComponent<Image>().sprite = selectedToken.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;

		tokenMenu.GetComponent<Animator>().SetBool("Visible", true);        		
    }

	public void unselectToken()
	{
		if(tokenMenu.activeSelf) tokenMenu.GetComponent<Animator>().SetBool("Visible", false);
		BoardHighLight.Instance.HideHighlights();
		selectedToken = null;
	}

    public void selectActionToken(int action)
    {
        switch (action)
        {
            case 0:
                BoardHighLight.Instance.HideHighlights();
                selectedToken.action = 0;
                allowedAttack = selectedToken.PossibleAttack();			
				attackPattern = selectedToken.AttackPattern();

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						if(attackPattern[i, j] && allowedAttack[i, j])
						{
							attackPattern[i, j] = false;
						}
					}
				}

				BoardHighLight.Instance.HighlightAllowedAttack(allowedAttack);
				BoardHighLight.Instance.HighlightAllowedAttackPattern(attackPattern);
                break;
            case 1:
                BoardHighLight.Instance.HideHighlights();
                selectedToken.action = 1;
                allowedFusion = selectedToken.PossibleFusion();
				fusionPattern = selectedToken.FusionPattern();

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						if (fusionPattern[i, j] && allowedFusion[i, j])
						{
							fusionPattern[i, j] = false;
						}
					}
				}

				BoardHighLight.Instance.HighlightAllowedFusion(allowedFusion);
				BoardHighLight.Instance.HighlightAllowedFusionPattern(fusionPattern);
				break;
            case 2:
                BoardHighLight.Instance.HideHighlights();   
                selectedToken.action = 2;
                allowedMoves = selectedToken.PossibleMove();
				movementPattern = selectedToken.MovementPattern();

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						if (movementPattern[i, j] && allowedMoves[i, j])
						{
							movementPattern[i, j] = false;
						}
					}
				}

				BoardHighLight.Instance.HighlightAllowedMoves(allowedMoves);
				BoardHighLight.Instance.HighlightAllowedMovesPattern(movementPattern);
				break;
        }
    }

    public void endTurn()
    {
		if(selectedToken) unselectToken();

		for (int i = 0; i < activeTokens.Count; i++)
        {
            if(activeTokens[i]) activeTokens[i].GetComponent<Token>().movedOnce = false;
        }
        spawnLimit = 0;
		if (turn)
		{
			turn = false;
			bkg_p2.SetActive(true);
			bkg_p1.SetActive(false);
		}
		else
		{
			turn = true;
			bkg_p1.SetActive(true);
			bkg_p2.SetActive(false);
		}
        //Cambiar el jugador que puede realizar las acciones
    }   

    private void Attack(int x, int y)
    {
		if (selectedToken.GetComponent<Vulcan>())
		{
			for (int j = 0; j <= 15; j++)
			{
				for (int i = 0; i <= 7; i++)
				{
					if (allowedAttack[i,j])
					{
						if (TokensInBoard[i, j] != null)
						{
							selectedToken.movedOnce = true;

							TokensInBoard[i, j].life -= 1;
							setVisualDamage(TokensInBoard[i, j], true);

							if (TokensInBoard[i, j].life <= 0)
							{
								setNumberTokens(TokensInBoard[i, j].typeToken);

								TokensInBoard[i, j].gameObject.SetActive(false);

								TokensInBoard[TokensInBoard[i, j].CurrentX, TokensInBoard[i, j].CurrentY] = null;
							}																					
						}
					}					
				}
			}
		}		
		else
		{
			if (allowedAttack[x, y])
			{
				Token victim = TokensInBoard[x, y];

				selectedToken.movedOnce = true;

				if (selectedToken.GetComponent<MagicCauldron>())
				{
					if (victim.life == victim.maxLife) return;

					victim.life += 1;

					setVisualDamage(victim, false);
				}
				else
				{
					victim.life -= 1;

					if (victim.life <= 0)
					{
						TokensInBoard[victim.CurrentX, victim.CurrentY] = null;

						inactiveTokens.Add(victim.gameObject);
						activeTokens.Remove(victim.gameObject);

						victim.gameObject.SetActive(false);

						setNumberTokens(victim.typeToken);

						if (selectedToken.meleeAttack)
						{
							selectedToken.gameObject.SetActive(false);
							selectedToken.gameObject.SetActive(true);

							selectedToken.transform.position = GetTile(x, y);

							selectedToken.setPosition(x, y);

							TokensInBoard[x, y] = selectedToken;

							if (selectedToken.CurrentY == 15 && !selectedToken.isEnemy)
							{
								cam.GetComponent<Animator>().SetInteger("Win", 1);
							}
							if (selectedToken.CurrentY == 0 && selectedToken.isEnemy)
							{
								cam.GetComponent<Animator>().SetInteger("Win", 2);
							}
						}
					}
					else
					{
						setVisualDamage(victim, true);

						if (selectedToken.meleeAttack)
						{
							//TODO: Cuando se ataque a  melee y la victima no muera la ficha atacante se acercara lo maximo posible a la victima
							//si lav ictima esta arriba a la derecha
							if(victim.CurrentX > selectedToken.CurrentX && victim.CurrentY > selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX - 1, victim.CurrentY - 1);

								selectedToken.setPosition(victim.CurrentX - 1, victim.CurrentY - 1);

								TokensInBoard[victim.CurrentX - 1, victim.CurrentY - 1] = selectedToken;
							}
							//si la victima esta arriba a la izquierda
							else if(victim.CurrentX < selectedToken.CurrentX && victim.CurrentY > selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX + 1, victim.CurrentY - 1);

								selectedToken.setPosition(victim.CurrentX + 1, victim.CurrentY - 1);

								TokensInBoard[victim.CurrentX + 1, victim.CurrentY - 1] = selectedToken;
							}
							//si la victima esta abajo a la derecha
							else if (victim.CurrentX > selectedToken.CurrentX && victim.CurrentY < selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX - 1, victim.CurrentY + 1);

								selectedToken.setPosition(victim.CurrentX - 1, victim.CurrentY + 1);

								TokensInBoard[victim.CurrentX - 1, victim.CurrentY + 1] = selectedToken;
							}
							//si la victima esta abajo a la izquierda
							else if (victim.CurrentX < selectedToken.CurrentX && victim.CurrentY < selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX + 1, victim.CurrentY - 1);

								selectedToken.setPosition(victim.CurrentX + 1, victim.CurrentY - 1);

								TokensInBoard[victim.CurrentX + 1, victim.CurrentY - 1] = selectedToken;
							}
							//si la victima esta arriba
							else if (victim.CurrentX == selectedToken.CurrentX && victim.CurrentY > selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX, victim.CurrentY - 1);

								selectedToken.setPosition(victim.CurrentX, victim.CurrentY - 1);

								TokensInBoard[victim.CurrentX, victim.CurrentY - 1] = selectedToken;
							}
							//si la victima esta abajo
							else if (victim.CurrentX == selectedToken.CurrentX && victim.CurrentY < selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX, victim.CurrentY + 1);

								selectedToken.setPosition(victim.CurrentX, victim.CurrentY + 1);

								TokensInBoard[victim.CurrentX, victim.CurrentY + 1] = selectedToken;
							}
							//si la victima esta a la izquierda
							else if (victim.CurrentX < selectedToken.CurrentX && victim.CurrentY == selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX + 1, victim.CurrentY);

								selectedToken.setPosition(victim.CurrentX + 1, victim.CurrentY);

								TokensInBoard[victim.CurrentX + 1, victim.CurrentY] = selectedToken;
							}
							//si la victima esta a la derecha
							else if (victim.CurrentX > selectedToken.CurrentX && victim.CurrentY == selectedToken.CurrentY)
							{
								TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

								selectedToken.gameObject.SetActive(false);
								selectedToken.gameObject.SetActive(true);

								selectedToken.transform.position = GetTile(victim.CurrentX - 1, victim.CurrentY);

								selectedToken.setPosition(victim.CurrentX - 1, victim.CurrentY);

								TokensInBoard[victim.CurrentX - 1, victim.CurrentY] = selectedToken;
							}
						}
					}
				}				
			}        
        }
		selectedToken.action = 3;
        unselectToken();
    }

    public void setVisualDamage(Token t, bool damage)
    {
        for (int i = 0; i <= t.life; i++)
        {
            if (i == t.life)
            {//i sera el indice del objeto equivalente a la porcion de vida
				if (damage)
				{
					t.transform.GetChild(t.transform.childCount - 1).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
				}
				else
				{
					t.transform.GetChild(t.transform.childCount - 1).GetChild(0).GetChild(i - 1).GetChild(0).gameObject.SetActive(true);
				}				
            }
        }                    
    }

    private void FusionateToken(int x, int y)
    {
        Token objective = TokensInBoard[x, y];
        if (allowedFusion[x,y])
        {
            TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;
            TokensInBoard[objective.CurrentX, objective.CurrentY] = null;			

			if(!objective.isEnemy)
			{
				if (objective.GetComponent<Horse>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensCentaurP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensDragonP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensGolemP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensRamP1, 0, x, y);
					}
				}
				else if (objective.GetComponent<Archer>())
				{
					if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensCentaurP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensVulcanP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensDefenseTowerP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensCatapultP1, 0, x, y);
					}
				}
				else if (objective.GetComponent<Wizard>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensVulcanP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensDragonP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensAngelP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensMagicCauldronP1, 0, x, y);
					}
				}
				else if (objective.GetComponent<Infantry>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensDefenseTowerP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensAngelP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensGolemP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensWallP1, 0, x, y);
					}
				}
				else if (objective.GetComponent<Builder>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensCatapultP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensMagicCauldronP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensWallP1, 0, x, y);
					}
					else if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensRamP1, 0, x, y);
					}
				}				
			}
			else
			{
				if (objective.GetComponent<Horse>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensCentaurP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensDragonP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensGolemP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensRamP2, 0, x, y);
					}
				}
				else if (objective.GetComponent<Archer>())
				{
					if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensCentaurP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensVulcanP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensDefenseTowerP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensCatapultP2, 0, x, y);
					}
				}
				else if (objective.GetComponent<Wizard>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensVulcanP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensDragonP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensAngelP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensMagicCauldronP2, 0, x, y);
					}
				}
				else if (objective.GetComponent<Infantry>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensDefenseTowerP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensAngelP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensGolemP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Builder>())
					{
						TokenInstance(tokensWallP2, 0, x, y);
					}
				}
				else if (objective.GetComponent<Builder>())
				{
					if (selectedToken.GetComponent<Archer>())
					{
						TokenInstance(tokensCatapultP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Wizard>())
					{
						TokenInstance(tokensMagicCauldronP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Infantry>())
					{
						TokenInstance(tokensWallP2, 0, x, y);
					}
					else if (selectedToken.GetComponent<Horse>())
					{
						TokenInstance(tokensRamP2, 0, x, y);
					}
				}
			}
			selectedToken.gameObject.SetActive(false);
			objective.gameObject.SetActive(false);
		}      
        selectedToken.action = 3;
        unselectToken();
    }

    private void MoveToken(int x, int y)
    {
		if (allowedMoves[x, y])
		{
			selectedToken.movedOnce = true;

			TokensInBoard[selectedToken.CurrentX, selectedToken.CurrentY] = null;

			selectedToken.gameObject.SetActive(false);
			selectedToken.gameObject.SetActive(true);

			selectedToken.transform.position = GetTile(x, y);

			selectedToken.setPosition(x, y);	

			TokensInBoard[x, y] = selectedToken;

			if(selectedToken.CurrentY == 15 && !selectedToken.isEnemy)
			{
				cam.GetComponent<Animator>().SetInteger("Win", 1);
			}
			if(selectedToken.CurrentY == 0 && selectedToken.isEnemy)
			{
				cam.GetComponent<Animator>().SetInteger("Win", 2);
			}
		}
        selectedToken.action = 3;
        unselectToken();
    }

	private void setNumberTokens(int typeToken)
	{
		int iNum = Int32.Parse(txtRestTokens[typeToken].GetComponent<Text>().text);
		iNum += 1;
		txtRestTokens[typeToken].GetComponent<Text>().text = iNum.ToString();
	}

	private void UpdateSelection(Camera c)
    {
        //Si no hay camara cerraremos
        
        if (!c)
        {
            return;
        }
        
        RaycastHit hit;
        /*  Physics.Raycast es un metodo que de evalua si un rayo golpea un objeto
         *
         *  public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask);
         *
         *  siend ray el punto de foco, hitInfo el punto golpeado, maxDistance la distancia maxima que tomoara hitInfo y 
         *  layerMask la capa donde evaluara el golpe   
         */

        if (Physics.Raycast(c.ScreenPointToRay(Input.mousePosition),
            out hit, 25f, LayerMask.GetMask("BoardFisic")))
        {
            /*  en este caso: si desde el mouse en la pantalla se lanza un rayo a la capa del tablero recuperamos la 
             *  informacion del punto golpeado y los selection adoptan dico valor segun sea x o z
             *  
             *  Porque z? Segun la prespectiva de la camara z es y en el mundo
             *  
             *  Mundo:
             *      Y
             *      |   %
             *      |   #
             *      |   #
             *      |   #
             *      ---------- Z
             *      X    
             *      
             *  Camara:
             *      Y
             *      |  #
             *      | #
             *      |#
             *      ----------- Z
             *      X 
             *       rayo:# camara:%
             *       
             *       El eje Y en la camara se podria traducir como la altura y no nos interesa, queremos saber el 
             *       desplazamiento horizontal y vertical
             *  
             */
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else 
        {
            selectionX = -1;
            selectionY = -1;
        }
    }   

    private void TokenInstance(List<GameObject> tokens, int index, int x, int y)//TODO: Pasarle el jugador propietario por parametros
    {
        GameObject instantiate = Instantiate(tokens[index], GetTile(x, y), Quaternion.identity) as GameObject;

        instantiate.transform.SetParent(transform);

        TokensInBoard[x, y] = instantiate.GetComponent<Token>();

        TokensInBoard[x, y].setPosition(x, y);

        activeTokens.Add(instantiate);
    }

	//Spawn modificado para desarrollador
	public void spawnToken(int typeToken, Text num)
	{
		int iNum = Int32.Parse(num.text);

		//Solo podemos instanciar fichas dentro del 
		if (selectionX < 0 || selectionY < 0) return;

		//Solo se puede invocar una ficha en la primera fila
		if (spawnPosLock) { 
			if (turn)
			{
				if (selectionY != 0) return;
			}
			else
			{
				if (selectionY != 15) return;
			}
		}		

		//Si la casilla esta ocupada no se puede invocar una en dicha casilla
		if (TokensInBoard[selectionX, selectionY] != null) return;

		//Solo se pueden invocar 2 fichas por turno
		if (spawnLimitLock)
		{
			if (spawnLimit > 1) return;
		}

		//Solo se pueden invocar 5 fichas
		if (spawnPoolLock)
		{
			if (iNum <= 0) return;
		}

		if (turn)
		{
			switch (typeToken)
			{
				case 0:
					TokenInstance(tokensBuilderP1, 0, selectionX, selectionY);
					break;
				case 1:
					TokenInstance(tokensArcherP1, 0, selectionX, selectionY);
					break;
				case 2:
					TokenInstance(tokensHorseP1, 0, selectionX, selectionY);
					break;
				case 3:
					TokenInstance(tokensWizardP1, 0, selectionX, selectionY);
					break;
				case 4:
					TokenInstance(tokensInfantryP1, 0, selectionX, selectionY);
					break;
			}

		}
		else
		{
			switch (typeToken)
			{
				case 0:
					TokenInstance(tokensBuilderP2, 0, selectionX, selectionY);
					break;
				case 1:
					TokenInstance(tokensArcherP2, 0, selectionX, selectionY);
					break;
				case 2:
					TokenInstance(tokensHorseP2, 0, selectionX, selectionY);
					break;
				case 3:
					TokenInstance(tokensWizardP2, 0, selectionX, selectionY);
					break;
				case 4:
					TokenInstance(tokensInfantryP2, 0, selectionX, selectionY);
					break;
			}
		}
		iNum -= 1;
		num.text = iNum.ToString();
		spawnLimit += 1;
    }

    private void SpawnAllTokens()
    {        
        for (int i = 0; i < tokensBuilderP1.Count; i++)
        {
            //Tokens Player1			
            TokenInstance(tokensBuilderP1, i, i, 0);
            TokenInstance(tokensInfantryP1, i, i, 1);
            TokenInstance(tokensWizardP1, i, i, 2);
            TokenInstance(tokensArcherP1, i, i, 3);
            TokenInstance(tokensHorseP1, i, i, 4);
			

            //Tokens Player2
            TokenInstance(tokensBuilderP2, i, i, 15);
            TokenInstance(tokensInfantryP2, i, i, 14);
            TokenInstance(tokensWizardP2, i, i, 13);
            TokenInstance(tokensArcherP2, i, i, 12);
            TokenInstance(tokensHorseP2, i, i, 11);
        }
    }
    
    private Vector3 GetTileCenter(float x, float y, float z)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.y += (TILE_SIZE * y) + TILE_OFFSET;
        origin.z += (TILE_SIZE * z) + TILE_OFFSET;

        return origin;
    }

    private Vector3 GetTile(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;

        return origin;
    }

    private void DrawBoard()
    {
        /*  Utilizamos los atributos right y forward para comvertir los Vector3 en vectores unitarios
         los cuales seran las medidas del tablero   */
        Vector3 widhtLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 16;

         
        for (int y = 0; y <= 16; y++)
        {
            Vector3 start = Vector3.forward * y;
            Debug.DrawLine(start, start + widhtLine);

            for (int x = 0; x <= 8; x++)
            {
				start = Vector3.right * x;
                Debug.DrawLine(start, start + heightLine);
            }

            if(selectionX >= 0 && selectionY >= 0)
            {				
				Debug.DrawLine(
                    Vector3.forward * selectionY + Vector3.right * selectionX,
                    Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

                Debug.DrawLine(
                   Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                   Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
			}
			
        }
    }
}