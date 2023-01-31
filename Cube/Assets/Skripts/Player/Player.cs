using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerControl PlayerControl;
    public Health Health;
    public KeepCoins KeepCoins;
    public Ultimate Ultimate;
    public Upgrade Upgrade;
    
    private void Start()
    {
        PlayerControl = gameObject.GetComponent<PlayerControl>();
        Health = gameObject.GetComponent<Health>();
        KeepCoins = gameObject.GetComponent<KeepCoins>();
        Ultimate = gameObject.GetComponent<Ultimate>();
    }

   
}
