using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] float HareketSüresi;
    float now;

    void Start()
    {

    }

    void Update()
    {
        Move();
     }

       void Move() {

        now += Time.deltaTime;
        if(now < HareketSüresi)
        {
            transform.Translate(-Vector3.up * Time.deltaTime);
        }
        else if(now > HareketSüresi && now <= HareketSüresi * 2)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        else
        {
            now = 0;
        }

    }
   
}
