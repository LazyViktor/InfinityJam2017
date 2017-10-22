using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Player player;

    public SpriteRenderer roomSprite;
    private float roomHeightHalf;
    private float roomWidthHalf;


    private Camera cam;
    private float cameraHeightHalf;
    private float cameraWidthHalf;

    private float distanceToLeftEdge;
    private float distanceToRightEdge;
    private float distanceToTopEdge;
    private float distanceToBottomEdge;


    // Use this for initialization
    void Start () {
        cam = Camera.main;
        cameraWidthHalf = cameraHeightHalf * cam.aspect / 2f;
        cameraHeightHalf = cam.orthographicSize;

        roomHeightHalf = roomSprite.bounds.extents.y;
        roomWidthHalf = roomSprite.bounds.extents.z;

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 curPosition = transform.position;

        distanceToLeftEdge = curPosition.x - roomWidthHalf - roomSprite.bounds.extents.x;
        distanceToRightEdge = roomSprite.bounds.center.x + roomWidthHalf - curPosition.x;
        distanceToTopEdge = roomSprite.bounds.center.y + roomHeightHalf - curPosition.y;
        distanceToBottomEdge = roomSprite.bounds.center.y - roomHeightHalf - curPosition.y;

        //Rect cameraConstraintRect = new Rect(roomSprite.bounds.center.x - roomSprite.bounds.extents.x + cameraWidth,
        //                                     roomSprite.bounds.center.y + roomSprite.bounds.extents.y - cameraHeight,)

        Vector3 potPosition = new Vector3(player.playerPosition.x, player.playerPosition.y, -10);
        bool potPositionValidity = false;

        // moving right
        if((potPosition - curPosition).x > 0)
        {
            // check for distance to right enough
            if(distanceToRightEdge > cameraWidthHalf)
            {
                // moving up
                if((potPosition - curPosition).y > 0)
                {
                    // check for distance to top enough
                    if(distanceToTopEdge > cameraHeightHalf)
                    {
                        potPositionValidity = true;
                    }
                    
                }
                else // moving down
                {
                    // check for distance to bottom enough
                    if(distanceToBottomEdge > cameraHeightHalf)
                    {
                        potPositionValidity = true;
                    }
                }
            }
        }
        else // moving left
        {
            // check for distance to left enough
            if(distanceToLeftEdge > cameraWidthHalf)
            {
                // moving up
                if ((potPosition - curPosition).y > 0)
                {
                    // check for distance to top enough
                    if (distanceToTopEdge > cameraHeightHalf)
                    {
                        potPositionValidity = true;
                    }

                }
                else // moving down
                {
                    // check for distance to bottom enough
                    if (distanceToBottomEdge > cameraHeightHalf)
                    {
                        potPositionValidity = true;
                    }
                }
            }
        }


        // changing position if new position has enough distance to the edges of the room
        if (potPositionValidity)
        {
            transform.position = new Vector3(player.playerPosition.x,
                                         player.playerPosition.y, -10);
        }
       
	}
}
