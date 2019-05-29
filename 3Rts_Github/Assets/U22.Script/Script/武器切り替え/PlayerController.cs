/* Written by Kaz Crowe */
/* PlayerController.cs */
using UnityEngine;
using System.Collections;

namespace SimpleHealthBar_SpaceshipExample
{
<<<<<<< HEAD
	public class PlayerController : MonoBehaviour
	{
		static PlayerController instance;
		public static PlayerController Instance { get { return instance; } }

		// Speeds //
		[Header( "Speeds" )]
		public float rotationSpeed = 45.0f;
		public float accelerationSpeed = 2.0f;
		public float maxSpeed = 3.0f;
		public float shootingCooldown = 0.2f;

		// Prefabs //
		[Header( "Prefabs" )]
		public GameObject bulletPrefab;

		// Player Components //
		Rigidbody myRigidbody;
		[Header( "Components" )]
		public Transform gunTrans;
		public Transform bulletSpawnPos;

		// Timers //
		float shootingTimer = 0;

		// Controls //
		public bool canControl = true;

		// Input Positions //
		float rotation;
		float acceleration;

		[Header( "Overheat" )]
		public RectTransform overheatVisual;
		float overheatTimer = 0.0f;
		public float overheatTimerMax = 5.0f;
		public float cooldownSpeed = 2.0f;
		bool canShoot = true;
		
		public SimpleHealthBar gunHeatBar;


		void OnDisable ()
		{
			if( Application.isPlaying == true && overheatVisual != null )
				overheatVisual.gameObject.SetActive( false );
		}
		
		void Awake ()
		{
			// If the instance variable is already assigned, then there are multiple of this component in the scene. Inform the user.
			if( instance != null )
				Debug.LogError( "There are multiple instances of the Player Controller script. Assigning the most recent one to Instance." );
			
			// Assign the instance variable as the Player Controller script on this object.
			instance = GetComponent<PlayerController>();
		}

		void Start ()
		{
			// Store the player's rigidbody.
			myRigidbody = GetComponent<Rigidbody>();

			overheatVisual.sizeDelta = new Vector2( Screen.width / 12, Screen.width / 12 );
		}

		void Update ()
		{
			// Run the CheckExitScreen function to see if the player has left the screen.
			CheckExitScreen();

			// If the user cannot control the player, then return.
			if( canControl == false )
				return;

			// Store the input positions
			rotation = Input.GetAxis( "Horizontal" );
			acceleration = Input.GetAxis( "Vertical" );

			if( canShoot == true )
			{
				// If the shooting button is being used...
				if( Input.GetMouseButton( 0 ) )
				{
					// If the gun is not overheated, then increase the timer.
					if( overheatTimer < overheatTimerMax )
						overheatTimer += Time.deltaTime;
					// Else the gun has overheated, so start the overheat coroutine.
					else
					{
						canShoot = false;
						StartCoroutine( "DelayOverheat" );
					}

					if( shootingTimer <= 0 )
					{
						// Then reset the timer and shoot a bullet.
						shootingTimer = shootingCooldown;
						CreateBullets();
					}
				}
				else
				{
					if( overheatTimer > 0 )
						overheatTimer -= Time.deltaTime * cooldownSpeed;
				}

				gunHeatBar.UpdateBar( overheatTimer, overheatTimerMax );
			}

			// If the shoot timer is above zero, reduce it.
			if( shootingTimer > 0 )
				shootingTimer -= Time.deltaTime;
			
			Aiming();
		}

		void FixedUpdate ()
		{
			// If the user cannot control the player...
			if( canControl == false )
				return;

			// Figure out the rotation that the player should be facing and apply it.
			Vector3 lookRot = new Vector3( rotation, 0, acceleration );
			transform.LookAt( transform.position + lookRot );

			float distVec = Vector2.Distance( Vector2.zero, new Vector2( rotation, acceleration ) );

			// Apply the input force to the player.
			myRigidbody.AddForce( transform.forward * distVec * 1000.0f * accelerationSpeed * Time.deltaTime );

			// If the player's force is greater than the max speed, then normalize it.
			if( myRigidbody.velocity.magnitude > maxSpeed )
				myRigidbody.velocity = myRigidbody.velocity.normalized * maxSpeed;
		}

		void Aiming ()
		{
			// Position the image on the mouse.
			overheatVisual.position = Input.mousePosition - ( Vector3 )( overheatVisual.sizeDelta / 2 );

			float mousePositionX = Input.mousePosition.x;
			float mousePositionY = Input.mousePosition.y;

			mousePositionX /= Screen.width;
			mousePositionY /= Screen.height;

			mousePositionX -= 0.5f;
			mousePositionY -= 0.5f;

			Vector3 lookAtPosition = new Vector3( mousePositionX * ( Camera.main.orthographicSize * Camera.main.aspect ) * 2.0f, 0, mousePositionY * Camera.main.orthographicSize * 2.0f );

			gunTrans.LookAt( lookAtPosition );
		}

