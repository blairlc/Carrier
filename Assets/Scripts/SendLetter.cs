using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendLetter : MonoBehaviour {

    public Sprite letterSprite;
    public string address;
    public bool hasLetter = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasLetter && other.gameObject.CompareTag("Player"))
        {
            Item letter = ScriptableObject.CreateInstance("Item") as Item;
            letter.sprite = letterSprite;
            letter.address = address;
            GameObject.FindWithTag("Player").GetComponent<Inventory>().AddItem(letter);
            hasLetter = false;
        }
    }
}
