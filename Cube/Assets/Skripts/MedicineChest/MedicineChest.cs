using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineChest : Creature
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.ApplyDamage(-health.MaxHealth);
        }

        base.Die();
    }
}
