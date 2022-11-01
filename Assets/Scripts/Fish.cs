using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        GameManager.Instance.fishContainer.Add(gameObject, this);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}