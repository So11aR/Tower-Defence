using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public Color SelectColor;
    private MeshRenderer renderer;
    private Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        baseColor = renderer.material.color;
    }

    void OnMouseEnter()
    {
        renderer.material.color = SelectColor;
    }

    void OnMouseExit()
    {
        renderer.material.color = baseColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
