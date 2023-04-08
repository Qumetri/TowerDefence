using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text moneyText;
    [SerializeField] int money;
    public GameObject towerPrefab;
    [SerializeField] GameObject[] towers;

    public void SetTurretPrefab()
    {
        towerPrefab = towers[0];
    }
    public void SetLauncherPrefab()
    {
        towerPrefab = towers[1];
    }
    public void SetLaserPrefab()
    {
        towerPrefab = towers[2];
    }
    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            moneyText.text = money.ToString();
        }
    }
    void Start()
    {
        Money = money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
