using UnityEngine;

public class Token : MonoBehaviour
{
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    public int action { set; get; }
    public int life, maxLife;
	public int typeToken { set; get; }
	public bool movedOnce{ set; get; }
    public bool isEnemy, meleeAttack;

    //Direcciones
    public static int moveHorizontalRight = 1, moveHorizontalLeft = 1, moveVerticalUp = 1, moveVerticalDown = 1,
        moveDiagonalUpRight = 1, moveDiagonalUpLeft = 1, moveDiagonalDownRight = 1, moveDiagonalDownLeft = 1;

    public void setPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public virtual bool[,] PossibleMove()
    {
        return new bool[8, 16];
    }

    public virtual bool[,] PossibleAttack()
    {
        return new bool[8, 16];
    }

    public virtual bool[,] PossibleFusion()
    {
        return new bool[8, 16];
    }

	public virtual bool[,] MovementPattern()
	{
		return new bool[8, 16];
	}

	public virtual bool[,] AttackPattern()
	{
		return new bool[8, 16];
	}

	public virtual bool[,] FusionPattern()
	{
		return new bool[8, 16];
	}
}
