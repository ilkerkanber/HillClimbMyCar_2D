using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   [SerializeField] float donmeHızı;

        void Start()
    {
        
    }

    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        transform.Rotate(new Vector3(0, donmeHızı, 0));
    }
}
