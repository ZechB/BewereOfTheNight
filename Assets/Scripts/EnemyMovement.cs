/* Team 1
 * project 2
 * controls enemy stats
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private AudioSource enemyAudio;
    //changed for flag
    //public DisplayKillCounter killCounterScript;
    public Text textBox;
    public AudioClip slash; 
    public int enemyDamage; 
    // start is called before the first frame update
    public float speed; 
    public int health; 
    public Transform groundDetection; 
    private bool moveRight = true; 
    public float Raycast; 
    public float Raylength;

    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
        textBox = GetComponent<Text>();
        //killCounterScript = GameObject.FindGameObjectWithTag("KillCounterText").GetComponent<DisplayKillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //killCounterScript.killCounter += 1;
            DisplayKillCounter.killCounter++;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime); 
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down,Raylength); 
        if (groundInfo.collider == false)
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                moveRight = false; 
            } 
            else
            {
            transform.eulerAngles = new Vector3(0,0,0); 
            moveRight = true;
            }
        } 

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyAudio.PlayOneShot(slash, 1.0F);
            //Hurt the player and update their health bar
            other.GetComponent<HealthBar>().SetHealth(other.GetComponent<CharacterControl>().playerHealth -= enemyDamage);
        }
    }

}
