using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject playerToSpawn = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerToSpawn.GetComponent<Player>().color = new Color(Random.RandomRange(0.0f, 1.0f), Random.RandomRange(0.0f, 1.0f), Random.RandomRange(0.0f, 1.0f));
        NetworkServer.AddPlayerForConnection(conn, playerToSpawn);
    }
}