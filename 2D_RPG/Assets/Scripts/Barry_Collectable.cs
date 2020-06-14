using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barry_Collectable : MonoBehaviour
{
    [SerializeField] private string itemTag;
    [SerializeField] Item itemSelf;
    Animator animator;
    SpriteRenderer spriteRenderer;
    string sortingLayerName = "Fx";
    bool isCollected = false;

    public string ItemTag { get => itemTag; }

    private void Awake()
    {


        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void fxEnd()
    {
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;
        Collected();
    }

    private void Collected()
    {
        isCollected = true;
        ShowFx();
        SendSelfToGameManager();
    }

    private void ShowFx()
    {
        animator.SetTrigger("OnCollected");
        spriteRenderer.sortingLayerName = sortingLayerName;
    }

    private void SendSelfToGameManager()
    {
        GameManager.instance.CollectItem(itemSelf);
    }
}
