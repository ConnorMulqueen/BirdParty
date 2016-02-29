using UnityEngine;
using System.Collections;

public class OwlControl : MonoBehaviour {
    private float speed = 4f;
    private bool facingRight = true;
    GameObject pellet;
    GameObject enemy;
    private Rigidbody2D owlRB;

    private float MinX = 0;
    private float MaxX = 30;
    private float MinY = 0;
    private float MaxY = 30;

   // private Rigidbody2D rb2d;
   
    // Use this for initialization
    void Start () {
        // rb2d = GetComponent<Rigidbody2D>();
        pellet = Resources.Load("Prefabs/dot") as GameObject;
        enemy = Resources.Load("Prefabs/box") as GameObject;
        owlRB = this.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        Movement();
        enemySpawn();

	}

	void Movement() {
		if (Input.GetKey (KeyCode.D)) {
			//transform.Translate(Vector2.right * speed * Time.deltaTime);
            owlRB.AddForce(Vector2.right * speed * 88 * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.A)) {
            facingRight = false;
           // transform.Translate(Vector2.left * speed * Time.deltaTime);
           owlRB.AddForce(Vector2.left * speed * 88 * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.S)) {
           //transform.Translate(Vector2.down * speed * Time.deltaTime);
            owlRB.AddForce(Vector2.down * speed * 88 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W)) {
           // transform.Translate(Vector2.up * speed * Time.deltaTime);
            owlRB.AddForce(Vector2.up * speed * 88 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Q)) { 
            transform.Rotate(Vector3.forward * 5);
        }
        if(Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.forward * -5);
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject projectile = Instantiate(pellet) as GameObject;
            projectile.transform.position = GameObject.Find("OwlSprite").transform.position; //the get component rigid body here is useless probly
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * 99999/4 * Time.deltaTime);
            //print(Time.deltaTime);
            Object.Destroy(projectile, .5f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            GameObject projectile = Instantiate(pellet) as GameObject;
            projectile.transform.position = GameObject.Find("OwlSprite").transform.position; //the get component rigid body here is useless probly
            Vector3 temp = projectile.transform.position;
            temp.y -= 1;
            projectile.transform.position = temp;
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed * 99999/4 * Time.deltaTime);
            //print(Time.deltaTime);
            Object.Destroy(projectile, .5f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            GameObject projectile = Instantiate(pellet) as GameObject;
            projectile.transform.position = GameObject.Find("OwlSprite").transform.position; //the get component rigid body here is useless probly
            Vector3 temp = projectile.transform.position;
            temp.x += 1;
            projectile.transform.position = temp;
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * 99999 / 4 * Time.deltaTime);
            //print(Time.deltaTime);
            Object.Destroy(projectile, .5f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            GameObject projectile = Instantiate(pellet) as GameObject;
            projectile.transform.position = GameObject.Find("OwlSprite").transform.position; //the get component rigid body here is useless probly
            Vector3 temp = projectile.transform.position;
            temp.y += 1;
            projectile.transform.position = temp;
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed * 99999 / 4 * Time.deltaTime);
            //print(Time.deltaTime);
            Object.Destroy(projectile, .5f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            GameObject projectile = Instantiate(pellet) as GameObject;
            projectile.transform.position = GameObject.Find("OwlSprite").transform.position; //the get component rigid body here is useless probly
            Vector3 temp = projectile.transform.position;
            temp.x -= 1;
            projectile.transform.position = temp;
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * 99999 / 4 * Time.deltaTime);
            //print(Time.deltaTime);
            Object.Destroy(projectile, .5f);
        }
    }
    void enemySpawn() {
        //add a counter to each of these and stop the counter when max enemies is reached?
        //or should it just be play till die+ highscore? <----
        if(Time.frameCount % 40 == 0) {
            float x = Random.Range(MinX, MaxX);
            float y = Random.Range(MinY, MaxY); 
            GameObject enemySpawn = Instantiate(enemy, new Vector3(x,y,0), Quaternion.identity) as GameObject;
            //enemySpawn.transform.position = GameObject.Find("OwlSprite").transform.position * 4;
            enemySpawn.transform.position = Vector2.MoveTowards(enemySpawn.transform.position, GameObject.Find("OwlSprite").transform.position, speed * Time.deltaTime *99);
            // enemySpawn.transform.position = GameObject.Find("OwlSprite").transform.position;

            //enemySpawn.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * 777 * Time.deltaTime);
        }
        else if(Time.frameCount % 20 == 0) {
            //spawn bigger enemy that takes multiple shots to kill
        }
    }
    void enemyMovement (GameObject enemy) {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, GameObject.Find("OwlSprite").transform.position, speed * Time.deltaTime * 50);
    }
}
