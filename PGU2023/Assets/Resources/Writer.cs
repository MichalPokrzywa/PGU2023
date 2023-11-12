using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Writer : MonoBehaviour
{
    [SerializeField] MoveData data;

    public void StoreData(string nickname, Level level)
    {
        data.nickname = nickname;
        data.level = level;
    }
}
