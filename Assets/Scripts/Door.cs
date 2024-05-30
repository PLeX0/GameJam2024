using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Door : MonoBehaviour
{
    public InteractionsWithItems interactionsWithItems;
    private string password = "123456";
    private string combination = "";
    private int i = 0;
    private char[] number = new char[6];
    public TMP_Text code;
    public 
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            combination = "";

        code.SetText(combination);
        if(combination.Length>password.Length)
        {
            combination = "";
        }
    }

    public void CloseWindow()
    {
        interactionsWithItems.OutFromKeyboard();
        ResetCombination();
    }

    public void Button1()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '1';
        combination += number[i];
        i++;
    }
    public void Button2()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '2';
        combination += number[i];
        i++;
    }
    public void Button3()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '3';
        combination += number[i];
        i++;
    }
    public void Button4()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '4';
        combination += number[i];
        i++;
    }
    public void Button5()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '5';
        combination += number[i];
        i++;
    }
    public void Button6()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '6';
        combination += number[i];
        i++;
    }

    public void Button7()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '7';
        combination += number[i];
        i++;
    }
    public void Button8()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '8';
        combination += number[i];
        i++;
    }
    public void Button9()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '9';
        combination += number[i];
        i++;
    }
    public void Button0()
    {
        if (i > number.Length - 1)
        {
            ResetCombination();
        }
        number[i] = '0';
        combination += number[i];
        i++;
    }

    public void Enter()
    {
        if (combination.Equals(password))
        {
            SceneManager.LoadScene("Credits");
        }
        else if (!combination.Equals(password))
            ResetCombination();
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
    }
}
