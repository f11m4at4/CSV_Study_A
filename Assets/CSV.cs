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

        //파일 열자
        byte [] byteData = File.ReadAllBytes(path);
        string stringData = Encoding.GetEncoding("euc-kr").GetString(byteData);
        //string stringData = File.ReadAllText(path);

        //엔터(\n) 기준으로 한줄씩 자르기
        string [] lines = stringData.Split("\n");
        //\r 을 제거
        for(int i = 0; i < lines.Length; i++)
        {
            lines[i] = lines[i].Replace("\r", "");
        }

        //변수 나누기
        string[] variable = lines[0].Split(",");

        //값 나누기
        for(int i = 1; i < lines.Length; i++)
        {
            //만약에 값이 없다면(길이가 0이라면)
            if (lines[i].Length == 0) continue;

            string[] value = lines[i].Split(",");

            //정보 만들기
            UserInfoA data = new UserInfoA();
            data.name = value[0];
            data.phone = value[1];
            data.age = int.Parse(value[2]);

            //정보 추가
            list.Add(data);
        }

        return list;
    }
}
