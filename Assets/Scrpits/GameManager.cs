using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;

    private void Awake()
    {
        Instance = FindObjectOfType<GameManager>();

        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


}
