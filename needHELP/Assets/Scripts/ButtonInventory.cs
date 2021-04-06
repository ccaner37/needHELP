using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventory : MonoBehaviour
{
	public DisplayInventory displayInventory;
	public Player ply;
	public InventoryObject inventory;

	

	public void GetItemInfo()
	{
		GameObject thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
		string buttonTag = thisButton.tag;
		if (buttonTag == "Food")
		{
			ply.stamina += 5;
			
		}
	}
}
