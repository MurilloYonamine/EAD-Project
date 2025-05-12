using UnityEngine;

public class Follow_camera : MonoBehaviour
{
    
    private Transform Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3, -10);
    }
}
