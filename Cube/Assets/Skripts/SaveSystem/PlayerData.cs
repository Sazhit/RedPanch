using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData 
{
    public float GravityForce;
    public float Cooldown;
    public float MaxHealth;
    public int Coins;
    public List<KeyValueElement>  Quantity;
    public PlayerData()
    {

    }

    public PlayerData(Player player)
    {
        GravityForce = player.PlayerControl.GravityForce;
        MaxHealth = player.Health.MaxHealth;
        Coins = player.KeepCoins.Coins;
        Cooldown = player.Ultimate.SkillsCooldown;
        Quantity = player.GetQuantity();
    }
}

[System.Serializable]
public class KeyValueElement
{
    public string Key;
    public int Value;
    public KeyValueElement()
    {
    }

    public KeyValueElement(string key, int value)
    {
        Key = key;
        Value = value;
    }
}
