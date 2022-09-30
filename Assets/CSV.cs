using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSV : MonoBehaviour
{
    public static CSV instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public List<UserInfoA> Parsing(string fileName)
    {
        List<UserInfoA> list = new List<UserInfoA>();

        string path = Application.dataPath + "/" + fileName + ".csv";

        //���� ����
        byte [] byteData = File.ReadAllBytes(path);
        string stringData = Encoding.GetEncoding("euc-kr").GetString(byteData);
        //string stringData = File.ReadAllText(path);

        //����(\n) �������� ���پ� �ڸ���
        string [] lines = stringData.Split("\n");
        //\r �� ����
        for(int i = 0; i < lines.Length; i++)
        {
            lines[i] = lines[i].Replace("\r", "");
        }

        //���� ������
        string[] variable = lines[0].Split(",");

        //�� ������
        for(int i = 1; i < lines.Length; i++)
        {
            //���࿡ ���� ���ٸ�(���̰� 0�̶��)
            if (lines[i].Length == 0) continue;

            string[] value = lines[i].Split(",");

            //���� �����
            UserInfoA data = new UserInfoA();
            data.name = value[0];
            data.phone = value[1];
            data.age = int.Parse(value[2]);

            //���� �߰�
            list.Add(data);
        }

        return list;
    }
}
