using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermovement : MonoBehaviour 
{

	public GameObject object1;
	public GameObject object2;
	public GameObject object3;
	public GameObject object4;
	public GameObject object5;
	public GameObject object6;
	public GameObject hershey;

	public Light flashlight;

	AudioSource myAudio;
	public AudioClip ending;

	public float lookSpeed = 300f;
	public float moveSpeed = 10f;
	Vector3 inputVector; // pass keyboard data from Update() to FixedUpdate()
	public Text gametext;
	public Text counter;
	public int totalObjects = 6;
	float upDownRotation;




	void Start (){

		myAudio = GetComponent<AudioSource>();
		myAudio.Play();
	}

	// Update is called once per frame, this is where INPUT and RENDERING happens!!!
	void Update () {


		counter.text = "Treasures left: " + totalObjects + "/6";




		// mouse look

		// mouseDelta = difference, how fast you're moving your mouse
		// if it's "0" that means the mouse isn't moving
		// this is NOT mouse position (mouse position is Input.mousePosition)
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime; // mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime; // mouseY = vertical mouseDelta

		// negative mouseX = moving your mouse to the left, etc.
		// negative mouseY = moving your mouse downwards, etc.

		// "pitch yaw roll", X Y Z
		// rotating on X axis, up/down, is "pitch"
		// rotating on Y axis, left/right, is "yaw"
		// rotating on Z axis is "roll"

		// simplest possible mouse-look: just rotate camera naively
		// Camera.main.transform.Rotate(-mouseY, mouseX, 0f);

		// slightly better mouse-look:
		// rotate capsule left/right, but rotate camera up/down
		transform.Rotate(0f, mouseX, 0f); // capsule rotation

		upDownRotation -= mouseY;
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80);

		//Camera.main.transform.localEulerAngles += new Vector3(-mouseY, 0f, 0f); // camera rotation
		// Camera.main.transform.Rotate(-mouseY, 0f, 0f); // this is the same thing as the line above

		// 1 big problem with this: camera keeps rolling anyway

		// solution: after applying rotations, un-roll the camera
		// this is what we want to do, but can't: Camera.main.transform.localEulerAngles.z = 0f;
		Camera.main.transform.localEulerAngles = new Vector3(
			upDownRotation,
			0f,
			0f
		);


		// first-person player movement

		float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down on keyboard, -1 for down, +1 for up
		float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right on keyboard, -1 is left, +1 right

		if (Input.GetMouseButtonDown(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}// 0 - left click

		// simplest possible method: move transform based on keyboard values
		// vertical (forward) movement:
		// transform.position += transform.forward * vertical * moveSpeed * Time.deltaTime;
		// horizontal (strafe) movement:
		// transform.position += transform.right * horizontal * moveSpeed * Time.deltaTime;
		// multiply by Time.deltaTime to make it "framerate INDEPENDENT", more consistent across machines

		// this "simplest method" is bad because we are moving transform directly
		// when you move transform directly, you're basically teleporting it, no collision detection

		// a better method: move using Rigidbody forces in FixedUpdate(), which won't have same problems
		inputVector = transform.forward * vertical * moveSpeed; // forward / backward direction
		inputVector += transform.right * horizontal * moveSpeed; // left / right direction


		if (Vector3.Distance(transform.position, object1.transform.position) < 3) 
		{
			gametext.text = "Press SPACE to grab this treasure";
			if (Input.GetKeyDown("space"))
			{	
				object1.transform.position = new Vector3(50f, 50f, 50f);
				gametext.text = "In the most SouthWest corner, filled with pictures, is the next item.";
				totalObjects -=1;
				object2.transform.position = new Vector3(-37.2f, 0.5f, 3.41f);
				//RenderSettings.ambientIntensity = 3;
				//RenderSettings.reflectionIntensity = 1;


			}
		}

		else if (Vector3.Distance(transform.position, object1.transform.position) > 3f) 
		{
			//gametext.text = "";

		}
		if (Vector3.Distance(transform.position, object2.transform.position) < 3f)  
		{
			gametext.text = "Press SPACE to grab this treasure";
			if (Input.GetKeyDown("space"))
			{	
				object2.transform.position = new Vector3(50f, 50f, 50f);
				gametext.text = "Next treasure to find is just West of the starting room";
				totalObjects -=1;
				object3.transform.position = new Vector3(-16.8f, 0.5f, 22.28f);
			}
		}

		else if (Vector3.Distance(transform.position, object2.transform.position) > 3f) 
		{
			//gametext.text = "";

		}

		if (Vector3.Distance(transform.position, object3.transform.position) < 3f)  
		{
			gametext.text = "Press SPACE to grab this treasure";
			if (Input.GetKeyDown("space"))
			{	
				object3.transform.position = new Vector3(50f, 50f, 50f);
				gametext.text = "Head to the Northmost center to find the next object.";
				totalObjects -=1;
				object4.transform.position = new Vector3(-7.5f, 0.5f, 65.5f);
			}
		}

		else if (Vector3.Distance(transform.position, object3.transform.position) > 3f) 
		{
			//gametext.text = "";

		}
		if (Vector3.Distance(transform.position, object4.transform.position) < 3f)  
		{
			gametext.text = "Press SPACE to grab this treasure";
			if (Input.GetKeyDown("space"))
			{	
				object4.transform.position = new Vector3(50f, 50f, 50f);
				gametext.text = "In a nearly endless hallway, littered with decoration, is the next treasure.";
				totalObjects -=1;
				object5.transform.position = new Vector3(38.7f, 0.5f, 47.4f);
			}
		}

		else if (Vector3.Distance(transform.position, object4.transform.position) > 3f) 
		{
			//gametext.text = "";

		}
		if (Vector3.Distance(transform.position, object5.transform.position) < 3f)  
		{
			gametext.text = "Press SPACE to grab this treasure";
			if (Input.GetKeyDown("space"))
			{	
				object5.transform.position = new Vector3(50f, 50f, 50f);
				gametext.text = "Return to the room where this search first began.";
				totalObjects -=1;
				object6.transform.position = new Vector3(3.66f, 0.5f, -1.01f);
			}
		}

		else if (Vector3.Distance(transform.position, object5.transform.position) > 3f) 
		{
			//gametext.text = "";

		}
		if (Vector3.Distance(transform.position, object6.transform.position) < 6f)  
		{
			gametext.text = "Press SPACE to open it";
			if (Input.GetKeyDown("space"))
			{	
				object6.transform.position = new Vector3(50f, 50f, 50f);
				gametext.text = "The end";
				totalObjects -=1;
				hershey.transform.position = new Vector3(3.66f, 0f, -1.01f);
				moveSpeed = 0f;
				lookSpeed = 0f;
				upDownRotation = 25f;
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f);
				RenderSettings.ambientIntensity = 3;
				RenderSettings.reflectionIntensity = 1;
				myAudio.clip = ending;
				myAudio.PlayOneShot( myAudio.clip );
				flashlight.enabled = false;
			}
		}

		else if (Vector3.Distance(transform.position, object6.transform.position) > 3f) 
		{
			//gametext.text = "";

		}



	}

	// FixedUpdate runs all the time, every physics frame (physics runs at a different framerate than everything else)
	void FixedUpdate() // all physics code should go in FixedUpdate!!!
	{
		// apply our forces to move the object around
		GetComponent<Rigidbody>().velocity = inputVector; // no need for Time.deltaTime, already fixed framerate

		// one problem: gravity doesn't work anymore
	}


}