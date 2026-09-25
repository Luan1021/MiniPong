using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField]
    private string axisName;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float verticalLimitMax = 4.5f;
    [SerializeField]
    private float verticalLimitMin = -4.5f;

    void Update()
    {
        float move = Input.GetAxis(axisName) * speed;
        float nextPlayerPosition = transform.position.y + (move * Time.deltaTime);

        float clampedPositionY = Mathf.Clamp(nextPlayerPosition, verticalLimitMin, verticalLimitMax);

        transform.position = new Vector3(transform.position.x, clampedPositionY, transform.position.z);
        
    }
}
