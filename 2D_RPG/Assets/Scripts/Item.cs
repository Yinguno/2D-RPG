using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "My Asset/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
}
