[System.Serializable]
public class PlayerData 
{
    public float GravityForce;
    public float Cooldown;
    public float MaxHealth;
    public int Coins;
    public int Quantity;

    public PlayerData(ShopsItem player)
    {
        GravityForce = player.PlayerControl.GravityForce;
        MaxHealth = player.Health.MaxHealth;
        Coins = player.KeepCoins.Coins;
        Cooldown = player.Ultimate.SkillsCooldown;
    }
}
    
