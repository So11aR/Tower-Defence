using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    public GameObject towerShopUI;
    private TowerPlatform towerPlatform;
    
    public void Open(TowerPlatform platform)
    {
        towerShopUI.SetActive(true);
        towerPlatform = platform;
    }

    public void BuyTower(int price)
    {

    }

    public void SetTower(GameObject tower)
    {
        towerPlatform.SetTower(tower);
        towerShopUI.SetActive(false);
    }
}
