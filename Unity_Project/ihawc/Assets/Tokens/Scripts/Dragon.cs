using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Token
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 16];
		Token t;

		int i, j;

		if (!isEnemy)
		{
			//Mover arriba
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
			}

			//Mover abajo
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
			}


			//Mover diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1];
				if (t == null)
				{
					r[CurrentX - 1, CurrentY - 1] = true;
				}
			}

			//Mover diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1];
				if (t == null)
				{
					r[CurrentX + 1, CurrentY - 1] = true;
				}
			}
		}
		else
		{
			//Mover abajo
			i = CurrentY;
			while (true)
			{
				i--;
				if (i < 0 || CurrentY - i == 4) break;

				t = BoarManager.Instance.TokensInBoard[CurrentX, i];
				if (t == null)
				{
					r[CurrentX, i] = true;
				}
			}

			//Mover arriba
			if (CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 1];
				if (t == null)
				{
					r[CurrentX, CurrentY + 1] = true;
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
			}


			//Mover diagonal derecha abajo
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j--;
				if (i >= 8 || j < 0 || CurrentY - j == 4) break;

				t = BoarManager.Instance.TokensInBoard[i, j];
				if (t == null)
				{
					r[i, j] = true;
				}
			}


			//Mover diagonal izquierda arriba
			if (CurrentX != 0 && CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY + 1];
				if (t == null)
				{
					r[CurrentX - 1, CurrentY + 1] = true;
				}
			}

			//Mover diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY + 1];
				if (t == null)
				{
					r[CurrentX + 1, CurrentY + 1] = true;
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
			if (CurrentY != 15)
			{
				r[CurrentX, CurrentY + 1] = true;
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

			//Mover diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				r[CurrentX - 1, CurrentY - 1] = true;
			}

			//Mover diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				r[CurrentX + 1, CurrentY - 1] = true;
			}
		}
		else
		{
			//Mover abajo
			i = CurrentY;
			while (true)
			{
				i--;
				if (i < 0 || CurrentY - i == 4) break;

				r[CurrentX, i] = true;
			}

			//Mover arriba
			if (CurrentY != 15)
			{
				r[CurrentX, CurrentY + 1] = true;
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
				if (i >= 8 || j < 0 || CurrentY - j == 4) break;

				r[i, j] = true;
			}

			//Mover diagonal izquierda arriba
			if (CurrentX != 0 && CurrentY != 15)
			{
				r[CurrentX - 1, CurrentY + 1] = true;
			}

			//Mover diagonal derecha arriba
			if (CurrentX != 7 && CurrentY != 15)
			{
				r[CurrentX + 1, CurrentY + 1] = true;
			}
		}


		return r;
	}

	public override bool[,] PossibleAttack()
	{
		bool[,] r = new bool[8, 16];
		Token t;

		int i, j;


		//Atacar recto
		i = CurrentY;
		while (true)
		{
			i++;
			if (i >= 16 || CurrentY - i == -4) break;

			t = BoarManager.Instance.TokensInBoard[CurrentX, i];
			if (t)
			{
				if (t.isEnemy)
				{
					r[CurrentX, i] = true;
					break;
				}
			}
		}

		//Atacar atras
		if (CurrentY != 0)
		{
			t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1];
			if (t)
			{
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
			t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
			if (t)
			{
				if (t.isEnemy)
				{
					r[CurrentX + 1, CurrentY] = true;
				}
			}
		}

		//Atacar izquierda
		if (CurrentX != 0)
		{
			t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
			if (t)
			{
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

			t = BoarManager.Instance.TokensInBoard[i, j];
			if (t)
			{
				if (t)
				{
					if (t.isEnemy)
					{
						r[i, j] = true;
						break;
					}
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

			t = BoarManager.Instance.TokensInBoard[i, j];
			if (t)
			{
				if (t.isEnemy)
				{
					r[i, j] = true;
					break;
				}
			}
		}


		//Atacar diagonal izquierda abajo
		if (CurrentX != 0 && CurrentY != 0)
		{
			t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1];
			if (t)
			{
				if (t.isEnemy)
				{
					r[CurrentX - 1, CurrentY - 1] = true;
				}
			}
		}

		//Atacar diagonal derecha abajo
		if (CurrentX != 7 && CurrentY != 0)
		{
			t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1];
			if (t)
			{
				if (t.isEnemy)
				{
					r[CurrentX + 1, CurrentY - 1] = true;
				}
			}
		}
		return r;
	}

	public override bool[,] AttackPattern()
	{
		bool[,] r = new bool[8, 16];

		int i, j;

		if (!isEnemy)
		{
			//Atacar arriba
			i = CurrentY;
			while (true)
			{
				i++;
				if (i >= 16 || CurrentY - i == -4) break;

				r[CurrentX, i] = true;
			}

			//Atacar abajo
			if (CurrentY != 0)
			{
				r[CurrentX, CurrentY - 1] = true;
			}


			//Atacar derecha
			i = CurrentX;
			if (CurrentX != 7)
			{
				r[CurrentX + 1, CurrentY] = true;
			}

			//Atacar izquierda
			if (CurrentX != 0)
			{
				r[CurrentX - 1, CurrentY] = true;
			}

			//Atacar diagonal izquierda arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j++;
				if (i < 0 || j >= 16 || CurrentY - j == -4) break;

				r[i, j] = true;
			}


			//Atacar diagonal derecha arriba
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j++;
				if (i >= 8 || j >= 16 || CurrentY - j == -4) break;

				r[i, j] = true;
			}


			//Atacar diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				r[CurrentX - 1, CurrentY - 1] = true;
			}

			//Atacar diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				r[CurrentX + 1, CurrentY - 1] = true;
			}
		}
		else
		{
			//Atacar abajo
			i = CurrentY;
			while (true)
			{
				i--;
				if (i < 0 || CurrentY - i == 4) break;

				r[CurrentX, i] = true;
			}

			//Atacar arriba
			if (CurrentY != 15)
			{
				r[CurrentX, CurrentY + 1] = true;
			}


			//Atacar derecha
			i = CurrentX;
			if (CurrentX != 7)
			{
				r[CurrentX + 1, CurrentY] = true;
			}

			//Atacar izquierda
			if (CurrentX != 0)
			{
				r[CurrentX - 1, CurrentY] = true;
			}

			//Atacar diagonal izquierda abajo
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i--;
				j--;
				if (i < 0 || j < 0 || CurrentY - j == 4) break;

				r[i, j] = true;
			}


			//Atacar diagonal derecha abajo
			i = CurrentX;
			j = CurrentY;
			while (true)
			{
				i++;
				j--;
				if (i >= 8 || j < 0 || CurrentY - j == 4) break;

				r[i, j] = true;
			}


			//Atacar diagonal izquierda arriba
			if (CurrentX != 0 && CurrentY != 15)
			{
				r[CurrentX - 1, CurrentY + 1] = true;
			}

			//Atacar diagonal derecha arriba
			if (CurrentX != 7 && CurrentY != 15)
			{
				r[CurrentX + 1, CurrentY + 1] = true;
			}
		}

		return r;
	}

}

