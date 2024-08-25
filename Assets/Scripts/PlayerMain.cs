using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public WeaponHandler Player { get; private set; }
    /*public PlayerSwapAimNormal PlayerSwapAimNormal { get; private set; }*/

    public Rigidbody2D PlayerRigidbody2D { get; private set; }

    private void Awake()
    {
        Player = GetComponent<WeaponHandler>();
        /*PlayerSwapAimNormal = GetComponent<PlayerSwapAimNormal>();*/
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
    }


}
