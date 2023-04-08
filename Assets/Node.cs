using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Material nodemat;
    Renderer rend;
    [SerializeField] Color startColor, hoverColor, busyColor;
    [SerializeField] GameObject nTower;
    [SerializeField] Vector3 offset;
    bool canPlace = true;
    bool hasMoney;
    Master master;
    void Start()
    {
        rend = GetComponent<Renderer>();
        nodemat = rend.material;
        startColor = nodemat.color;
        master = GameObject.Find("MASTER").GetComponent<Master>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
      
        if (canPlace)
        {
            nodemat.color = hoverColor;
        }
        else
        {
            nodemat.color = busyColor;
            
        }
        
    }
    private void OnMouseExit()
    {
        nodemat.color = startColor;
    }
    private void OnMouseUp()
    {
        nTower = master.towerPrefab;
        if (master.Money < 200)
        {
            hasMoney = false;
        }
        else hasMoney = true;
        if (canPlace && hasMoney)
        {
            Instantiate(nTower, transform.position + offset, Quaternion.identity);
            master.Money -= 200;
            canPlace = false;
            nodemat.color = busyColor;
        }
        
    }
    //private void OnMouseOver()
    //{
    //    if (Input.GetKey(KeyCode.Mouse1))
    //    {
            //do something on right mouse button click choose whatever you want
    //    }
        
    //}
}
