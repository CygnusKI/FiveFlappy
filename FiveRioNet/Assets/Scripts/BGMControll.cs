using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControll : MonoBehaviour
{
    private static BGMControll instance;
    void Awake()
    {
        // 他のインスタンスが存在する場合はこのインスタンスを破棄
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // このインスタンスを保存し、シーンをまたいでも破棄されないようにする
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
