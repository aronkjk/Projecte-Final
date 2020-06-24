using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Token
{
    public void Start()
    {
        life = 1;
		typeToken = 0;
	}

    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 16];
        Token t;

        int i, j;

		if (!isEnemy)
		{
			//Mover recto
			i = CurrentY;
			while (true)
			{
				i++;
				if (i >= 16 || CurrentY - i == -4) break;

				t = BoarManager.Instance.TokensInBoard[CurrentX, i];
				if (t == null)
				{
					r[CurrentX, i] = true;
				}
				else
				{
					break;
				}
			}

			//Mover atras
			if (CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1];
				if (t == null)
				{
					r[CurrentX, CurrentY - 1] = true;
				}
			}


			//Mover derecha
			i = CurrentX;
			if (CurrentX != 7)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
				if (t == null)
				{
					r[CurrentX + 1, CurrentY] = true;
				}
			}

			//Mover izquierda
			if (CurrentX != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
				if (t == null)
				{
					r[CurrentX - 1, CurrentY] = true;
				}
			}

			//Mover diagonal izquierda arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j++;
				if (i < 0 || j >= 16 || CurrentY - j == -4) break;

				t = BoarManager.Instance.TokensInBoard[i, j];
				if (t == null)
				{
					r[i, j] = true;
				}
				else
				{
					break;
				}
			}


			//Mover diagonal derecha arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j++;
				if (i >= 8 || j >= 16 || CurrentY - j == -4) break;

				t = BoarManager.Instance.TokensInBoard[i, j];
				if (t == null)
				{
					r[i, j] = true;
				}
				else
				{
					break;
				}
			}
		}
		else
		{
			i = CurrentY;

			//Mover recto
			if (CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 1];
				if (t == null)
				{
					r[CurrentX, CurrentY + 1] = true;
				}
			}


			//Mover atras
			while (true)
			{
				i--;
				if (i >= 16 || CurrentY - i == 4) break;

				t = BoarManager.Instance.TokensInBoard[CurrentX, i];
				if (t == null)
				{
					r[CurrentX, i] = true;
				}
				else
				{
					break;
				}
			}


			//Mover derecha
			i = CurrentX;
			if (CurrentX != 7)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
				if (t == null)
				{
					r[CurrentX + 1, CurrentY] = true;
				}
			}

			//Mover izquierda
			if (CurrentX != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
				if (t == null)
				{
					r[CurrentX - 1, CurrentY] = true;
				}
			}

			//Mover diagonal izquierda abajo
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j--;
				if (i < 0 || j < 0 || CurrentY - j == 4) break;

				t = BoarManager.Instance.TokensInBoard[i, j];
				if (t == null)
				{
					r[i, j] = true;
				}
				else
				{
					break;
				}
			}


			//Mover diagonal derecha abajo
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j--;
				if (i >= 8 || j <= 0 || CurrentY - j == 4) break;

				t = BoarManager.Instance.TokensInBoard[i, j];
				if (t == null)
				{
					r[i, j] = true;
				}
				else
				{
					break;
				}
			}
		}
        return r;
    }

	public override bool[,] MovementPattern()
	{
		bool[,] r = new bool[8, 16];

		int i, j;

		if (!isEnemy)
		{
			//Mover recto
			i = CurrentY;
			while (true)
			{
				i++;
				if (i >= 16 || CurrentY - i == -4) break;

				r[CurrentX, i] = true;
			}

			//Mover atras
			if (CurrentY != 0)
			{
				r[CurrentX, CurrentY - 1] = true;
			}


			//Mover derecha
			i = CurrentX;
			if (CurrentX != 7)
			{
				r[CurrentX + 1, CurrentY] = true;
			}

			//Mover izquierda
			if (CurrentX != 0)
			{
				r[CurrentX - 1, CurrentY] = true;
			}

			//Mover diagonal izquierda arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j++;
				if (i < 0 || j >= 16 || CurrentY - j == -4) break;

				r[i, j] = true;
			}


			//Mover diagonal derecha arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j++;
				if (i >= 8 || j >= 16 || CurrentY - j == -4) break;

				r[i, j] = true;
			}
		}
		else
		{
			i = CurrentY;

			//Mover recto
			if (CurrentY != 15)
			{
				r[CurrentX, CurrentY + 1] = true;
			}


			//Mover atras
			while (true)
			{
				i--;
				if (i >= 16 || CurrentY - i == 4) break;

				r[CurrentX, i] = true;
			}


			//Mover derecha
			i = CurrentX;
			if (CurrentX != 7)
			{
				r[CurrentX + 1, CurrentY] = true;
			}

			//Mover izquierda
			if (CurrentX != 0)
			{
				r[CurrentX - 1, CurrentY] = true;
			}

			//Mover diagonal izquierda abajo
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j--;
				if (i < 0 || j < 0 || CurrentY - j == 4) break;

				r[i, j] = true;
			}


			//Mover diagonal derecha abajo
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j--;
				if (i >= 8 || j <= 0 || CurrentY - j == 4) break;

				r[i, j] = true;
			}
		}
		return r;
	}

	public override bool[,] PossibleAttack()
    {
		Token t;
		bool[,] r = new bool[8, 16];        
        int i, j;

		if (!isEnemy) {
			//Atacar recto
			i = CurrentY;
			while (true)
			{
				i++;
				//Algo raro huele aqui
				if (i >= 16 || CurrentY - i == -4) break;

				if (BoarManager.Instance.TokensInBoard[CurrentX, i] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, i];
					if (t.isEnemy)
					{
						r[CurrentX, i] = true;
						break;
					}
				}
				else
				{
					break;
				}
			}

			//Atacar atras
			if (CurrentY != 0)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1];
					if (t.isEnemy)
					{
						r[CurrentX, CurrentY - 1] = true;
					}
				}
			}


			//Atacar derecha
			i = CurrentX;
			if (CurrentX != 7)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
					if (t.isEnemy)
					{
						r[CurrentX + 1, CurrentY] = true;
					}
				}
			}

			//Atacar izquierda
			if (CurrentX != 0)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
					if (t.isEnemy)
					{
						r[CurrentX - 1, CurrentY] = true;
					}
				}
			}

			//Atacar diagonal izquierda arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j++;
				if (i < 0 || j >= 16 || CurrentY - j == -4) break;
				if (BoarManager.Instance.TokensInBoard[i, j] != null)
				{
					t = BoarManager.Instance.TokensInBoard[i, j];
					if (t.isEnemy)
					{
						r[i, j] = true;
						break;
					}
					else
					{
						break;
					}
				}
			}


			//Atacar diagonal derecha arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j++;
				if (i >= 8 || j >= 16 || CurrentY - j == -4) break;

				if (BoarManager.Instance.TokensInBoard[i, j] != null)
				{
					t = BoarManager.Instance.TokensInBoard[i, j];
					if (t.isEnemy)
					{
						r[i, j] = true;
						break;
					}
					else
					{
						break;
					}
				}
			}


			//Atacar diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1];
					if (t.isEnemy)
					{
						r[CurrentX - 1, CurrentY - 1] = true;
					}
				}
			}

			//Mover diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1];
					if (t.isEnemy)
					{
						r[CurrentX + 1, CurrentY - 1] = true;
					}
				}
			}
		}
		else
		{
			//Atacar recto
			i = CurrentY;
			while (true)
			{
				i++;
				if (i >= 16 || CurrentY - i == -4) break;

				if (BoarManager.Instance.TokensInBoard[CurrentX, i] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, i];
					if (!t.isEnemy)
					{
						r[CurrentX, i] = true;
						break;
					}
				}
				else
				{
					break;
				}
			}

			//Atacar atras
			if (CurrentY != 0)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1];
					if (!t.isEnemy)
					{
						r[CurrentX, CurrentY - 1] = true;
					}
				}
			}


			//Atacar derecha
			i = CurrentX;
			if (CurrentX != 7 && CurrentY != 15)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
					if (!t.isEnemy)
					{
						r[CurrentX + 1, CurrentY] = true;
					}
				}
			}

			//Atacar izquierda
			if (CurrentX != 0 && CurrentY != 15)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
					if (!t.isEnemy)
					{
						r[CurrentX - 1, CurrentY] = true;
					}
				}
			}

			//Atacar diagonal izquierda arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j++;
				if (i < 0 || j >= 16 || CurrentY - j == -4) break;
				if (BoarManager.Instance.TokensInBoard[i, j] != null)
				{
					t = BoarManager.Instance.TokensInBoard[i, j];
					if (!t.isEnemy)
					{
						r[i, j] = true;
						break;
					}
					else
					{
						break;
					}
				}
			}


			//Atacar diagonal derecha arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j++;
				if (i >= 8 || j >= 16 || CurrentY - j == -4) break;

				if (BoarManager.Instance.TokensInBoard[i, j] != null)
				{
					t = BoarManager.Instance.TokensInBoard[i, j];
					if (!t.isEnemy)
					{
						r[i, j] = true;
						break;
					}
					else
					{
						break;
					}
				}
			}


			//Atacar diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1];
					if (!t.isEnemy)
					{
						r[CurrentX - 1, CurrentY - 1] = true;
					}
				}
			}

			//Mover diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				if (BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1] != null)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1];
					if (!t.isEnemy)
					{
						r[CurrentX + 1, CurrentY - 1] = true;
					}
				}
			}
		}
        
        return r;
    }

	public override bool[,] AttackPattern()
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Horse>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
						if (t.gameObject.GetComponent<Infantry>() || t.gameObject.GetComponent<Wizard>() ||
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
