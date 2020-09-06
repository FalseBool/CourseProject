using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nums : PuzzleClass
{
    public string rightNum;
    public Text ourText;
    public int maxInt = 4;
    // Start is called before the first frame update
    void Start()
    {
        rightNum = GenNum();
       // Debug.Log(rightNum);

        generateNums();
    }

    public void generateNums()
    {

        //Debug.Log("Сгенерированное 1-4 число " + changeFirstLast(rightNum));
        //Debug.Log("Сгенерированное 1-2 число " + changeFirstSecond(rightNum));
        //Debug.Log("Сгенерированное 3 число " + changeFirstLast(changeFirstSecond(rightNum)));

        Text[] Texts= GetComponentsInChildren<Text>();

        Texts[0].text = changeFirstLast(rightNum);
        Texts[1].text = changeFirstSecond(rightNum);
        Texts[2].text = changeFirstLast(changeFirstSecond(rightNum));

    }
    public void correct()
    {

        if (rightNum == ourText.text)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
    public string GenNum()
    {
        int [] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        string generatedNum = "";
        for (int i = 0; i < maxInt; i++)
        {
            int temp = Random.Range(0, 9);
            while (a[temp] == -1)
            {
                temp = Random.Range(0, 9);
            }

            generatedNum += a[temp].ToString();
            a[temp] = -1;
        }

        return generatedNum;
    }
    public string changeFirstSecond(string str)
    {
        for (int i = 0; i < str.Length; i+=2)
        {
            char temp = str[i];
            str = str.Remove(i, 1);
            str = str.Insert(i, str[i].ToString());

            str = str.Remove(i+1, 1);
            str = str.Insert(i+1, temp.ToString());
        }
        return str;
    }
    public string changeFirstLast(string str)
    {
        for (int i = 0; i < str.Length/2; i++)
        {
            char temp = str[i];

            str = str.Remove(i,1);
            str = str.Insert(i, str[str.Length - 1 - i].ToString());

            str = str.Remove(str.Length-1-i,1);
            str = str.Insert(str.Length-i, temp.ToString());
        }
        return str;
    }
}
