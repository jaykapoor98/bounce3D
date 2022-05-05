using UnityEngine;

public class Follow_player : MonoBehaviour {

    public Transform player;
    public int x ;
    public int y ;
    public int z ;
    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + new Vector3(x, y, z);
    }
}