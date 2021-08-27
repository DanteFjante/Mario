using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float mapwidth = 100;
    public float mapStartPosX = -10;
    public float mapHeight = 20;


    public Player player;

    public EdgeCollider2D mapLimits;
    public BoxCollider2D deathFloor;
    // Start is called before the first frame update
    void Start()
    {
        deathFloor.transform.localScale = new Vector3(mapwidth, deathFloor.transform.localScale.y, deathFloor.transform.localScale.z);


        mapLimits.points = new[]
        {
            new Vector2(mapStartPosX, mapHeight),
            new Vector2(mapwidth + mapStartPosX, mapHeight),
            new Vector2(mapwidth + mapStartPosX, -mapHeight),
            new Vector2(mapStartPosX, -mapHeight),
            new Vector2(mapStartPosX, mapHeight),
        };
        Vector3 pos = Vector3.right;
        deathFloor.transform.position = new Vector3((mapwidth / 2 + mapStartPosX), -mapHeight + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (deathFloor.IsTouchingLayers(LayerMask.GetMask("Player")))
            player.Kill();
            
            
    }
}
