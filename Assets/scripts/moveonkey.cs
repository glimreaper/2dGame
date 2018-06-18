using UnityEngine;
using System.Collections;

public class moveonkey : MonoBehaviour {
    private bool fell = false;
    private bool won = false;
    private Rigidbody2D rb2d;
    private AudioSource audio;

    public AudioClip fallSound;
    public AudioClip victorySound;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

	void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

	// Update is called once per frame
	void Update () {
        if (fell == false && won == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 position = this.transform.position;
                if (position.x - 108 >= 31)
                {
                    position.x -= 108;
                    this.transform.position = position;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 position = this.transform.position;
                if (position.x + 108 <= 1111)
                {
                    position.x += 108;
                    this.transform.position = position;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector3 position = this.transform.position;
                if (position.y + 120 <= 570.5)
                {
                    position.y += 120;
                    this.transform.position = position;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Vector3 position = this.transform.position;
                if (position.y - 120 >= -28)
                {
                    position.y -= 120;
                    this.transform.position = position;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "stairsedited")
        {
            won = true;
            audio.PlayOneShot(victorySound, 1.0f);
            GameControl.instance.characterWon();
        }

        else if (coll.gameObject.tag == "hole")
        {
            fell = true;
            audio.PlayOneShot(fallSound, 1.0f);
            GameControl.instance.characterFell();
        }
        
    }
}
