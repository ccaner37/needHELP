using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
	public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _amount, ItemType _type)
	{
		bool hasItem = false;
		for (int i = 0; i < Container.Count; i++)
		{
			if(Container[i].item == _item)
			{
				Container[i].AddAmount(_amount);
				Container[i].type = _type;
				hasItem = true;
				break;
			}
		}
		if (!hasItem)
		{
			Container.Add(new InventorySlot(_item, _amount, _type));
		}
	}
}

[System.Serializable]
public class InventorySlot
{
	public ItemObject item;
	public int amount;
	public ItemType type;
	public InventorySlot(ItemObject _item, int _amount, ItemType _type)
	{
		item = _item;
		amount = _amount;
		type = _type;
	}
	public void AddAmount(int value)
	{
		amount += value;
	}
}
