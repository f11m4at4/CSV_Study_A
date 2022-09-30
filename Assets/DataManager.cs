using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A�� ����ó ����
[System.Serializable]
public class UserInfoA
{
    public string name;
    public string phone;
    public int age;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    //A�� �л��� ���� ���� ����
    public List<UserInfoA> userInfoA;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        userInfoA = CSV.instance.Parsing("Table_Contact_A");
    }

    void Update()
    {
        
    }
}
