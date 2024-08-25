using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    AudioManager audioManager;

    public event EventHandler OnKeysChanged;

    private List<Key.KeyType> keyList;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
        keyList = new List<Key.KeyType>();
    }

    //Function for exposing our Key List to UI

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    // Add the Key to Holder

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    // Remove the Key from Holder

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    // Check that the key is in the Holder or not

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();

        // If player collides with the key, then he grabs the key

        if (key != null)
        {
            audioManager.PlaySFX(audioManager.keyPickup);
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        // If the player collides with the door then we check that specific key
        // is present in the holder or not to open the door

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                // Currently Holding Key to open this door
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
            else
            {
                keyDoor.PlayOpenFailAnim();
            }
        }
    }
}
