using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hp = 200; 

    public int baseHp
    {
        get { return hp; }
        set
        {
            hp = value;
            mat.color = Color.HSVToRGB(0, 1, hp/100.0f);
        }
    }
    Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
