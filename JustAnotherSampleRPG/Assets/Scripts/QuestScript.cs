using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestScript : MonoBehaviour
{
    public Text levelText;
	public Text dangerText;
	public Text lootLumberText;
    public Text lootStoneText;

    private int level;
	private int danger;
    private int lootLumber;
    private int lootStone;
    private int damage;
	private int chance;
	private int chanceMod = 0;
	private int dieRoll;

	private GameObject player;
	//private bool chestSpawn;

	private ResourceScript playerScript;

    void Start ()
    {
        level = 0;
        lootLumber = 0;
        lootStone = 0;

		player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<ResourceScript>();
		NewQuest();
    }

	public void NewQuest()
	{
		level = Random.Range((playerScript.level), (playerScript.level + 4));
		danger = Random.Range(0,101);
		lootLumber = (int)Random.Range(1, ((int)(level * Random.Range(0.7F, 1.1F)) + (danger * Random.Range(0.75F, 1.25F)) + (danger / 2)));
		lootStone = (int)Random.Range(1, ((int)(level * Random.Range(1.2F, 1.9F)) + (danger * Random.Range(0.8F, 1.0F)) + (danger / 2)));

		levelText.text = "Recommended level: " + level.ToString();

		if (danger > 20)
		{
			dangerText.text = "Danger level: Medium";
			if (danger > 60)
			{
				dangerText.text = "Danger level: High";
				if (danger > 90)
				{
					dangerText.text = "Danger level: DEADLY!";
				}
			}
		}
		else if (danger < 20)
		{
			dangerText.text = "Danger level: Easy";
		}

		lootLumberText.text = lootLumber.ToString();
		lootStoneText.text = lootStone.ToString();
	}

	public void AcceptQuest()
	{
		dieRoll = Random.Range(0, 101);
		chance = 95;
		if (level > playerScript.level)
		{
			chanceMod = 15;
			chanceMod = chanceMod * (level - playerScript.level);
		}
		chance -= chanceMod;
		chance -= danger;
		if (chance < 0)
		{
			chance = 0;
		}

		if (chance >= dieRoll)
		{
			Success();
		}
		else
		{
			Failure();
		}
	}

	void Success()
	{
		playerScript.lumber += lootLumber;
		playerScript.stone += lootStone;
		NewQuest();
	}

	void Failure()
	{
		playerScript.health--;
		NewQuest();
	}











    /*void QuestProcess(int Qname, int Qdamage, int Qlumber, int Qstone, float Qchance)
    {
        int randNum = 0;

        playerScript.health -= Qdamage;

        randNum = Random.Range(1, 101);
        //if (randNum == Qchance)
        //{
        //    chestSpawn = true;
        //}
    }

    void Room_Spike()
    {
        Qname = "Spike room";
        damage = 5;
        tool = playerScript.iron_boots;
        chance = 36;

        if (playerScript.inventory.Contains(tool))
        {
            damage = 0;
        }
    }

    void Room_Flame()
    {
        Qname = "Flame room";
        damage = Random.Range(5,8);
        tool = playerScript.flame_cloak;
        chance = 78;

        if (playerScript.inventory.Contains(tool))
        {
            damage = 0;
        }
    }

    void Room_Pit()
    {
        Qname = "Pit room";
        damage = Random.Range(0, 11);
        tool = playerScript.glider;
        chance = 5;

        if (playerScript.inventory.Contains(tool))
        {
            damage = 0;
        }
    }

    void Room_Cliff()
    {
        Qname = "Cliff room";
        damage = Random.Range(2, 6);
        tool = playerScript.hook;
        chance = 50;

        if (playerScript.inventory.Contains(tool))
        {
            damage = 0;
        }
    }*/
}