using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubukDonerge : MonoBehaviour
{
    [SerializeField] float hareketSüresi;
    float now;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            now += Time.deltaTime;
            if (now < hareketSüresi)
            {
                transform.Translate(-Vector3.down * Time.deltaTime);
            }
            else if (now > hareketSüresi && now <= hareketSüresi * 2)
            {
                transform.Translate(Vector3.down * Time.deltaTime);
            }
            else
            {
                now = 0;
            }

        
    }
}
