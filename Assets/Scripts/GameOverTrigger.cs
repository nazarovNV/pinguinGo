using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.gameOverTriggerContainer.Add(gameObject, this);
    }

    
}
