using UnityEngine;

public class Coin : Creature
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out KeepCoins coin))
        {
            coin.SetCoins(1);
        }

        base.Die();
    }
}
