using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DotsPuzzle : PuzzleClass
{
    public float deg;
    [SerializeField] private GameObject toMove = null;
    public int radius;
    public float speed;
    private int dir = 1;
    public float timer;
    public float increaseSpd;
    private int rightAns = 0;

    [SerializeField] private Image[] imgs = null;


    
    // Start is called before the first frame update
    void Start()
    {

    }
    //увеличивать скорость с кол-вом закрашенных
    // Update is called once per frame
    override public void Update()
    {
        base.Update();

        if (Input.GetKeyDown("space"))
        {
            dir *= -1;
            Check();
        }
        timer +=  speed * dir * Time.deltaTime * 10000000;
        if(timer > 2 * Mathf.PI)
        {
            timer = 0;
        }if (timer <0)
        {
            timer = 2 * Mathf.PI;
        }
        deg = Mathf.Round( timer * Mathf.Rad2Deg) % 360;
        float X = Mathf.Cos(timer) * radius;
        float Y = Mathf.Sin(timer) * radius;
        toMove.transform.localPosition = new Vector2(X,Y);

        if (rightAns == 8)//проверка на ответ
        {
            endOfPuzzle(true);
        }
    }
    
    
    void fixdCheck()
    {

    }
    void Check()
    {

        if (deg >0 && deg < 22.5f || deg < 360 && deg > 337.5f)
        {
            if(imgs[0].color == Color.red)
            {
                imgs[0].color = Color.white;
                rightAns--;
            }
            else
            {
                rightAns++;
                imgs[0].color = Color.red;
               
            }
            
        }else if (deg > 22.5f && deg < 67.5f)
        {
            if (imgs[1].color == Color.red)
            {
                imgs[1].color = Color.white;
                rightAns--;
            }
            else
            {
                rightAns++;
                imgs[1].color = Color.red;

            }
        }
        else if (deg > 67.5f && deg < 112.5f)
        {
            if (imgs[2].color == Color.red)
            {
                imgs[2].color = Color.white;
                rightAns--;
            }
            else
            {
                rightAns++;
                imgs[2].color = Color.red;

            }
        }
        else if (deg >112.5f  && deg < 157.5f)
        {
            if (imgs[3].color == Color.red)
            {
                imgs[3].color = Color.white;
                rightAns--;
            }
            else
            {
                rightAns++;
                imgs[3].color = Color.red;

            }
        }
        else if (deg > 157.5f && deg < 202.5f)
        {
            if (imgs[4].color == Color.red)
            {
                imgs[4].color = Color.white;
                rightAns--;
            }
            else
            {
                imgs[4].color = Color.red;
                rightAns++;
            }
        }
        else if (deg > 202.5f && deg < 247.5f)
        {
            if (imgs[5].color == Color.red)
            {
                imgs[5].color = Color.white;
                rightAns--;
            }
            else
            {
                imgs[5].color = Color.red;
                rightAns++;
            }
        }
        else if (deg > 247.5f && deg < 292.5f)
        {
            if (imgs[6].color == Color.red)
            {
                imgs[6].color = Color.white;
                rightAns--;
            }
            else
            {
                imgs[6].color = Color.red;
                rightAns++;
            }
        }
        else if (deg > 292.5f && deg < 337.5f)
        {
            if (imgs[7].color == Color.red)
            {
                imgs[7].color = Color.white;
                rightAns--;
            }
            else
            {
                imgs[7].color = Color.red;
                rightAns++;
            }
        }

    }
}
