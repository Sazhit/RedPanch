using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataUpbgrade 
{
    public int Quantity;

    public DataUpbgrade(Upgrade upgrade)
    {
        Quantity = upgrade.Quantity;
    }
}
