using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControll : MonoBehaviour
{
    private static BGMControll instance;
    void Awake()
    {
        // ���̃C���X�^���X�����݂���ꍇ�͂��̃C���X�^���X��j��
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // ���̃C���X�^���X��ۑ����A�V�[�����܂����ł��j������Ȃ��悤�ɂ���
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
