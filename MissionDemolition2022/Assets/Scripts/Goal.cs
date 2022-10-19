using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class Goal : MonoBehaviour
{
    static public bool goalMet = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //when the tirgger is hit, check to see if it's a projectile
        Projectile proj = other.GetComponent<Projectile>();
        if (proj != null)
        {
            Goal.goalMet = true;
            //also set the alpha of the color to a higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 0.75f;
            mat.color = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
