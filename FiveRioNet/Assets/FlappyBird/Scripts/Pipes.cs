using UnityEngine;

public class Pipes : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public float initialSpeed = 5f;
    public float gainSpeed = 0.5f;
    public float gap = 3f;

    private float leftEdge;

    private GameObject playerObject;
    private Player player;
    private float speed = 5f;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        top.position += Vector3.up * gap / 2;
        bottom.position += Vector3.down * gap / 2;
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        speed = initialSpeed * gainSpeed * (6 - player.CheckNumPenguins());
        transform.position += speed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

}
