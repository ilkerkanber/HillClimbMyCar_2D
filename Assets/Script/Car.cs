using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public WheelJoint2D onTekerlek;
	public WheelJoint2D arkaTekerlek;
	public Camera kamera;
	public GameObject startPosition;
	JointMotor2D onMotor;
	JointMotor2D arkaMotor;

	public float speedF;
	public float speedB;

	public float onTork;
	public float arkaTork;

	[SerializeField]AudioClip CoinSound;
	[SerializeField] AudioClip WonSound;

	public GameObject EndMenu;
	public bool oyunDurum = true;
	public float benzin;
	public int para;
	float benzinGiderTime;


	void Update () {

		Controller();
		Camera();

	}
	void Camera()
    {
		kamera.transform.position = new Vector3(transform.position.x + 4, transform.position.y, -20);
	}
	public void Respawn()
    {
		transform.rotation = Quaternion.Euler(0, 0, 0);
        if (benzin <= 30)
        {
			benzin = 30;
        }
        if (para >= 10) { para -= 10; }
		transform.position = startPosition.transform.position;		
    }

	void Controller()
    {
		if (benzin > 0)
		{
			if (Input.GetAxisRaw("Vertical") > 0)
			{
				benzinGiderTime += Time.deltaTime;
				if (benzinGiderTime >= Random.Range(3, 5))
				{
					benzin--;
					benzinGiderTime = 0;
				}

				onMotor.motorSpeed = -speedF;
				onMotor.maxMotorTorque = onTork;

				arkaMotor.motorSpeed = -speedF;
				arkaMotor.maxMotorTorque = onTork;

				onTekerlek.motor = onMotor;
				arkaTekerlek.motor = arkaMotor;
			}
			else if (Input.GetAxisRaw("Vertical") < 0)
			{
				onMotor.motorSpeed = -speedB;
				onMotor.maxMotorTorque = arkaTork;

				arkaMotor.motorSpeed = -speedB;
				arkaMotor.maxMotorTorque = arkaTork;

				onTekerlek.motor = onMotor;
				arkaTekerlek.motor = arkaMotor;
			}

			else
			{
				onTekerlek.useMotor = false;
				arkaTekerlek.useMotor = false;
			}
		}
	}
    private void OnCollisionEnter2D(Collision2D carpan)
    {
        if (carpan.collider.tag == "Enemy")
        {
			Respawn();
        }
		if (carpan.collider.tag == "Coin")
		{
			AudioSource.PlayClipAtPoint(CoinSound, transform.position);
			para += 10;
			Destroy(carpan.gameObject);
		}
		if (carpan.collider.tag == "Gas")
		{
			switch (Random.Range(0, 5))
			{
				case 0:
					benzin += 10;
					break;
				case 1:
					benzin += 15;
					break;
				case 2:
					benzin += 20;
					break;
				case 3:
					benzin += 25;
					break;
				case 4:
					benzin += 30;
					break;
			}
			if (benzin > 100) { benzin = 100; }
			Destroy(carpan.gameObject);
		}

        if (carpan.collider.tag == "FinishFlag")
		{
			AudioSource.PlayClipAtPoint(WonSound, transform.position);

			speedB = 0;
			speedF = 0;

			EndMenu.SetActive(true);
			oyunDurum = false;
        }

	}
   

}
