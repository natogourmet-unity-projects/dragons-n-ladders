using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, 2, player.position.z - 2);
            transform.rotation = Quaternion.Euler(35, 0, 0);
        }
    }

    
}
