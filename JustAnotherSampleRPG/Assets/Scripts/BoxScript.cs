using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxScript : MonoBehaviour
{
	private GameObject selectedBuilding;
    private bool inside;
    private bool buildFinished;
    private ResourceScript playerScript;
	private GameObject player;

	void Start ()
    {
        inside = false;
        buildFinished = false;

		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<ResourceScript>();
    }
	
	void Update ()
    {
		if (inside)
		{
			//Open build menu



			if (Input.GetKeyDown(KeyCode.Return) && buildFinished == false && playerScript.lumber >= 10 && playerScript.stone >= 20)
			{
				playerScript.lumber -= 10;
				playerScript.stone -= 20;
				Instantiate(selectedBuilding, gameObject.transform.position, gameObject.transform.rotation);
				buildFinished = true;
			}

			if (buildFinished)
			{
				//Open craft menu
			}
		}
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && inside == false)
        {
            inside = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && inside == true)
        {
            inside = false;
        }
    }
}
