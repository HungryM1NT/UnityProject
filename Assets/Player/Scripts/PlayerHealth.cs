using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxhealth;
    public Image healthBar;
    public Sprite hp20;
    public Sprite hp21;
    public Sprite hp22;
    public Sprite hp30;
    public Sprite hp31;
    public Sprite hp32;
    public Sprite hp33;
    public Sprite hp40;
    public Sprite hp41;
    public Sprite hp42;
    public Sprite hp43;
    public Sprite hp44;

    void Start()
    {
        
    }

    void Update()
    {
        switch (maxhealth)
        {
            case 2:
                switch (health)
                {
                    case 0:
                        healthBar.sprite = hp20;
                        break;
                    case 1:
                        healthBar.sprite = hp21;
                        break;
                    case 2:
                        healthBar.sprite = hp22;
                        break;
                }
                break;
            case 3:
                switch (health)
                {
                    case 0:
                        healthBar.sprite = hp30;
                        break;
                    case 1:
                        healthBar.sprite = hp31;
                        break;
                    case 2:
                        healthBar.sprite = hp32;
                        break;
                    case 3:
                        healthBar.sprite = hp33;
                        break;
                }
                break;
            case 4:
                switch (health)
                {
                    case 0:
                        healthBar.sprite = hp40;
                        break;
                    case 1:
                        healthBar.sprite = hp41;
                        break;
                    case 2:
                        healthBar.sprite = hp42;
                        break;
                    case 3:
                        healthBar.sprite = hp43;
                        break;
                    case 4:
                        healthBar.sprite = hp44;
                        break;
                }
                break;
        } 
    }
}
