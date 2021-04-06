using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public InventoryObject inventory;
	public Player ply;
	public Animator anim;
	public AudioSource attackSound;

	RaycastHit hit;
	float reach = 20.0f;

   

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetMouseButtonDown(0))
		{
			var fwd = transform.TransformDirection(Vector3.forward);
			
			if (Physics.Raycast(transform.position, fwd, out hit, reach)) // && hit.transform.tag == "StoneRock"
			{
				var item = hit.transform.gameObject.GetComponent<Item>();
				if (item)
				{
					inventory.AddItem(item.item, 1, ItemType.Default);
					attackSound.Play();
					ply.stamina -= 5;	
				}
				anim.Play("arms1");
				anim.SetTrigger("Attack");
			}
		}
    }
}
