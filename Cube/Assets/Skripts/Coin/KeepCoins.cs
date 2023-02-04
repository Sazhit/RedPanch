using UnityEngine;
using TMPro;

public class KeepCoins : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private int _coins;
    [SerializeField] private TextMeshProUGUI _coinText;

    public int Coins
    {
        get => _coins;
        set
        {
            if (_coins <= 0)
            {
                _coins = 0;
            }
            else
            {
                _coins = value;
            }
        }
    }

    private void Start()
    {
        SetCoins(0);
    }

    public void SetCoins(int cost)
    {
        _coins += cost;
        _coinText.text = "" + _coins.ToString();
        _player.SavePlayer();
    }
}
