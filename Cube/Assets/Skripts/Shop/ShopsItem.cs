using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopsItem : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Upgrade[] _upgrades;

    [SerializeField] private GameObject _shopUI;
    [SerializeField] private TextMeshProUGUI _shopCoinText;

    [SerializeField] private Transform _shopContent;
    [SerializeField] private GameObject _itemPrefab;

    private const string ImprovementGravityForce = "GravityForce";
    private const string ImprovementMaxHealth = "MaxHealth";
    private const string ImprovementCooldawn = "Cooldown";

    private void Start()
    {
        //_player.LoadPlayer();
        foreach (Upgrade upgrade in _upgrades)
        {
            GameObject item = Instantiate(_itemPrefab, _shopContent);

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = _player.GetUpgrade(upgrade.Name).ToString();
                }
                else if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = "$" + upgrade.Cost.ToString();
                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.Name;
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.Sprite;
                }
            }

            item.GetComponent<Button>().onClick.AddListener(() => BuyUpgrade(upgrade, item.transform));
        }
    }

    private void BuyUpgrade(Upgrade upgrade, Transform item)
    {
        if (_player.KeepCoins.Coins >= upgrade.Cost && _player.GetUpgrade(upgrade.Name) < upgrade.MaxQuantity)
        {
            _player.KeepCoins.SetCoins(-upgrade.Cost);
            _player.AddUpgrade(upgrade.Name, 1);
            
           item.GetChild(0).GetComponent<TextMeshProUGUI>().text = _player.GetUpgrade(upgrade.Name).ToString();

            ApplyUpgrade(upgrade);
        }
    }

    private void ApplyUpgrade(Upgrade upgrade)
    {
        switch (upgrade.Name)
        {
            case ImprovementGravityForce:
                _player.PlayerControl.GravityForce += 1;
                break;
            case ImprovementMaxHealth:
                _player.Health.MaxHealth += 5;
                break;
            case ImprovementCooldawn:
                _player.Ultimate.SkillsCooldown -= 1;
                break;
        }
    }

    public void ToNextScene(int scene)
    {
        SceneManager.LoadScene(scene);
        _player.SavePlayer();
    }

    private void OnGUI()
    {
        _shopCoinText.text = _player.KeepCoins.Coins.ToString();
    }
}

