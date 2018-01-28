using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBus : MonoBehaviour {

    public GameObject bus;
    bool drive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		if (inventory.GetMoney() >= Inventory.winMoney && inventory.GetNumberOfItems() == 0)
        {
            bus.SetActive(true);
            drive = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (drive)
            bus.transform.position = Vector2.MoveTowards(bus.transform.position, transform.position, Time.deltaTime);
    }
}
