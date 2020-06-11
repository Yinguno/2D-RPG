using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    void Start()
    {

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
