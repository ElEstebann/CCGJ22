// From: https://forum.unity.com/threads/2d-pokemon-style-movement-with-working-collision.755000/

using UnityEngine;
using UnityEngine.Tilemaps;
 
// require SpriteRenderer for changing the player's sprite
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    // walkspeed in tiles per second
    public float walkSpeed = 3f;
 
    // the tilemap which has the tiles we want to collide with
    public Tilemap tilemap;
 
    // the amount of time we can press an input without moving in seconds
    public float moveDelay = 0.1f;
 
    // our player's direction
    Direction currentDir = Direction.South;

    // Variables to adjust animation, in terms of 0f-1f (progress)
    public float altImageStart = 0.10f;
    public float altImageEnd = 0.75f;
 
    // a vector storing the input of our input-axis
    Vector2 input;
 
    // states if the player is moving or waiting for movement input
    bool isMoving = false;
 
    // position before a move is executed
    Vector3 startPos;
 
    // target-position after the move is executed
    Vector3 endPos;
 
    // stores the progress of the current move in a range from 0f to 1f
    float progress;
 
    // stores the time remaining before the player can move again
    float remainingMoveDelay = 0f;
    public bool alive = true;
    public bool invincible = false;
    public bool stopped = false;
 
    // Sprite nonsense
    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;
    public Sprite northWalk1;
    public Sprite northWalk2;
    public Sprite eastWalk1;
    public Sprite eastWalk2;
    public Sprite southWalk1;
    public Sprite southWalk2;
    public Sprite westWalk1;
    public Sprite westWalk2;
 
    private Collider2D box;
    public void Start()
    {
        box = GetComponent<Collider2D>();
    }
    public void FixedUpdate()
    {
        // check if the player is moving
        if (!isMoving && alive)
        {
            if(!stopped)
            {
            // The player is currently not moving so check if there is keyinput
                input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
            }
            else
            {
                input = new Vector2(0,0);
            }
            // if there is input in x direction disable input in y direction to
            // disable diagonal movement
            if (input.x != 0f)
                input.y = 0;
 
            // check if there is infact movement or if the input axis are in idle
            // position
            if (input != Vector2.zero)
            {
                // save the old direction for later use
                Direction oldDirection = currentDir;
 
                // update the players direction according to the input
                #region update Direction
                if (input.x == -1f)
                    currentDir = Direction.West;
                else if (input.x == 1f)
                    currentDir = Direction.East;
                else if (input.y == 1f)
                    currentDir = Direction.North;
                else if (input.y == -1f)
                    currentDir = Direction.South;
                #endregion

                // set idle sprite according to the direction
                switch (currentDir)
                {
                    case Direction.North:
                        gameObject.GetComponent<SpriteRenderer>().sprite = northSprite;
                        break;
                    case Direction.East:
                        gameObject.GetComponent<SpriteRenderer>().sprite = eastSprite;
                        break;
                    case Direction.South:
                        gameObject.GetComponent<SpriteRenderer>().sprite = southSprite;
                        break;
                    case Direction.West:
                        gameObject.GetComponent<SpriteRenderer>().sprite = westSprite;
                        break;
                }
 
                // if the currentDirection is different from the old direction
                // we want to add a delay so the player can just change direction
                // without having to move
                if (currentDir != oldDirection)
                {
                    remainingMoveDelay = moveDelay;
                }
 
                // if the direction of the input does not change then the move-
                // delay ticks down
                if (remainingMoveDelay > 0f)
                {
                    remainingMoveDelay -= Time.deltaTime;
                    return;
                }
 
                // for the collision detection and movement we need the current
                // position as well as the target position where our player
                // is going to move to
                startPos = transform.position;
                endPos = new Vector3(startPos.x + input.x, startPos.y + input.y, startPos.z);
                Debug.Log(endPos);
 
                // we subtract 0.5 both in x and y direction to get the coordinates
                // of the upper left corner of our player sprite and convert
                // the floating point vector into an int vector for tile search
                Vector3Int tilePosition = new Vector3Int((int)(endPos.x - 0.5f),
                                                         (int)(endPos.y - 0.5f), 0);
 
                // with our freshly calculated tile position of the tile where our
                // player want to move to we can now check if there is in fact
                // a tile at that position which we would collide with
                // if there is no tile so the GetTile-function return null then
                // we can go ahead and move towards our target
                if (tilemap.GetTile(tilePosition) == null)
                {
                    // we set our moving variable to true and our progress
                    // towards the target position to 0
                    isMoving = true;
                    progress = 0f;
                }
            }
        }
 
        // check if the player is currently in the moving state
        if (isMoving && alive)
        {
            // check if the progress is still below 1f so the movement is still
            // going on
            if (progress < 1f)
            {
                // Jank ass animation
                if (altImageStart < progress && progress < altImageEnd)
                {
                    switch (currentDir)
                    {
                        case Direction.North:
                            gameObject.GetComponent<SpriteRenderer>().sprite = northWalk2
                    ;
                            break;
                        case Direction.East:
                            gameObject.GetComponent<SpriteRenderer>().sprite = eastWalk2;
                            break;
                        case Direction.South:
                            gameObject.GetComponent<SpriteRenderer>().sprite = southWalk2;
                            break;
                        case Direction.West:
                            gameObject.GetComponent<SpriteRenderer>().sprite = westWalk2;
                            break;
                    }
                } else {
                    switch (currentDir)
                    {
                        case Direction.North:
                            gameObject.GetComponent<SpriteRenderer>().sprite = northWalk1;
                            break;
                        case Direction.East:
                            gameObject.GetComponent<SpriteRenderer>().sprite = eastWalk1;
                            break;
                        case Direction.South:
                            gameObject.GetComponent<SpriteRenderer>().sprite = southWalk1;
                            break;
                        case Direction.West:
                            gameObject.GetComponent<SpriteRenderer>().sprite = westWalk1;
                            break;
                    }
                }


                // increase our movement progress by our deltaTime times our
                // above specified walkspeed
                progress += Time.deltaTime * walkSpeed;
                
 
                // linearly interpolate between our start- and end-positions
                // with the value of our progress which is in range of [0, 1]
                transform.position = Vector3.Lerp(startPos, endPos, progress);
            }
            else
            {
                // if we are moving and our progress is above one that means we
                // either landed exactly on our desired position or we overshot
                // by some tiny amount so in ordered to not accumulate errors
                // we clamp our final position to our desired end-position
                isMoving = false;
                transform.position = endPos;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pushable")
        {
            //Debug.Log("Mirror hit");
            Pushable pushable= collision.transform.gameObject.GetComponent<Pushable>();
            if(pushable)
            {
                if(!pushable.push(input))
                {
                    abortMove();
                }
            }
        }
        else if(collision.tag == "Wall" || collision.tag == "ExplodingBarrel")
        {
            abortMove();
        }
        else
        {
            //Idk what else you could collide with
        }
        
    }

    public void Kill()
    {
        if(!invincible && alive)
        {
            Debug.Log("You Died!");
            alive = false;
            box.enabled = false;
            GameController manager= GameObject.Find("GameManager").GetComponent<GameController>();
            manager.Lose();
        }
    }

    public void Stop()
    {
        Debug.Log("player stopped");
        stopped = true;

    }

    public void Unstop()
    {
        Debug.Log("player unstopped");
        stopped = false;

    }

    public void abortMove()
    {
        Debug.Log("move aborted");
        transform.position = startPos;
        isMoving = false;
        remainingMoveDelay = moveDelay;

    }
}
 
// small Enumeration to help us keep track of the player's direction more easyly
enum Direction
{
    North, East, South, West
}