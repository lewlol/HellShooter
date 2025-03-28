using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] rooms;

    GameObject currentRoom;

    private void Awake()
    {
        GenerateRoom();
    }

    private void GenerateRoom()
    {
        Destroy(currentRoom);

        int randomRoom = Random.Range(0, rooms.Length);
        GameObject newRoom = Instantiate(rooms[randomRoom], transform.position, Quaternion.identity);
        currentRoom = newRoom;
    }
}
