using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCannon : Token
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 16];

        WashSpiritMove(CurrentX + 2, CurrentY - 2, ref r);

        WashSpiritMove(CurrentX - 2, CurrentY - 2, ref r);

        WashSpiritMove(CurrentX - 2, CurrentY + 2, ref r);

        WashSpiritMove(CurrentX + 2, CurrentY + 2, ref r);

        WashSpiritMove(CurrentX, CurrentY + 2, ref r);

        WashSpiritMove(CurrentX - 2, CurrentY, ref r);

        WashSpiritMove(CurrentX, CurrentY - 2, ref r);

        WashSpiritMove(CurrentX + 2, CurrentY, ref r);

        return r;
    }

    public void WashSpiritMove(int x, int y, ref bool[,] r)
    {
        Token t;
        if (x >= 0 && x < 8 && y >= 0 && y < 16)
        {
            t = BoarManager.Instance.TokensInBoard[x, y];
            if (t == null)
            {
                r[x, y] = true;
            }
        }
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
                }
                else
                {
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
        if (CurrentX != 7 && CurrentY != 15)
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
        if (CurrentX != 0 && CurrentY != 15)
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
                    }
                    else
                    {
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

    /*
    public override bool[,] PossibleFusion()
    {
        bool[,] r = new bool[8, 16];
        Token t;

        int i;

        //Fusionarse con el de adelante
        if (CurrentY != 15)
        {
            t = BoarManager.Instance.TokensInBoard[CurrentX, CurrentY + 1];
            if (t)
            {
                if (!t.isEnemy)
                {
                    r[CurrentX, CurrentY + moveVerticalUp] = true;
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
                    r[CurrentX, CurrentY - moveVerticalDown] = true;
                }
            }
        }

        //Fusionarse con el de la derecha
        i = CurrentX;
        if (CurrentX != 7 && CurrentY != 15)
        {
            t = BoarManager.Instance.TokensInBoard[CurrentX + 1, CurrentY];
            if (t)
            {
                if (!t.isEnemy)
                {
                    r[CurrentX + moveHorizontalRight, CurrentY] = true;
                }
            }
        }

        //Fusionarse con el de la izquierda
        if (CurrentX != 0 && CurrentY != 15)
        {
            t = BoarManager.Instance.TokensInBoard[CurrentX - 1, CurrentY];
            if (t)
            {
                if (!t.isEnemy)
                {
                    r[CurrentX - moveHorizontalLeft, CurrentY] = true;
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
                    r[CurrentX - moveDiagonalUpLeft, CurrentY + moveDiagonalUpLeft] = true;
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
                    r[CurrentX + moveDiagonalUpRight, CurrentY + moveDiagonalUpRight] = true;
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
                    r[CurrentX - moveDiagonalDownLeft, CurrentY - moveDiagonalDownLeft] = true;
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
                    r[CurrentX + moveDiagonalDownRight, CurrentY - moveDiagonalDownRight] = true;
                }
            }
        }
        return r;
    }*/
}

