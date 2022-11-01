using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void OnClickRetry()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
