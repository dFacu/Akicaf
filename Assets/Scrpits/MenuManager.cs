using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private Button buttonNewGame, buttonContinueG, buttonExit, buttonMenu, buttonSetting, buttonReturn;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (buttonNewGame)
        {
            buttonNewGame.GetComponent<Button>().onClick.AddListener(() => { 
                gameManager.ChangeScene("Juego"); 
            });
        }
        if (buttonContinueG)
        {
            buttonContinueG.GetComponent<Button>().onClick.AddListener(() => { 
                gameManager.ChangeScene("Juego"); 
            });
        }
        if (buttonExit)
        {
            buttonExit.GetComponent<Button>().onClick.AddListener(() => {
                Application.Quit();
                Debug.Log("Saliste");

            });
        }
        if (buttonMenu)
        {
            buttonMenu.GetComponent<Button>().onClick.AddListener(() => {
                gameManager.ChangeScene("Menu");

            });
        }
        if (buttonSetting)
        {
            buttonSetting.GetComponent<Button>().onClick.AddListener(() => {
                gameManager.ChangeScene("Setting");
            });
        }
        if(buttonReturn)
        {
            buttonReturn.GetComponent<Button>().onClick.AddListener(() =>{
                gameManager.ChangeScene("Menu");
            });
        }
    }
}
