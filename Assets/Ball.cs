using UnityEngine;

public class Ball : MonoBehaviour
{

    private float ballSpeed;
    private Vector2 direction;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private string verticalWallTag, horizontalWallTag, paddletag;

    [SerializeField]
    private float iniBallSpeed = 7;


    void Start()
    {
        direction = new Vector2(1, 1);
        ballSpeed = iniBallSpeed;
    }

    void Update()
    {
        transform.Translate(direction * ballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == verticalWallTag)
        {
            direction = new Vector2(direction.x, -direction.y);
        }
        if (collision.gameObject.tag == horizontalWallTag)
        {
            direction= new Vector2 (-direction.x, direction.y);
            AddPoint();
        }
        if (collision.gameObject.tag == paddletag)
        {
            direction = new Vector2(-direction.x, direction.y);
        }
       
    }

    private void AddPoint()
    { 
        if(transform.position.x < 0)
           gameManager.AddPoin(1);
        else
            gameManager.AddPoin(0);

        gameManager.ResetBall();

    }
}
