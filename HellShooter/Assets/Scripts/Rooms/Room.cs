using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform playerPosition;
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerPosition.position;
    }
}
