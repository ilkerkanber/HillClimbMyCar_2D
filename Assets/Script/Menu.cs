using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{   public TextMeshProUGUI benzinText;
    public TextMeshProUGUI paraText;
    public TextMeshProUGUI zamanText;

    public RectTransform güncelBenzinCubugu;
    public float zaman;

    void Start()
    {
        zaman = 0;
    }

    void Update()
    {
        var car = GameObject.FindGameObjectWithTag("Player").GetComponent<Car>();
        
        paraText.SetText(car.para.ToString());
        benzinText.SetText("%"+car.benzin.ToString());
        if (car.oyunDurum==true) {
            zaman += Time.deltaTime;
        }
        
        zamanText.SetText(zaman.ToString());

        güncelBenzinCubugu.sizeDelta = new Vector2(car.benzin, 15);
    }
  
    
}
