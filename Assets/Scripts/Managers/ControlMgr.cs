//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;
    public float deltaSpeed = 1;
    public float deltaHeading = 4;

    float cos45 = Mathf.Cos(45 * Mathf.Deg2Rad);

    Vector3 up;
    Vector3 down;
    Vector3 left;
    Vector3 right;

    Vector3 upleft;
    Vector3 upright;
    Vector3 downleft;
    Vector3 downright;

    public Vector3 intersectionPoint;
    RaycastHit hit;

    float lookangle;
    float random;
    Vector3 diff;

    private void Awake()
    {
        inst = this;
        upleft = new Vector3(cos45 * -1, 0, cos45) * GameMgr.inst.player.maxSpeed;
        upright = new Vector3(cos45, 0, cos45) * GameMgr.inst.player.maxSpeed;
        downleft = new Vector3(cos45 * -1, 0, cos45 * -1) * GameMgr.inst.player.maxSpeed;
        downright = new Vector3(cos45, 0, cos45 * -1) * GameMgr.inst.player.maxSpeed;

        up = Vector3.forward * GameMgr.inst.player.maxSpeed;
        down = Vector3.back * GameMgr.inst.player.maxSpeed;
        left = Vector3.left * GameMgr.inst.player.maxSpeed;
        right = Vector3.right * GameMgr.inst.player.maxSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        if(GameMgr.inst.playerIsAlive == true)
        {
            //movement
            if(GameMgr.inst.PlayerInBounds())
            {
                if (Input.GetKey(KeyCode.W))    
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        GameMgr.inst.player.desiredVelocity = upleft;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        GameMgr.inst.player.desiredVelocity = upright;
                    }
                    else
                    {
                        GameMgr.inst.player.desiredVelocity = up;
                    }
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        GameMgr.inst.player.desiredVelocity = downleft;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        GameMgr.inst.player.desiredVelocity = downright;
                    }
                    else
                    {
                        GameMgr.inst.player.desiredVelocity = down;
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    GameMgr.inst.player.desiredVelocity = left;
                }  
                else if (Input.GetKey(KeyCode.D))
                {
                    GameMgr.inst.player.desiredVelocity = right;
                }
                else
                {
                    GameMgr.inst.player.desiredVelocity = Vector3.zero;
                }
            }
            else
            {
                GameMgr.inst.player.desiredVelocity = GameMgr.inst.player.position.normalized * GameMgr.inst.player.maxSpeed * -1;
            }


            //Right Mouse turns on magnet
            if(Input.GetMouseButtonDown(1))
            {
                GameMgr.inst.ToggleMagnet(true);
            }
            else if(Input.GetMouseButtonUp(1))
            {
                GameMgr.inst.ToggleMagnet(false);
            }


            //Left Mouse spawns projectile
            if (Input.GetMouseButtonDown(0))
            {
                if(GameMgr.inst.Debris >=1)
                {
                    SoundMgr.inst.PlayProjectile();
                    GameMgr.inst.Debris -= 1;
                    random = Random.Range(-1.5f,1.5f);
                    GameObject projectile = Object.Instantiate(GameMgr.inst.playerProjectile.gameObject, GameMgr.inst.player.position,GameMgr.inst.transform.transform.rotation);
                    projectile.GetComponent<Entity381>().speed = GameMgr.inst.projectileSpeed;
                    projectile.GetComponent<Entity381>().desiredSpeed = GameMgr.inst.projectileSpeed;
                    projectile.GetComponent<Entity381>().heading = GameMgr.inst.player.heading + random;
                    projectile.GetComponent<Entity381>().desiredHeading = GameMgr.inst.player.heading + random;
                    Object.Destroy(projectile, 3);
                }
            }



            //Get Mouse position on screen, set player heading to look at it
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                intersectionPoint = hit.point;
                diff = intersectionPoint - GameMgr.inst.player.position;
                lookangle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
                lookangle = Utils.Degress360(lookangle);
                GameMgr.inst.player.desiredHeading = lookangle;
                Debug.DrawLine(intersectionPoint, Camera.main.transform.position, Color.red, 0.01f);
            }

        }
        else
        {
            GameMgr.inst.player.desiredVelocity = Vector3.zero;
        }

    }
}
