using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : Token
{
    public override bool[,] PossibleMove()
    {
		bool[,] r = new bool[8, 16];
		Token t;

		int i;

		if (!isEnemy)
		{
			//Mover recto
			i = CurrentY;
			while (true)
			{
				i++;
				if (i > 15 || CurrentY - i == -7) break;

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
		}
		else
		{
			//Mover recto
			i = CurrentY;
			while (true)
			{
				i--;
				if (i < 1 || CurrentY - i == 7) break;

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
		}
		
		return r;
    }

    public override bool[,] PossibleAttack()
    {
        bool[,] r = new bool[8, 16];
        Token t;

        int i;

		if (!isEnemy)
		{
			//Atacar recto
			i = CurrentY;
			while (true)
			{
				i++;
				if (i > 15 || CurrentY - i == -7) break;

				t = BoarManager.Instance.TokensInBoard[CurrentX, i];
				if (t)
				{
					if (t.isEnemy)
					{
						r[CurrentX, i] = true;
						break;
					}
					else
					{
						break;
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
				i--;
				if (i < 1 || CurrentY - i == 7) break;

				t = BoarManager.Instance.TokensInBoard[CurrentX, i];
				if (t)
				{
					if (!t.isEnemy)
					{
						r[CurrentX, i] = true;
						break;
					}
					else
					{
						break;
					}
				}
			}
		}
        
		return r;
    }

	public override bool[,] MovementPattern()
	{
		bool[,] r = new bool[8, 16];

		int i;

		if (!isEnemy)
		{
			//Mover recto
			i = CurrentY;
			while (true)
			{
				i++;
				if (i > 15 || CurrentY - i == -7) break;

				r[CurrentX, i] = true;
			}
		}
		else
		{
			//Mover recto
			i = CurrentY;
			while (true)
			{
				i--;
				if (i < 1 || CurrentY - i == 7) break;

				r[CurrentX, i] = true;
			}
		}

		return r;
	}

	public override bool[,] AttackPattern()
	{
		bool[,] r = new bool[8, 16];
		Token t;

		int i;

		if (!isEnemy)
		{
			//Atacar recto
			i = CurrentY;
			while (true)
			{
				i++;
				if (i > 15 || CurrentY - i == -7) break;

				t = BoarManager.Instance.TokensInBoard[CurrentX, i];

				r[CurrentX, i] = true;
			}
		}
		else
		{
			//Atacar recto
			i = CurrentY;
			while (true)
			{
				i--;
				if (i < 1 || CurrentY - i == 7) break;

				t = BoarManager.Instance.TokensInBoard[CurrentX, i];

				r[CurrentX, i] = true;
			}
		}

		return r;
	}

}

