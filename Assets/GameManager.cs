using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI player1ScoreText, player2ScoreText;

    [SerializeField]
    private Rigidbody2D ball;

    [SerializeField]
    private Transform paddle1, paddle2;

    [SerializeField]
    private int mxPoints = 10;

    private int player1Score, player2Score;

    void Start()
    {
        ball.gameObject.SetActive(false);
        Invoke("ResetGame", 3);

    }


    private void ResetGame()
    {
        ball.gameObject.SetActive(true);
        ResetBall();

        paddle1.transform.position = new Vector2(paddle1.transform.position.x, 0);
        paddle2.transform.position = new Vector2(paddle2.transform.position.x, 0);

        player1Score = 0;
        player2Score = 0;

        ShowScore();

    }

    public void ResetBall()
    {
        ball.transform.position = Vector2.zero;
    }

    private void ShowScore()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void AddPoin(int playerNumber)
    {
        if (playerNumber == 0)
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }
        ShowScore();

        if (player1Score >= mxPoints || player2Score >= mxPoints)
        {
            ball.gameObject.SetActive(false);
            Invoke("ResetGame", 2);
        }
    }
}