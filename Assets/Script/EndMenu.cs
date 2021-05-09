using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
   public TextMeshProUGUI zamanText,benzinText,paraText;
    
    void Start()
    {
        var Car = GameObject.FindGameObjectWithTag("Player").GetComponent<Car>();
        var Menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();

        zamanText.SetText(Menu.zaman.ToString());
        benzinText.SetText("%"+Car.benzin.ToString());
        paraText.SetText(Car.para.ToString());
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void NextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex)+1);
    }
   
}
