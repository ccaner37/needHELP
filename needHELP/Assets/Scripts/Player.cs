using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public InventoryObject inventory;
	public GameObject inventoryMenu;
	bool isInventoryOpen = false;
	public DisplayInventory displyinv;

	public float health = 100f;
	public float stamina = 100f;

	public Image healthBar;
	public Image staminaBar;
	float healthBarFillAmount;
	float staminaBarFillAmount;

	private void Start()
	{
		inventoryMenu.SetActive(false);
	}

	private void LateUpdate()
	{
		healthBarFillAmount = health / 100;
		staminaBarFillAmount = stamina / 100;

		healthBar.fillAmount = healthBarFillAmount;
		staminaBar.fillAmount = Mathf.Lerp(staminaBar.fillAmount, staminaBarFillAmount, 1 * Time.deltaTime);

	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Tab) && !isInventoryOpen)
		{
			displyinv.UpdateDisplay();
			inventoryMenu.SetActive(true);
			isInventoryOpen = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else if (Input.GetKeyDown(KeyCode.Tab) && isInventoryOpen)
		{
			inventoryMenu.SetActive(false);
			isInventoryOpen = false;
			Cursor.visible = false;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		var item = other.GetComponent<Item>();
		if (item)
		{
			inventory.AddItem(item.item, 1, ItemType.Food);
			Destroy(other.gameObject);
		}
	}

	private void OnApplicationQuit()
	{
		inventory.Container.Clear();
	}

}
