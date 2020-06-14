using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    public static GameManager instance;
    Inventory inventory;

    void Awake()
    {
        instance = this;
        inventory = new Inventory();
    }

    public void CollectItem(Item item)
    {
        inventory.AddItem(item);
    }


    void FixedUpdate()
    {
        player.HorizontalMove(Input.GetAxisRaw("Horizontal"));
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            player.Jump();
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            player.Fall();
        }
    }
}
