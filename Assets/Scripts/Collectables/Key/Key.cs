using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType; // Checking the color of Key

    // List of Key Types
    public enum KeyType
    {
        Red, Green, Blue
    }

    // To get the key type

    public KeyType GetKeyType()
    {
        return keyType;
    }

    /*public static Color GetColor(KeyType keyType)
    {
        switch (keyType)
        {
            default:
            case KeyType.Green: return Color.green;
            case KeyType.Red: return Color.red;
            case KeyType.Blue: return Color.blue;
        }
    }*/

}
