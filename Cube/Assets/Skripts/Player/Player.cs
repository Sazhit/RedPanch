using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
#endif

public class Player : MonoBehaviour
{
    public PlayerControl PlayerControl;
    public Health Health;
    public KeepCoins KeepCoins;
    public Ultimate Ultimate;

    [SerializeField] private Dictionary<string, int> upgrade = new Dictionary<string, int>();

    public List<KeyValueElement> GetQuantity()
    {
        var quantity = new List<KeyValueElement>(upgrade.Count);
        foreach (var item in upgrade)
        {
            quantity.Add(new KeyValueElement(item.Key, item.Value)); 
        }
        return quantity;
    }

    public int GetUpgrade(string key)
    {
        if (upgrade.ContainsKey(key))
        {
            return upgrade[key];
        }
        upgrade.Add(key, 0);
        return 0;
    }

    public void AddUpgrade(string key, int quantity)
    {
        if (upgrade.ContainsKey(key))
        {
            upgrade[key] += quantity;
        }
        else
        {
            upgrade.Add(key, quantity);
        }  
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if(data == null)
        {
            return;
        }
        PlayerControl.GravityForce = data.GravityForce;
        Ultimate.SkillsCooldown = data.Cooldown;
        Health.MaxHealth = data.MaxHealth;
        KeepCoins.Coins = data.Coins;
        upgrade = new Dictionary<string, int>();

        foreach (var item in data.Quantity)
        {
            upgrade.Add(item.Key, item.Value);
        }
    }


}

//[System.Serializable] public class CustomDictionary : SerializableDictionary<string, int> { }

//#if UNITY_EDITOR

//[CustomPropertyDrawer(typeof(CustomDictionary))] // Name of your class (same as above)
//public class CustomDictionaryDrawer : DictionaryDrawer<string, int> { }
//#endif 