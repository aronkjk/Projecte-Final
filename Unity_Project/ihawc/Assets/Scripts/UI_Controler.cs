using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controler : MonoBehaviour
{
	
    public static UI_Controler instance;

	//Elementos del Menu
    public GameObject PanelTokens, PanelMainMenu, PanelPauseMenu, ButtonPause, Board, 
        Camera, PanelConfirmPurchase, PanelPack, PanelSingles, PanelMessageError;

	//Los tokens
	public GameObject tokenHorse, tokenInfantry, tokenBuilder, tokenWizard, tokenArcher, tokenAngel, tokenCatapult,
		tokenCentaur, tokenDragon, tokenGolem, tokenMagicCauldron, tokenRam, tokenDefenseTower, tokenVulcan, tokenWall;

	//Seccion de personalizacion
	public GameObject PanelCustomizer, PanelCustomizeTokens,
		HorseCustomizer, WizardCustomizer, ArcherCustomizer, InfantryCustomizer,
		BuilderCustomizer, AngelCustomizer, CatapultCustomizer, CentaurCustomizer,
		DragonCustomizer, GolemCustomizer, MagicCauldronCustomizer, RamCustomizer,
		DefenseTowerCustomizer, VulcanCustomizer, WallCustomizer;

	public InputField game_user, pass;
	public Text txt_cash;
	public Player player;
	public XmlRcpSender xmlrpc;

	private bool isLoguin, isCreateUser;

	private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

	public void closeApp()
	{
		Application.Quit();
	}

	public void goMenu()
	{
		Camera.gameObject.GetComponent<Animator>().SetInteger("MenuState", 0);
		Board.gameObject.SetActive(false);
	}

	public void goGame()
    {
		Board.gameObject.SetActive(true);
		Camera.gameObject.GetComponent<Animator>().SetInteger("MenuState", 3);
		Camera.gameObject.GetComponent<Animator>().SetBool("Pause", false);
	}

	public void goLobby()
	{
		Camera.gameObject.GetComponent<Animator>().SetInteger("MenuState", 3);
		Camera.gameObject.GetComponent<Animator>().SetBool("Pause", false);
	}    

    public void goStore()
    {
        Camera.gameObject.GetComponent<Animator>().SetInteger("MenuState", 2);        
    }

    public void goCustomizer()
    {
        Camera.gameObject.GetComponent<Animator>().SetInteger("MenuState", 1);
    }        

	//Compras

    public void goConfirmPurchase(int typeAction)
    {
		if(typeAction == 5)
		{
			PanelConfirmPurchase.SetActive(false);
		}
		else
		{
			PanelConfirmPurchase.SetActive(true);
			PanelConfirmPurchase.GetComponent<PurchaseManager>().setPurchase(typeAction);
		}          
    }	
	
	//Ajustes en el juego
	public void setPause(bool open)
	{
		if (open)
		{
			Camera.gameObject.GetComponent<Animator>().SetBool("Pause", true);
		}
		else
		{
			Camera.gameObject.GetComponent<Animator>().SetBool("Pause", false);
		}

	}

	public void setSpawnPosLock(bool enabled)
	{
		Board.GetComponent<BoarManager>().spawnPosLock = enabled;
	}

	public void setsPawnLimitLock(bool enabled)
	{
		Board.GetComponent<BoarManager>().spawnLimitLock = enabled;
	}

	public void setSpawnPoolLock(bool enabled)
	{
		Board.GetComponent<BoarManager>().spawnPoolLock = enabled;
	}

	public void PlayAgain()
	{	
		Camera.gameObject.GetComponent<Animator>().SetTrigger("PlayAgain");
	}

	//Botones de los ajustes

	public void goSettings()
	{
		Camera.gameObject.GetComponent<Animator>().SetInteger("MenuState", 4);
		game_user.text = player.getGameUser();
		pass.text = player.getPass();	
	}

	public void savePreferences()
	{
		game_user.interactable = false;
		pass.interactable = false;

		if (isCreateUser)
		{
			xmlrpc.CreateUser(game_user.text, pass.text);
			isCreateUser = false;
		}

		if (isLoguin)
		{
			xmlrpc.Login(game_user.text, pass.text);
			isLoguin = false;
		}

		player.saveUserPrefs(game_user.text, pass.text);
		txt_cash.text = player.getGame_coins().ToString();
	}

	public void enableLogin()
	{
		game_user.interactable = true;
		pass.interactable = true;
		isLoguin = true;
	}

	public void enableCreateUser()
	{
		game_user.interactable = true;
		pass.interactable = true;
		isCreateUser = true;
	}

	public void closeMessageError()
	{
		for (int i = 0; i < PanelMessageError.transform.childCount; i++)
		{
			PanelMessageError.transform.GetChild(i).gameObject.SetActive(false);
		}
		
	}

	//Abrir y cerrar cada panel de personalizacion de los Tokens
	//Tenia pensado crear una sola funcion de este tipo y pasarle por parametros el Panel y el token, pero no se puede(solo tipos primitivos?)
	public void horseCustomizer(bool open)
    {
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			HorseCustomizer.SetActive(true);
			HorseCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenHorse.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			HorseCustomizer.SetActive(false);
		}
        
    }
    public void wizardCustomizer(bool open)
    {
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			WizardCustomizer.SetActive(true);
			WizardCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenWizard.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			WizardCustomizer.SetActive(false);
		}
    }
    public void archerCustomizer(bool open)
    {
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			ArcherCustomizer.SetActive(true);
			ArcherCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenArcher.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			ArcherCustomizer.SetActive(false);
		}
    }
    public void infantryCustomizer(bool open)
    {
		if(open)
		{
			PanelCustomizeTokens.SetActive(false);
			InfantryCustomizer.SetActive(true);
			InfantryCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenInfantry.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			InfantryCustomizer.SetActive(false);
		}
    }
    public void builderCustomizer(bool open)
    {
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			BuilderCustomizer.SetActive(true);
			BuilderCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenBuilder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			BuilderCustomizer.SetActive(false);
		}
        
    }
	public void angelCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			AngelCustomizer.SetActive(true);
			AngelCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenAngel.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			AngelCustomizer.SetActive(false);
		}
	}
	public void catapultCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			CatapultCustomizer.SetActive(true);
			CatapultCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenCatapult.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			CatapultCustomizer.SetActive(false);
		}
		
	}
	public void centaurCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			CentaurCustomizer.SetActive(true);
			CentaurCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenCentaur.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			CentaurCustomizer.SetActive(false);
		}
	}
	public void dragonCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			DragonCustomizer.SetActive(true);
			DragonCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenDragon.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			DragonCustomizer.SetActive(false);
		}
	}
	public void golemCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			GolemCustomizer.SetActive(true);
			GolemCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenGolem.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			GolemCustomizer.SetActive(false);
		}
		
	}
	public void magicCauldronCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			MagicCauldronCustomizer.SetActive(true);
			MagicCauldronCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenMagicCauldron.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			MagicCauldronCustomizer.SetActive(false);
		}
		
	}
	public void ramCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			RamCustomizer.SetActive(true);
			RamCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenRam.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			RamCustomizer.SetActive(false);
		}
		
	}
	public void defenseTowerCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			DefenseTowerCustomizer.SetActive(true);
			DefenseTowerCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenDefenseTower.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			DefenseTowerCustomizer.SetActive(false);
		}
		
	}
	public void vulcanCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			VulcanCustomizer.SetActive(true);
			VulcanCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenVulcan.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			VulcanCustomizer.SetActive(false);
		}
		
	}
	public void wallCustomizer(bool open)
	{
		if (open)
		{
			PanelCustomizeTokens.SetActive(false);
			WallCustomizer.SetActive(true);
			WallCustomizer.transform.GetChild(3).GetComponent<Image>().sprite = tokenWall.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
		else
		{
			PanelCustomizeTokens.SetActive(true);
			WallCustomizer.SetActive(false);
		}
		
	}
}
