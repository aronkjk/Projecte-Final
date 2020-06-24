using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Token
{
	public void Start()
	{
		life = 1;
		typeToken = 4;
	}

	public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 16];

        WizardMove(CurrentX + 1, CurrentY -1, ref r);

        WizardMove(CurrentX - 1, CurrentY -1, ref r);

        WizardMove(CurrentX - 1, CurrentY + 1, ref r);
    
        WizardMove(CurrentX + 1, CurrentY + 1, ref r);

        WizardMove(CurrentX, CurrentY + 2, ref r);

        WizardMove(CurrentX - 2, CurrentY, ref r);

        WizardMove(CurrentX, CurrentY - 2, ref r);

        WizardMove(CurrentX + 2, CurrentY , ref r);

        return r;
    }

	private void WizardMove(int x, int y, ref bool[,] r)
		{
			Token t;
			if(x >= 0 && x < 8 && y >= 0 && y < 16)
			{
				t = BoarManager.Instance.TokensInBoard[x, y];
				if(t == null)
				{
					r[x, y] = true;
				}
			}
		}

	public override bool[,] MovementPattern()
	{
		bool[,] r = new bool[8, 16];

		WizardMovementPattern(CurrentX + 1, CurrentY - 1, ref r);

		WizardMovementPattern(CurrentX - 1, CurrentY - 1, ref r);

		WizardMovementPattern(CurrentX - 1, CurrentY + 1, ref r);

		WizardMovementPattern(CurrentX + 1, CurrentY + 1, ref r);

		WizardMovementPattern(CurrentX, CurrentY + 2, ref r);

		WizardMovementPattern(CurrentX - 2, CurrentY, ref r);

		WizardMovementPattern(CurrentX, CurrentY - 2, ref r);

		WizardMovementPattern(CurrentX + 2, CurrentY, ref r);

		return r;
	}    

	private void WizardMovementPattern(int x, int y, ref bool[,] r)
	{
		if (x >= 0 && x < 8 && y >= 0 && y < 16)
		{
			r[x, y] = true;
		}
	}

	public override bool[,] PossibleAttack()
	{
		bool[,] r = new bool[8, 16];
		Token t;

		if (!isEnemy)
		{
			//Atacar recto
			if (CurrentY != 15)
			{
				if (CurrentY + 3 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 3];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX, CurrentY + 3] = true;
						}
					}
				}			
			}

			//Atacar atras
			if (CurrentY != 0)
			{
				if (CurrentY - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 3];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX, CurrentY - 3] = true;
						}
					}
				}
			}

			//Atacar derecha
			if (CurrentX != 7)
			{
				if (CurrentX + 3 <= 7)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 3, CurrentY] = true;
						}
					}
				}
			}

			//Atacar izquierda
			if (CurrentX != 0)
			{
				if (CurrentX - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 3, CurrentY] = true;
						}
					}
				}
			}

			//Atacar izquierda arriba 
			if (CurrentX != 0 && CurrentY != 15)
			{
				if (CurrentX - 1 >= 0 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY + 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 1, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX - 2 >= 0 && CurrentY + 1 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY + 1];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 2, CurrentY + 1] = true;
						}
					}
				}
			}

			//Atacar derecha arriba 
			if (CurrentX != 7 && CurrentY != 15)
			{
				if (CurrentX + 1 <= 7 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY + 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 1, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX + 2 <= 7 && CurrentY + 1 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY + 1];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 2, CurrentY + 1] = true;
						}
					}
				}
			}

			//Atacar izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				if (CurrentX - 1 >= 0 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 1, CurrentY - 2] = true;
						}
					}
				}
				if (CurrentX - 2 >= 0 && CurrentY - 1 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY - 1];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 2, CurrentY - 1] = true;
						}
					}
				}
			}

			//Atacar derecha abajo 
			if (CurrentX != 7 && CurrentY != 0)
			{
				if (CurrentX + 2 <= 7 && CurrentY - 1 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY - 1];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 2, CurrentY - 1] = true;
						}
					}
				}
				if (CurrentX + 1 <= 7 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 1, CurrentY - 2] = true;
						}
					}
				}
			}
		}
		else
		{
			//Atacar recto
			if (CurrentY != 15)
			{
				if (CurrentY + 3 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 3];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX, CurrentY + 3] = true;
						}
					}
				}
			}

			//Atacar atras
			if (CurrentY != 0)
			{
				if (CurrentY - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 3];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX, CurrentY - 3] = true;
						}
					}
				}
			}

			//Atacar derecha
			if (CurrentX != 7)
			{
				if (CurrentX + 3 <= 7)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 3, CurrentY] = true;
						}
					}
				}
			}

			//Atacar izquierda
			if (CurrentX != 0)
			{
				if (CurrentX - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 3, CurrentY] = true;
						}
					}
				}
			}

			//Atacar izquierda arriba 
			if (CurrentX != 0 && CurrentY != 15)
			{
				if (CurrentX - 1 >= 0 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY + 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 1, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX - 2 >= 0 && CurrentY + 1 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY + 1];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 2, CurrentY + 1] = true;
						}
					}
				}
			}

			//Atacar derecha arriba 
			if (CurrentX != 7 && CurrentY != 15)
			{
				if (CurrentX + 1 <= 7 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY + 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 1, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX + 2 <= 7 && CurrentY + 1 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY + 1];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 2, CurrentY + 1] = true;
						}
					}
				}
			}

			//Atacar izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				if (CurrentX - 1 >= 0 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 1, CurrentY - 2] = true;
						}
					}
				}
				if (CurrentX - 2 >= 0 && CurrentY - 1 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY - 1];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 2, CurrentY - 1] = true;
						}
					}
				}
			}

			//Atacar derecha abajo 
			if (CurrentX != 7 && CurrentY != 0)
			{
				if (CurrentX + 2 <= 7 && CurrentY - 1 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY - 1];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 2, CurrentY - 1] = true;
						}
					}
				}
				if (CurrentX + 1 <= 7 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 1, CurrentY - 2] = true;
						}
					}
				}
			}
		}

		return r;
	}

	public override bool[,] AttackPattern()
	{
		bool[,] r = new bool[8, 16];

		//Atacar recto
		if (CurrentY != 15)
		{
			if (CurrentY + 3 <= 15)
			{
				r[CurrentX, CurrentY + 3] = true;
			}
		}

		//Atacar atras
		if (CurrentY != 0)
		{
			if (CurrentY - 3 >= 0)
			{
				r[CurrentX, CurrentY - 3] = true;
			}
		}

		//Atacar derecha
		if (CurrentX != 7)
		{
			if (CurrentX + 3 <= 7)
			{
				r[CurrentX + 3, CurrentY] = true;
			}
		}

		//Atacar izquierda
		if (CurrentX != 0)
		{
			if (CurrentX - 3 >= 0)
			{
				r[CurrentX - 3, CurrentY] = true;
			}
		}

		//Atacar izquierda arriba 
		if (CurrentX != 0 && CurrentY != 15)
		{
			if (CurrentX - 1 >= 0 && CurrentY + 2 <= 15)
			{
				r[CurrentX - 1, CurrentY + 2] = true;
			}
			if (CurrentX - 2 >= 0 && CurrentY + 1 <= 15)
			{
				r[CurrentX - 2, CurrentY + 1] = true;
			}
		}

		//Atacar derecha arriba 
		if (CurrentX != 7 && CurrentY != 15)
		{
			if (CurrentX + 1 <= 7 && CurrentY + 2 <= 15)
			{
				r[CurrentX + 1, CurrentY + 2] = true;
			}
			if (CurrentX + 2 <= 7 && CurrentY + 1 <= 15)
			{
				r[CurrentX + 2, CurrentY + 1] = true;
			}
		}

		//Atacar izquierda abajo
		if (CurrentX != 0 && CurrentY != 0)
		{
			if (CurrentX - 1 >= 0 && CurrentY - 2 >= 0)
			{
				r[CurrentX - 1, CurrentY - 2] = true;
			}
			if (CurrentX - 2 >= 0 && CurrentY - 1 >= 0)
			{
				r[CurrentX - 2, CurrentY - 1] = true;
			}
		}

		//Atacar derecha abajo 
		if (CurrentX != 7 && CurrentY != 0)
		{
			if (CurrentX + 2 <= 7 && CurrentY - 1 >= 0)
			{
				r[CurrentX + 2, CurrentY - 1] = true;
			}
			if (CurrentX + 1 <= 7 && CurrentY - 2 >= 0)
			{					
				r[CurrentX + 1, CurrentY - 2] = true;
			}
		}		

		return r;
	}

	public override bool[,] PossibleFusion()
	{
		bool[,] r = new bool[8, 16];
		Token t;

		if (!isEnemy)
		{
			//Fusionarse con el de adelante
			if (CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 1];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX, CurrentY + moveVerticalUp] = true;
						}
					}
				}
			}

			//Fusionarse con el de atras
			if (CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX, CurrentY - moveVerticalDown] = true;
						}
					}
				}
			}

			//Fusionarse con el de la derecha
			if (CurrentX != 7)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX + moveHorizontalRight, CurrentY] = true;
						}
					}
				}
			}

			//Fusionarse con el de la izquierda
			if (CurrentX != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX - moveHorizontalLeft, CurrentY] = true;
						}
					}
				}
			}

			//Fusionarse con el de la diagonal izquierda arriba
			if (CurrentX != 0 && CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY + 1];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX - moveDiagonalUpLeft, CurrentY + moveDiagonalUpLeft] = true;
						}
					}
				}
			}

			//Fusionarse con el de la diagonal derecha arriba
			if (CurrentX != 7 && CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY + 1];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX + moveDiagonalUpRight, CurrentY + moveDiagonalUpRight] = true;
						}
					}
				}
			}


			//Fusionarse con el de diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX - moveDiagonalDownLeft, CurrentY - moveDiagonalDownLeft] = true;
						}
					}
				}
			}

			//Fusionarse con el de diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1];
				if (t)
				{
					if (!t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX + moveDiagonalDownRight, CurrentY - moveDiagonalDownRight] = true;
						}
					}
				}
			}
		}
		else
		{
			//Fusionarse con el de adelante
			if (CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 1];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX, CurrentY + moveVerticalUp] = true;
						}
					}
				}
			}

			//Fusionarse con el de atras
			if (CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX, CurrentY - moveVerticalDown] = true;
						}
					}
				}
			}

			//Fusionarse con el de la derecha
			if (CurrentX != 7)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX + moveHorizontalRight, CurrentY] = true;
						}
					}
				}
			}

			//Fusionarse con el de la izquierda
			if (CurrentX != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX - moveHorizontalLeft, CurrentY] = true;
						}
					}
				}
			}

			//Fusionarse con el de la diagonal izquierda arriba
			if (CurrentX != 0 && CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY + 1];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX - moveDiagonalUpLeft, CurrentY + moveDiagonalUpLeft] = true;
						}
					}
				}
			}

			//Fusionarse con el de la diagonal derecha arriba
			if (CurrentX != 7 && CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY + 1];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX + moveDiagonalUpRight, CurrentY + moveDiagonalUpRight] = true;
						}
					}
				}
			}


			//Fusionarse con el de diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX - moveDiagonalDownLeft, CurrentY - moveDiagonalDownLeft] = true;
						}
					}
				}
			}

			//Fusionarse con el de diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1];
				if (t)
				{
					if (t.isEnemy)
					{
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Infantry>() ||
						t.gameObject.GetComponent<Archer>() || t.gameObject.GetComponent<Builder>())
						{
							r[CurrentX + moveDiagonalDownRight, CurrentY - moveDiagonalDownRight] = true;
						}
					}
				}
			}
		}

		return r;
	}

	public override bool[,] FusionPattern()
	{
		bool[,] r = new bool[8, 16];

		//Fusionarse con el de adelante
		if (CurrentY != 15)
		{
			r[CurrentX, CurrentY + moveVerticalUp] = true;
		}

		//Fusionarse con el de atras
		if (CurrentY != 0)
		{
			r[CurrentX, CurrentY - moveVerticalDown] = true;
		}

		//Fusionarse con el de la derecha
		if (CurrentX != 7)
		{
			r[CurrentX + moveHorizontalRight, CurrentY] = true;
		}

		//Fusionarse con el de la izquierda
		if (CurrentX != 0)
		{
			r[CurrentX - moveHorizontalLeft, CurrentY] = true;
		}

		//Fusionarse con el de la diagonal izquierda arriba
		if (CurrentX != 0 && CurrentY != 15)
		{
			r[CurrentX - moveDiagonalUpLeft, CurrentY + moveDiagonalUpLeft] = true;
		}

		//Fusionarse con el de la diagonal derecha arriba
		if (CurrentX != 7 && CurrentY != 15)
		{
			r[CurrentX + moveDiagonalUpRight, CurrentY + moveDiagonalUpRight] = true;
		}


		//Fusionarse con el de diagonal izquierda abajo
		if (CurrentX != 0 && CurrentY != 0)
		{
			r[CurrentX - moveDiagonalDownLeft, CurrentY - moveDiagonalDownLeft] = true;
		}

		//Fusionarse con el de diagonal derecha abajo
		if (CurrentX != 7 && CurrentY != 0)
		{

			r[CurrentX + moveDiagonalDownRight, CurrentY - moveDiagonalDownRight] = true;
		}

		return r;
	}
}