		void CheckExitScreen ()
		{
			// If the main camera is not assigned, then return.
			if( Camera.main == null )
				return;
			
			// If the absolute value of the player's X position is greater than the ortho size of the camera multiplied by the camera's aspect ratio, then reset the player on the other side.
			if( Mathf.Abs( myRigidbody.position.x ) > Camera.main.orthographicSize * Camera.main.aspect )
				myRigidbody.position = new Vector3( -Mathf.Sign( myRigidbody.position.x ) * Camera.main.orthographicSize * Camera.main.aspect, 0, myRigidbody.position.z );
			
			// If the absolute value of the player's Z position is greater than the ortho size, then reset the Z position to the other side.
			if( Mathf.Abs( myRigidbody.position.z ) > Camera.main.orthographicSize )
				myRigidbody.position = new Vector3( myRigidbody.position.x, myRigidbody.position.y, -Mathf.Sign( myRigidbody.position.z ) * Camera.main.orthographicSize );
		}

		void CreateBullets ()
		{
			// Create a new bulletPrefab game object at the barrel's position and rotation.
			GameObject bullet = Instantiate( bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation ) as GameObject;

			// Rename the bullet for reference within the asteroid script.
			bullet.name = bulletPrefab.name;
			
			// Apply a speed to the bullet's velocity.
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 200.0f;

			// Destroy the bullet after 3 seconds.
			Destroy( bullet, 3.0f );
		}

		IEnumerator DelayOverheat ()
		{
			gunHeatBar.UpdateBar( 1.0f, 1.0f );

			yield return new WaitForSeconds( 1.0f );

			for( float t = 0.0f; t < 1.0f; t += Time.deltaTime * 0.25f )
			{
				overheatTimer = Mathf.Lerp( 1.0f, 0.0f, t );
				gunHeatBar.UpdateBar( overheatTimer, 1.0f );
				yield return null;
			}

			overheatTimer = 0;
			gunHeatBar.UpdateBar( overheatTimer, overheatTimerMax );

			canShoot = true;
		}
	}
}
=======
    //移動入力
    float inputHorizontal, inputVertical;

    // キャラクターコントローラ（カプセルコライダ）の参照
    private CapsuleCollider col;
    private Rigidbody rb;

    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;
    //　ジャンプ力
    [SerializeField]
    private float jumpForc;
    //ジャンプの回数
    [SerializeField]
    private int jumpMax = 2;
    //ジャンプ回数
    private int jumpCount;
    // 移動スピード
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float boost;
    public Animator animCon;  //  アニメーションするための変数
    public AnimatorStateInfo stateInfo;

    //コントローラーのための配列
    string[] ConNum;

    private float MoveSpeedSave;
    private void Start()
    {
        animCon = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する
        stateInfo = animCon.GetCurrentAnimatorStateInfo(0);
        velocity = Vector3.zero;

        // CapsuleColliderコンポーネントを取得する（カプ   セル型コリジョン）
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        //コントローラーが何台接続されているか
        ConNum = Input.GetJoystickNames();
    }

    private void Update()
    {
        //現在のアニメーション
        stateInfo = animCon.GetCurrentAnimatorStateInfo(0);
        if ((ConNum[0] == ""))
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal"); /*Input.GetAxisRaw("L Stick H")*/;
            inputVertical = Input.GetAxisRaw("Vertical"); /*Input.GetAxisRaw("L Stick V") */;
        }
        else
        {
            inputHorizontal = Input.GetAxisRaw("L Stick H");
            inputVertical = Input.GetAxisRaw("L Stick V");
        }
        
        Move();
        Weapon();
    }
    //行動関連
    private void Move()
    {
        // ▼▼▼移動処理▼▼▼
        if (inputHorizontal == 0 && inputVertical == 0)  //  テンキーや3Dスティックの入力（GetAxis）がゼロの時の動作
        {
            animCon.SetBool("Run", false);
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            animCon.SetBool("Run", true);  //  Runモーションする
        }
        if (animCon.GetBool("Run") == true)
        {
            if (!animCon.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                velocity.y += Physics.gravity.y * Time.deltaTime;
                // カメラの方向から、X-Z平面の単位ベクトルを取得
                Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

                // 方向キーの入力値とカメラの向きから、移動方向を決定
                Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

                // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
                rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

                // キャラクターの向きを進行方向に
                if (moveForward != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(moveForward);
                }
            }
        }

        // ▼▼▼ジャンプ処理▼▼▼
        //　ジャンプキー（デフォルトではSpace）を押したらY軸方向の速度にジャンプ力を足す
        if ((Input.GetButtonDown("Jump")||Input.GetButtonDown("joystick A"))
            && !animCon.GetCurrentAnimatorStateInfo(0).IsName("Jump")
            && jumpCount<=jumpMax)
        {
            rb.AddForce(Vector3.up * jumpForc,ForceMode.Impulse);
            animCon.SetBool("Jump", true);
            jumpCount++;
        }
    }

    private void Weapon()
    {
        if ((Input.GetMouseButtonDown(0)&& !Input.GetKeyDown("z")) || ((Input.GetButtonDown("joystick X"))&&!Input.GetButton("L1"))
        && !animCon.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animCon.SetBool("Attack", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DashCollider")
        {
            moveSpeed += boost;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DashCollider")
        {
            moveSpeed -= boost;
        }
    }
}
    

>>>>>>> Rikuto_Enemy
