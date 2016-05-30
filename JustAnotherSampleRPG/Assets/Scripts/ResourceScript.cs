using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResourceScript : MonoBehaviour
{
    public int level;
    public int health;
    public int lumber;
    public int stone;

    public Text LevelUI;
    public Text HealthUI;
    public Text LumberUI;
    public Text StoneUI;

    //public string iron_boots;
    //public string flame_cloak;
    //public string glider;
    //public string hook;


    void Start ()
    {
        level = 1;
        health = 10;
        lumber = 0;
        stone = 0;
	}
	
	void Update ()
    {
        LevelUI.text = level.ToString();
        HealthUI.text = "x " + health.ToString();
        LumberUI.text = "x " + lumber.ToString();
        StoneUI.text = "x " + stone.ToString();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lumber++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            stone++;
        }

        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    inventory.Add(iron_boots);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    inventory.Add(flame_cloak);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    inventory.Add(glider);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha7))
        //{
        //    inventory.Add(hook);
        //}
    }
}
