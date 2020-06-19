using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan : Token
{
	public override bool[,] PossibleAttack()
	{
		bool[,] r = new bool[8, 16];
		Token t;


		//Atacar recto
		if (CurrentY != 15)
		{
			if (CurrentY + 1 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 1];
				if (t)
				{
					r[CurrentX, CurrentY + 1] = true;
				}
			}
			if (CurrentY + 2 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 2];
				if (t)
				{
					r[CurrentX, CurrentY + 2] = true;						
				}
			}
			if (CurrentY + 4 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 4];
				if (t)
				{
					r[CurrentX, CurrentY + 4] = true;
				}
			}
		}

		//Atacar atras
		if (CurrentY != 0)
		{
			if (CurrentY - 1 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 1];
				if (t)
				{
					r[CurrentX, CurrentY - 1] = true;
				}
			}
			if (CurrentY - 2 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 2];
				if (t)
				{
					r[CurrentX, CurrentY - 2] = true;
				}
			}
			if (CurrentY - 4 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY - 4];
				if (t)
				{
					r[CurrentX, CurrentY - 4] = true;
				}
			}
		}

		//Atacar derecha
		if (CurrentX != 7)
		{
			if (CurrentX + 1 <= 7)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
				if (t)
				{
					r[CurrentX + 1, CurrentY] = true;
				}
			}
			if (CurrentX + 2 <= 7)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY];
				if (t)
				{
					r[CurrentX + 2, CurrentY] = true;
				}
			}
			if (CurrentX + 4 <= 7)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 4, CurrentY];
				if (t)
				{
					r[CurrentX + 4, CurrentY] = true;
				}
			}
		}

		//Atacar izquierda
		if (CurrentX != 0)
		{
			if (CurrentX - 1 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
				if (t)
				{
					r[CurrentX - 1, CurrentY] = true;
				}
			}
			if (CurrentX - 2 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY];
				if (t)
				{
					r[CurrentX - 2, CurrentY] = true;
				}
			}
			if (CurrentX - 4 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 4, CurrentY];
				if (t)
				{
					r[CurrentX - 4, CurrentY] = true;
				}
			}
		}

		//Atacar izquierda arriba
		if (CurrentX != 0 && CurrentY != 15)
		{
			if (CurrentX - 1 >= 0 && CurrentY + 1 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY + 1];
				if (t)
				{
					r[CurrentX - 1, CurrentY + 1] = true;
				}
			}
			if (CurrentX - 3 >= 0 && CurrentY + 3 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY + 3];
				if (t)
				{
					r[CurrentX - 3, CurrentY + 3] = true;
				}
			}
			if (CurrentX - 2 >= 0 && CurrentY + 1 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY + 1];
				if (t)
				{
					r[CurrentX - 2, CurrentY + 1] = true;
				}
			}
			if (CurrentX - 1 >= 0 && CurrentY + 2 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY + 2];
				if (t)
				{
					r[CurrentX - 1, CurrentY + 2] = true;
				}
			}
		}

		//Atacar derecha arriba
		if (CurrentX != 7 && CurrentY != 15)
		{
			if (CurrentX + 1 <= 7 && CurrentY + 1 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY + 1];
				if (t)
				{
					r[CurrentX + 1, CurrentY + 1] = true;
				}
			}
			if (CurrentX + 3 <= 7 && CurrentY + 3 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY + 3];
				if (t)
				{
					r[CurrentX + 3, CurrentY + 3] = true;
				}
			}
			if (CurrentX + 1 <= 7 && CurrentY + 2 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY + 2];
				if (t)
				{
					r[CurrentX + 1, CurrentY + 2] = true;
				}
			}
			if (CurrentX + 2 <= 7 && CurrentY + 1 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY + 1];
				if (t)
				{
					r[CurrentX + 2, CurrentY + 1] = true;
				}
			}
		}

		//Atacar izquierda abajo
		if (CurrentX != 0 && CurrentY != 0)
		{
			if (CurrentX - 1 >= 0 && CurrentY - 1 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 1];
				if (t)
				{
					r[CurrentX - 1, CurrentY - 1] = true;
				}
			}
			if (CurrentX - 3 >= 0 && CurrentY - 3 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 3, CurrentY - 3];
				if (t)
				{
					r[CurrentX - 3, CurrentY - 3] = true;
				}
			}
			if (CurrentX - 1 <= 7 && CurrentY - 2 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY - 2];
				if (t)
				{
					r[CurrentX - 1, CurrentY - 2] = true;
				}
			}
			if (CurrentX - 2 <= 7 && CurrentY - 1 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX - 2, CurrentY - 1];
				if (t)
				{
					r[CurrentX - 2, CurrentY - 1] = true;
				}
			}
		}

		//Atacar derecha abajo
		if (CurrentX != 7 && CurrentY != 0)
		{
			if (CurrentX + 1 >= 0 && CurrentY - 1 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 1];
				if (t)
				{
					r[CurrentX + 1, CurrentY - 1] = true;
				}
			}
			if (CurrentX + 3 <= 7 && CurrentY - 3 >= 0)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 3, CurrentY - 3];
				if (t)
				{
					r[CurrentX + 3, CurrentY - 3] = true;
				}
			}
			if (CurrentX + 1 <= 7 && CurrentY - 2 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY - 2];
				if (t)
				{
					r[CurrentX + 1, CurrentY - 2] = true;
				}
			}
			if (CurrentX + 2 <= 7 && CurrentY - 1 <= 15)
			{
				t = BoarManager.Instance.TokensInBoard[CurrentX + 2, CurrentY - 1];
				if (t)
				{
					r[CurrentX + 2, CurrentY - 1] = true;
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
			if (CurrentY + 1 <= 15)
			{
				r[CurrentX, CurrentY + 1] = true;
			}
			if (CurrentY + 2 <= 15)
			{
				r[CurrentX, CurrentY + 2] = true;
			}
			if (CurrentY + 4 <= 15)
			{
				r[CurrentX, CurrentY + 4] = true;
			}
		}

		//Atacar atras
		if (CurrentY != 0)
		{
			if (CurrentY - 1 >= 0)
			{
				r[CurrentX, CurrentY - 1] = true;
			}
			if (CurrentY - 2 >= 0)
			{
				r[CurrentX, CurrentY - 2] = true;
			}
			if (CurrentY - 4 >= 0)
			{
				r[CurrentX, CurrentY - 4] = true;
			}
		}

		//Atacar derecha
		if (CurrentX != 7)
		{
			if (CurrentX + 1 <= 7)
			{
				r[CurrentX + 1, CurrentY] = true;
			}
			if (CurrentX + 2 <= 7)
			{
				r[CurrentX + 2, CurrentY] = true;				
			}
			if (CurrentX + 4 <= 7)
			{
				r[CurrentX + 4, CurrentY] = true;
			}
		}

		//Atacar izquierda
		if (CurrentX != 0)
		{
			if (CurrentX - 1 >= 0)
			{
				r[CurrentX - 1, CurrentY] = true;
			}
			if (CurrentX - 2 >= 0)
			{
				r[CurrentX - 2, CurrentY] = true;				
			}
			if (CurrentX - 4 >= 0)
			{
				r[CurrentX - 4, CurrentY] = true;				
			}
		}

		//Atacar izquierda arriba
		if (CurrentX != 0 && CurrentY != 15)
		{
			if (CurrentX - 1 >= 0 && CurrentY + 1 <= 15)
			{
				r[CurrentX - 1, CurrentY + 1] = true;
			}
			if (CurrentX - 3 >= 0 && CurrentY + 3 <= 15)
			{
				r[CurrentX - 3, CurrentY + 3] = true;
			}			
			if (CurrentX - 2 >= 0 && CurrentY + 1 <= 15)
			{
				r[CurrentX - 2, CurrentY + 1] = true;
			}
			if (CurrentX - 1 >= 0 && CurrentY + 2 <= 15)
			{				
				r[CurrentX - 1, CurrentY + 2] = true;
			}
		}

		//Atacar derecha arriba
		if (CurrentX != 7 && CurrentY != 15)
		{
			if (CurrentX + 1 <= 7 && CurrentY + 1 <= 15)
			{
				r[CurrentX + 1, CurrentY + 1] = true;				
			}
			if (CurrentX + 3 <= 7 && CurrentY + 3 <= 15)
			{
				r[CurrentX + 3, CurrentY + 3] = true;				
			}
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
			if (CurrentX - 1 >= 0 && CurrentY - 1 >= 0)
			{
				r[CurrentX - 1, CurrentY - 1] = true;				
			}
			if (CurrentX - 3 >= 0 && CurrentY - 3 >= 0)
			{
				r[CurrentX - 3, CurrentY - 3] = true;				
			}
			if (CurrentX - 1 <= 7 && CurrentY - 2 <= 15)
			{
				r[CurrentX - 1, CurrentY - 2] = true;				
			}
			if (CurrentX - 2 <= 7 && CurrentY - 1 <= 15)
			{
				r[CurrentX - 2, CurrentY - 1] = true;				
			}
		}

		//Atacar derecha abajo
		if (CurrentX != 7 && CurrentY != 0)
		{
			if (CurrentX + 1 >= 0 && CurrentY - 1 >= 0)
			{
				r[CurrentX + 1, CurrentY - 1] = true;				
			}
			if (CurrentX + 3 <= 7 && CurrentY - 3 >= 0)
			{
				r[CurrentX + 3, CurrentY - 3] = true;				
			}
			if (CurrentX + 1 <= 7 && CurrentY - 2 <= 15)
			{
				r[CurrentX + 1, CurrentY - 2] = true;				
			}
			if (CurrentX + 2 <= 7 && CurrentY - 1 <= 15)
			{
				r[CurrentX + 2, CurrentY - 1] = true;				
			}
		}

		return r;
	}
}

