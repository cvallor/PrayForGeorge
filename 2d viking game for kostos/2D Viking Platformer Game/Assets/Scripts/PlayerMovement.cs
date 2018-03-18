using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float MovementSpeed;
    public float JumpStrength;

    private bool isJumping;

    public GameObject helpDotExe;
    public GameObject spawn;
    Rigidbody2D MyRigid;

    public int Gold;
    private Text GoldText;

	void Start () {

        MyRigid = GetComponent<Rigidbody2D>();
		
	}

	void Update () {

        MyRigid.velocity = new Vector2(Input.GetAxis("Horizontal") * MovementSpeed, MyRigid.velocity.y);

        if (MyRigid.velocity.x > 0 && transform.localScale.x < 0 || MyRigid.velocity.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Fall();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            attack();
        }

    }

    private void Fall()
    {

    }

    private void jump()
    {
        if (!isJumping)
        {
            isJumping = true;

            MyRigid.AddForce(Vector2.up * JumpStrength);

            Invoke("resetIsJumping", 1f);
        }
    }

    private void resetIsJumping()
    {
        isJumping = false;
    }

    void attack()
    {
        GameObject go = Instantiate(helpDotExe, spawn.transform.position, spawn.transform.rotation);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        Destroy(go, 1.0f);
    }

    void Flip()
    {
        Vector3 LocalScale = transform.localScale;
        LocalScale.x *= -1;
        transform.localScale = LocalScale;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "Bow")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.name == "Meat")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.name == "Potion")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
