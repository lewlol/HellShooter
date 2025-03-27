using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject
{
    [Header("Item Information")]
    public string itemName;
    public GameObject itemPrefab;
}
