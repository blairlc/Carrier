using UnityEngine;

// Based on code from Unity's Adventure Game tutorial.
// https://unity3d.com/learn/tutorials/projects/adventure-game-tutorial

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string address;

    public Item(Sprite sprite, string address)
    {
        this.sprite = sprite;
        this.address = address;
    }
}
