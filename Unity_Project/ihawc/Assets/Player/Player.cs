using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Camera Camera;
	XmlRcpSender xmlrcp;
	private string game_user, pass;
	private int game_coins;

	public Text txt_cash;

	public void setGame_user(string _game_user)
	{
		PlayerPrefs.SetString("game_user", _game_user);
		game_user = _game_user;
	}

	public void setPass(string _pass)
	{
		PlayerPrefs.SetString("pass", _pass);
		pass = _pass;
	}

	public void setGameCoins(int _game_coins)
	{
		PlayerPrefs.SetInt("game_coins", _game_coins);
		game_coins = _game_coins;
	}

	public string getGameUser()
	{
		return PlayerPrefs.GetString("game_user");
	}

	public string getPass()
	{
		return PlayerPrefs.GetString("pass");
	}

	public int getGame_coins()
	{
		return PlayerPrefs.GetInt("game_coins");
	}

	private void Start()
	{
		//if(!checkLogged()) Camera.gameObject.GetComponent<Animator>().SetInteger("MenuState", 4);
		xmlrcp = transform.GetComponent<XmlRcpSender>();
		xmlrcp.Login(getGameUser(), getPass());

		txt_cash.text = game_coins.ToString();
	}

	private bool checkLogged()
	{
		bool userLogged;

		if (game_user == null || pass == null)
		{
			userLogged = true;
		}
		else
		{
			userLogged = false;
		}
		return userLogged;
	}

	public void saveUserPrefs(string _game_user, string _pass)
	{
		PlayerPrefs.SetString("game_user", _game_user);
		PlayerPrefs.SetString("pass", _pass);

		game_user = _game_user;
		pass = _pass;
 	}
}
