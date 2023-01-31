using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Upgrade 
{
    public string Name;
    public int Cost;
    public Sprite Sprite;
    public int Quantity;
    public int MaxQuantity;

    [HideInInspector] public GameObject itemRef;

    public void Save()
    {
        SaveUpgrade.SavePlayer(this);
    }

    public void Load()
    {
        DataUpbgrade data =  SaveUpgrade.LoadPlayer();

        Quantity = data.Quantity;
    }
}

public class ShopsItem : MonoBehaviour
{
    public PlayerControl PlayerControl;
    public Health Health;
    public KeepCoins KeepCoins;
    public Ultimate Ultimate;

    [SerializeField] public Upgrade[] _upgrades;

    [SerializeField] private GameObject _shopUI;
    [SerializeField] private TextMeshProUGUI _shopCoinText;

    [SerializeField] private Transform _shopContent;
    [SerializeField] private GameObject _itemPrefab;

    private const string ImprovementGravityForce = "GravityForce";
    private const string ImprovementMaxHealth = "MaxHealth";
    private const string ImprovementCooldawn = "Cooldown";

    public bool currentOpen;

    private void Awake()
    {
        //LoadPlayer();
    }

    private void Start()
    {
        foreach (Upgrade upgrade in _upgrades)
        {
            GameObject item = Instantiate(_itemPrefab, _shopContent);

            upgrade.itemRef = item;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.Quantity.ToString();
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

            item.GetComponent<Button>().onClick.AddListener(() => BuyUpgrade(upgrade));
        }
    }


    public void BuyUpgrade(Upgrade upgrade)
    {
        if (KeepCoins.Coins >= upgrade.Cost && upgrade.Quantity <= upgrade.MaxQuantity)
        {
            KeepCoins.SetCoins(-upgrade.Cost);
            upgrade.Quantity++;
            upgrade.itemRef.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = upgrade.Quantity.ToString();

            ApplyUpgrade(upgrade);
        }
    }

    public void LoadUpgrade()
    {
        foreach (var item in _upgrades)
        {
            item.Load();
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        PlayerControl.GravityForce = data.GravityForce;
        Ultimate.SkillsCooldown = data.Cooldown;
        Health.MaxHealth = data.MaxHealth;
        KeepCoins.Coins = data.Coins;

    }

    private void ApplyUpgrade(Upgrade upgrade)
    {
        switch (upgrade.Name)
        {
            case ImprovementGravityForce:
                PlayerControl.GravityForce += 1;
                break;
            case ImprovementMaxHealth:
                Health.MaxHealth += 5;
                break;
            case ImprovementCooldawn:
                Ultimate.SkillsCooldown -= 1;
                break;
        }
    }

    public void OnButtonShop()
    {
        if (currentOpen)
        {
            _shopUI.SetActive(true);
            currentOpen = false;
        }
        else if (currentOpen == false)
        {
            _shopUI.SetActive(false);
            currentOpen = true;
        }
    }

    public void ToNextScene(int scene)
    {
        //SceneManager.LoadScene(scene);
        SavePlayer();
    }

    private void OnGUI()
    {
        _shopCoinText.text = KeepCoins.Coins.ToString();
    }
}

