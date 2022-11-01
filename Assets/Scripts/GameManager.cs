using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager Instance { get; private set; }
    #endregion
    public Dictionary<GameObject, Fish> fishContainer;
    public Dictionary<GameObject, Animator> animatorContainer;
    public Dictionary<GameObject, GameOverTrigger> gameOverTriggerContainer;


    private void Awake()
    {
        Instance = this;
        fishContainer = new Dictionary<GameObject, Fish>();
        gameOverTriggerContainer = new Dictionary<GameObject, GameOverTrigger>();
        //buffRecieverContainer = new Dictionary<GameObject, BuffReciever>();
        //itemsContainer = new Dictionary<GameObject, ItemComponent>();
    }

    public void OnClickPause()
    {
        if (Time.timeScale > 0)
        {
            //inventoryPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            //inventoryPanel.gameObject.SetActive(false);
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(0);
    }

    /*
    private void Start()
    {
        var healthObjects = FindObjectsOfType<Health>();
        foreach (var health in healthObjects)
        {
            healthContainer.Add(health.gameObject, health);
        }
    }
    */
}
