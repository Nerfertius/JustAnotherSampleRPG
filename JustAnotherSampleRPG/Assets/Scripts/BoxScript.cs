using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxScript : MonoBehaviour
{
    public List<GameObject> Buildings;

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
        if (Input.GetKeyDown(KeyCode.Return) && inside == true && buildFinished == false && playerScript.lumber >= 1 && playerScript.stone >= 2)
        {
            playerScript.lumber -= 1;
            playerScript.stone -= 2;
            Instantiate(Buildings[0], gameObject.transform.position, gameObject.transform.rotation);
            buildFinished = true;
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
