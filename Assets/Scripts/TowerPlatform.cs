using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    public TowerShop TowerShop;
    public Transform SetPoint;
    private Spawner spawner;
    private Tower installedTower;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    void OnMouseDown()
    {
        TowerShop.Open(this);
    }

    public void SetTower(GameObject tower)
    {
        installedTower = Instantiate(tower, SetPoint.position, Quaternion.identity).GetComponent<Tower>();
        installedTower.Init(spawner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
