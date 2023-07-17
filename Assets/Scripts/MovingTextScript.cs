using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTextScript : MonoBehaviour
{
    bool move = false;
    private Animation anim;
    private Text text;
    private void Start()
    {
        anim = GetComponent<Animation>();
        text = GetComponent<Text>();
        transform.position = Vector3.left * 30f;
    }
    private void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
        }
    }

    public void StartMove(int score)
    {
        if (score > 0)
        {
            transform.localPosition = Vector3.zero;
            text.text = '+' + score.ToString();
            move = true;
            anim.Play();
        }
    }

    public void StopMove()
    {
        move = false;
    }
}
