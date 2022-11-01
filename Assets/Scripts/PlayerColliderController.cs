using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerColliderController : MonoBehaviour
{
    public int fishCount;
    [SerializeField] private Text fishText;
    public PlayerController playerController;
    [SerializeField] Animator animator;
    public GameObject gameOverMenu;

    private void Start()
    {
        fishText.text = fishCount.ToString();

    }
    public static PlayerColliderController Instance { get; set; }
    private void OnTriggerEnter(Collider col)
    {
        if (GameManager.Instance.fishContainer.ContainsKey(col.gameObject))
        {
            fishCount = fishCount + 10;
            fishText.text = fishCount.ToString();
            var coin = GameManager.Instance.fishContainer[col.gameObject];
            coin.Destroy();

        }
        if (GameManager.Instance.gameOverTriggerContainer.ContainsKey(col.gameObject))
        {
            playerController.speed = 0f;
            playerController.leftrightSpeed = 0f;

            animator.SetBool("FallAnimation", true);
            StartCoroutine(GameOverMenuSetVisible());
            
            



        }
    
    }
    private IEnumerator GameOverMenuSetVisible()
    {

        yield return new WaitForSeconds(2);
        gameOverMenu.SetActive(true);
    }
}