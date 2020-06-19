using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : Token
{
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
				if (CurrentY + 4 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 4];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX, CurrentY + 4] = true;
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
				if (CurrentY - 4 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 4];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX, CurrentY - 4] = true;
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
				if (CurrentY + 4 <= 7)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 4, CurrentY];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 4, CurrentY] = true;
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
				if (CurrentX - 4 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 4, CurrentY];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 4, CurrentY] = true;
						}
					}
				}
			}

			//Atacar diagonal izquierda arriba
			if (CurrentX != 0 && CurrentY != 15)
			{
				if (CurrentX - 2 >= 0 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY + 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 2, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX - 3 >= 0 && CurrentY + 3 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY + 3];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 3, CurrentY + 3] = true;
						}
					}
				}
			}

			//Atacar diagonal derecha arriba
			if (CurrentX != 7 && CurrentY != 15)
			{
				if (CurrentX + 2 <= 7 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY + 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 2, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX + 3 <= 7 && CurrentY + 3 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY + 3];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 3, CurrentY + 3] = true;
						}
					}
				}
			}

			//Atacar diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				if (CurrentX - 2 >= 0 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY - 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 2, CurrentY - 2] = true;
						}
					}
				}
				if (CurrentX - 3 >= 0 && CurrentY - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY - 3];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX - 3, CurrentY - 3] = true;
						}
					}
				}
			}

			//Atacar diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				if (CurrentX + 2 <= 7 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY - 2];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 2, CurrentY - 2] = true;
						}
					}
				}
				if (CurrentX + 3 <= 7 && CurrentY - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY - 3];
					if (t)
					{
						if (t.isEnemy)
						{
							r[CurrentX + 3, CurrentY - 3] = true;
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
				if (CurrentY + 4 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 4];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX, CurrentY + 4] = true;
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
				if (CurrentY - 4 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 4];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX, CurrentY - 4] = true;
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
				if (CurrentY + 4 <= 7)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 4, CurrentY];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 4, CurrentY] = true;
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
				if (CurrentX - 4 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 4, CurrentY];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 4, CurrentY] = true;
						}
					}
				}
			}

			//Atacar diagonal izquierda arriba
			if (CurrentX != 0 && CurrentY != 15)
			{
				if (CurrentX - 2 >= 0 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY + 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 2, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX - 3 >= 0 && CurrentY + 3 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY + 3];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 3, CurrentY + 3] = true;
						}
					}
				}
			}

			//Atacar diagonal derecha arriba
			if (CurrentX != 7 && CurrentY != 15)
			{
				if (CurrentX + 2 <= 7 && CurrentY + 2 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY + 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 2, CurrentY + 2] = true;
						}
					}
				}
				if (CurrentX + 3 <= 7 && CurrentY + 3 <= 15)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY + 3];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 3, CurrentY + 3] = true;
						}
					}
				}
			}

			//Atacar diagonal izquierda abajo
			if (CurrentX != 0 && CurrentY != 0)
			{
				if (CurrentX - 2 >= 0 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY - 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 2, CurrentY - 2] = true;
						}
					}
				}
				if (CurrentX - 3 >= 0 && CurrentY - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY - 3];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX - 3, CurrentY - 3] = true;
						}
					}
				}
			}

			//Atacar diagonal derecha abajo
			if (CurrentX != 7 && CurrentY != 0)
			{
				if (CurrentX + 2 <= 7 && CurrentY - 2 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY - 2];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 2, CurrentY - 2] = true;
						}
					}
				}
				if (CurrentX + 3 <= 7 && CurrentY - 3 >= 0)
				{
					t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY - 3];
					if (t)
					{
						if (!t.isEnemy)
						{
							r[CurrentX + 3, CurrentY - 3] = true;
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
			if (CurrentY + 4 <= 15)
			{
				r[CurrentX, CurrentY + 4] = true;
			}
		}

		//Atacar atras
		if (CurrentY != 0)
		{
			if (CurrentY - 3 >= 0)
			{
				r[CurrentX, CurrentY - 3] = true;
			}
			if (CurrentY - 4 >= 0)
			{
				r[CurrentX, CurrentY - 4] = true;
			}
		}

		//Atacar derecha
		if (CurrentX != 7)
		{
			if (CurrentX + 3 <= 7)
			{
				r[CurrentX + 3, CurrentY] = true;
			}
			if (CurrentX + 4 <= 7)
			{
				r[CurrentX + 4, CurrentY] = true;
			}
		}

		//Atacar izquierda
		if (CurrentX != 0)
		{
			if (CurrentX - 3 >= 0)
			{
				r[CurrentX - 3, CurrentY] = true;
			}
			if (CurrentX - 4 >= 0)
			{
				r[CurrentX - 4, CurrentY] = true;
			}
		}

		//Atacar diagonal izquierda arriba
		if (CurrentX != 0 && CurrentY != 15)
		{
			if (CurrentX - 2 >= 0 && CurrentY + 2 <= 15)
			{
				r[CurrentX - 2, CurrentY + 2] = true;
			}
			if (CurrentX - 3 >= 0 && CurrentY + 3 <= 15)
			{
				r[CurrentX - 3, CurrentY + 3] = true;
			}
		}

		//Atacar diagonal derecha arriba
		if (CurrentX != 7 && CurrentY != 15)
		{
			if (CurrentX + 2 <= 7 && CurrentY + 2 <= 15)
			{
				r[CurrentX + 2, CurrentY + 2] = true;
			}
			if (CurrentX + 3 <= 7 && CurrentY + 3 <= 15)
			{
				r[CurrentX + 3, CurrentY + 3] = true;
			}
		}

		//Atacar diagonal izquierda abajo
		if (CurrentX != 0 && CurrentY != 0)
		{
			if (CurrentX - 2 >= 0 && CurrentY - 2 >= 0)
			{
				r[CurrentX - 2, CurrentY - 2] = true;
			}
			if (CurrentX - 3 >= 0 && CurrentY - 3 >= 0)
			{
				r[CurrentX - 3, CurrentY - 3] = true;
			}
		}

		//Atacar diagonal derecha abajo
		if (CurrentX != 7 && CurrentY != 0)
		{
			if (CurrentX + 2 <= 7 && CurrentY - 2 >= 0)
			{
				r[CurrentX + 2, CurrentY - 2] = true;
			}
			if (CurrentX + 3 <= 7 && CurrentY - 3 >= 0)
			{
				r[CurrentX + 3, CurrentY - 3] = true;
			}
		}

		return r;
	}

}

