using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isDrop = false;
    public AudioClip soundEffect;  // �Đ�����SE
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();

        // AudioClip��AudioSource�ɐݒ�
        audioSource.clip = soundEffect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            DropOut();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            GameManager.Instance.IncreaseScore();
            other.gameObject.SetActive(false);
        }
    }

    private void DropOut()
    {
        Debug.Log("DropOut!!");
        isDrop = true;
        rb.velocity = new Vector3(0, -1.0f, 0);
        PlaySoundEffect();
    }

    public void PlaySoundEffect()
    {
        // SE����x�����Đ�
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
        else
        {
            Debug.LogWarning("AudioSource�܂���AudioClip���ݒ肳��Ă��܂���B");
        }
    }
}
