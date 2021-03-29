using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject LvlMenu;
    public GameObject ConMenu;
    public GameObject CredMenu;
    // Start is called before the first frame update
    void Start()
    {
        showMainMenu();
        hideControls();
        hideCredits();
        hideLvlSelect();
    }

   public void showMainMenu()
    {
        MainMenu.SetActive(true);
    }

   public void hideMainMenu()
    {
        MainMenu.SetActive(false);
    }

    public void showLvlSelect()
    {
        LvlMenu.SetActive(true);
    }

    public void hideLvlSelect()
    {
        LvlMenu.SetActive(false);
    }

    public void showControls()
    {
        ConMenu.SetActive(true);
    }

    public void hideControls()
    {
        ConMenu.SetActive(false);
    }

    public void showCredits()
    {
        CredMenu.SetActive(true);
    }

    public void hideCredits()
    {
        CredMenu.SetActive(false);
    }

    //kathy...function added to exit the game from the main menu
    public void quitGame()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
