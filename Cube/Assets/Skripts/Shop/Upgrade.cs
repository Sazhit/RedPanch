using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public string Name;
    public int Cost;
    public Sprite Sprite;
    public int MaxQuantity;
}
