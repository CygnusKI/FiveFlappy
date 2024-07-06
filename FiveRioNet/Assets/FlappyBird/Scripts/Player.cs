using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] sprites;
    public float strength = 5f;
    public float gravity = -9.81f;
    public float gain_gravity = 0.25f;
    public float tilt = 5f;

    private SpriteRenderer spriteRenderer;
    private Vector3[] fingerDirection = new Vector3[5];
    // private int spriteIndex;

    [SerializeField] private Coordinate coordinate;
    private Vector3[] fingerPosition = new Vector3[5];
    private Vector3[] fingerPositionOffset = new Vector3[5];
    private float yOffset;

    // 各指に対応したオブジェクト(4つ)
    [SerializeField] private GameObject[] fingerObject = new GameObject[5]; // 0はこのゲームオブジェクト
    private Transform[] fingerObjectTransform = new Transform[5];
    private Penguin[] penguin = new Penguin[5];

    // スポナー処理
    [SerializeField] private Spawner spawner;
    int nowPenguinNum, pastPenguinNum = 0;
    [SerializeField] private float gainSpawnRate = 2f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        for (int i = 0; i < fingerDirection.Length; i++)
        {
            fingerDirection[i] = Vector3.zero;
        }
        for (int i = 0; i < fingerObject.Length; i++)
        {
            fingerObjectTransform[i] = fingerObject[i].transform;
            penguin[i] = fingerObject[i].GetComponent<Penguin>();
            Debug.Log(penguin[i]);
            Debug.Log(penguin[i].isDrop);
        }

        yOffset = transform.position.y;
    }

    private void Update()
    {
        ReceiveFingerPosition();

        for (int i = 0; i < fingerDirection.Length; i++)
        {
            if (!penguin[i].isDrop)
            {
                fingerDirection[i] = Vector3.up * fingerPosition[i].y * strength + new Vector3(0, yOffset, 0);
                //fingerDirection[i].y += gravity * Time.deltaTime * gain_gravity;
            }
            else
            {
                fingerDirection[i].y += gravity * Time.deltaTime;
            }
            fingerObjectTransform[i].position = new Vector3(fingerObjectTransform[i].position.x, fingerDirection[i].y, fingerObjectTransform[i].position.z);
            if (CheckNumPenguins() == 0)
            {
                GameManager.Instance.GameOver();
            }
        }

        nowPenguinNum = CheckNumPenguins();
        if (pastPenguinNum != nowPenguinNum && nowPenguinNum != 0)
        {
            pastPenguinNum = nowPenguinNum;
            spawner.UpdateSpawnRate((spawner.spawnRate * 1f/(6 - nowPenguinNum)) * gainSpawnRate);
        }

    }

    /*
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }
    */

    private void ReceiveFingerPosition()
    {
        for (int i = 0; i < fingerPosition.Length; i++)
        {
            fingerPosition[i] = coordinate.fingerPosition[i] - fingerPositionOffset[i];
        }
    }

    public void SetOffset()
    {
        for (int i = 0; i < fingerPosition.Length; i++)
        {
            fingerPositionOffset[i] = coordinate.fingerPosition[i];
        }
    }

    public int CheckNumPenguins()
    {
        int num = 0;
        for(int i = 0; i < fingerObject.Length; i++)
        {
            if (!penguin[i].isDrop)
            {
                num++;
            }
        }
        return num;
    }

}
