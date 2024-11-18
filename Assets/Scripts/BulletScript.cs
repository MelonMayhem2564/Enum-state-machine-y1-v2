using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
