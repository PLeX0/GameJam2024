using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyboardPuzzle : MonoBehaviour
{
    public InteractionsWithItems interactionsWithItems;
    private string password = "643512";
    private string combination = "";
    private int i = 0;
    private char[] number = new char[6];
    public Phone phone;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWindow()
    {
        interactionsWithItems.OutFromKeyboard();
        ResetCombination();
    }

    public void Button1()
    {
        if (i > number.Length-1)
        {
            ResetCombination();
        }
        number[i] = '1';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button2()
    {
        if (i > number.Length-1)
        {
            ResetCombination();
        }
        number[i] = '2';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button3()
    {
        if (i > number.Length-1)
        {
            ResetCombination();
        }
        number[i] = '3';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button4()
    {
        if (i > number.Length-1)
        {
            ResetCombination();
        }
        number[i] = '4';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button5()
    {
        if (i > number.Length-1)
        {
            ResetCombination();
        }
        number[i] = '5';
        combination += number[i];
        i++;
        audioSource.Play();
    }
    public void Button6()
    {
        if (i > number.Length-1)
        {
            ResetCombination();
        }
        number[i] = '6';
        combination += number[i];
        i++;
        audioSource.Play();
    }

    public void Enter()
    {
        if (combination.Equals(password))
        {
            CloseWindow();
            phone.callId++;
            phone.Call(phone.callId);
        }
        else if(!combination.Equals(password))
            ResetCombination();
        audioSource.Play();
    }

    public void ResetCombination()
    {
        i = 0;
        combination = "";
        number[0] = ' ';
        number[1] = ' ';
        number[2] = ' ';
        number[3] = ' ';
        number[4] = ' ';
        number[5] = ' ';
        audioSource.Play();
    }
}
