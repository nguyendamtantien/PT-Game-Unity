using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float MoveForce = 20f;
    public float MaxVelocity = 5f;
    public float Jumpforce = 200f;
    public bool grounded;

    private Rigidbody2D mybody;
    private Animator anim;

    private bool MoveLeft;
    private bool MoveRight; 
	public AudioSource audioSource;
	public AudioClip AudioJump;
	public AudioClip AudioRun;

	// AI
	public bool spotted = false;
	public Transform startSight, endSight;
	public GameObject bullet;
	private int numberBullet = 10; 
	private float timeDelay = 0;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(()=> Jump());
        
    }
    public void SetMoveLeft(bool MoveLeft){
		this.MoveLeft = MoveLeft;
		this.MoveRight = !MoveLeft;
	}

	public void StopMoving(){
		this.MoveLeft = false;
		this.MoveRight = false;
	}
    // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyboard();
        // PlayerWalkJoyStick();
		Debug.DrawLine(startSight.position, endSight.position, Color.red);
        spotted = Physics2D.Linecast(startSight.position, endSight.position, 1 << LayerMask.NameToLayer("Jumper"));

        timeDelay += Time.deltaTime;
        if (timeDelay>0.5f&&spotted&&numberBullet>0){
            Attack();
            timeDelay = 0;
        }

    }
	 void Attack()
    {
        numberBullet--;
	if (gameObject.transform.localScale.x == 1)
        {
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            body.GetComponent<BulletPlayer>().Shoot(1);
        }
        else
        {
            GameObject body = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            body.GetComponent<BulletPlayer>().Shoot(-1);
        }
    }

    // void PlayerWalkJoyStick(){
	// 	float forceX = 0f;
	// 	float vel = Mathf.Abs (mybody.velocity.x);

	// 	if (MoveRight) {

	// 		if (vel < MaxVelocity) {
	// 			if (grounded) {
	// 				forceX = MoveForce;
	// 			} else {
	// 				forceX = MoveForce * 1.1f;
	// 			}
	// 		}
			
	// 		Vector3 scale = transform.localScale;
	// 		scale.x = 1f;
	// 		transform.localScale = scale;
			
	// 		anim.SetBool ("Walk", true);

	// 	} else if (MoveLeft) {

	// 		if (vel < MaxVelocity) {
	// 			if (grounded) {
	// 				forceX = -MoveForce;
	// 			} else {
	// 				forceX = -MoveForce * 1.1f;
	// 			}
	// 		}
			
	// 		Vector3 scale = transform.localScale;
	// 		scale.x = -1f;
	// 		transform.localScale = scale;
			
	// 		anim.SetBool ("Walk", true);

	// 	} else {
	// 		anim.SetBool ("Walk", false);
	// 	}

	// 	mybody.AddForce (new Vector2 (forceX, 0));

	// }

    void PlayerWalkKeyboard()
    {
        float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (mybody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal"); //-1 0 1

		if (h > 0) {
            if(vel < MaxVelocity) {
				if(grounded){
					forceX = MoveForce ;
					audioSource.PlayOneShot(AudioRun);
				}else{
					forceX = MoveForce * 1.1f ;
					audioSource.PlayOneShot(AudioRun);
				}
			}
			
			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			anim.SetBool ("Walk", true);

		} else if (h < 0) {
			if (vel < MaxVelocity) {
				if(grounded){
					forceX = -MoveForce ;
					audioSource.PlayOneShot(AudioRun);
				}else{
					forceX = -MoveForce * 1.1f;
					audioSource.PlayOneShot(AudioRun);
				}
				
			}
			
			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;
			
			anim.SetBool ("Walk", true);
		} else if (h == 0) {
			anim.SetBool("Walk",false);
		}

        if(Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = Jumpforce;
                mybody.AddForce(new Vector2(0, forceY));
				audioSource.PlayOneShot(AudioJump);
            }
        }
        mybody.AddForce(new Vector2(forceX, forceY));
    }

    public void BouncePlayerWithBouncy(float force){
		if (grounded) {
			grounded = false;
			mybody.AddForce(new Vector2(0,force));
		}
	}
    public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            mybody.AddForce(new Vector2(0, Jumpforce));
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Grounds")
        {
            grounded = true;
        }
    }
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "bullet")
		{
			Destroy(gameObject);
			GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDie();
			}
	}
}
