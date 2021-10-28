using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Dialogs;
using UnityEngine.SceneManagement;



public class Calculate : MonoBehaviour
{
    int PrimeNum, SecondNum, ValueNum, RequestFinal, RandomNumber, RandomNum, RandomNum2, Temporary, Location, LocationDeath;
    public Text FirstNumber, SecondNumber, Symbol, Result, Answer1, Answer2, Answer3, CorrectBox;
    private string VarSymbol;
    public GameObject Canvas, Transparent, Tick, Cross, DeathBox, ScoreBox;
    List<Object> ScoreBoxClone = new List<Object>();//List for the correct answer tally
    List<Object> DeathBoxClone = new List<Object>();//List for the incorrect answer tally

    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(-12.127f, 1.55f, -4.684f);  //Set the view to main camera
        DialogUI.Instance.Hide();//Hide the hint dialog box
        StartCoroutine(ExampleCoroutine());
        Location = 0;
        LocationDeath = 1;
        Tick.GetComponent<Renderer>().enabled = false; // Hide the tick on the operation screen
        Cross.GetComponent<Renderer>().enabled = false; //Hide the cross the operation screen
    }

    // Update is called once per frame

    public void FunctionForAddition()
    {
        Canvas.SetActive(true);
        calculateFn("Add");
        Debug.Log(" Function Addition");
    }

    public void FunctionForSubtraction()
    {
        Canvas.SetActive(true);
        calculateFn("Subtract");
        Debug.Log(" Function Subtraction");
    }

    public void FunctionForMultiplication()
    {
        Canvas.SetActive(true);
        calculateFn("Multiply");
        Debug.Log(" Function Multiplication");
    }

    public void FunctionForDivision()
    {
        Canvas.SetActive(true);
        calculateFn("Divide");
        Debug.Log(" Function Division");
    }

    public void calculateFn(string operation) //Main calculation method for all operations
    {
        PrimeNum = Random.Range(1, 10);
        SecondNum = Random.Range(1, 10);
        RandomNum = Random.Range(1, 10);
        RandomNum2 = Random.Range(1, 10);

        if (PrimeNum - SecondNum < 0)
        {
            ValueNum = SecondNum;
            SecondNum = PrimeNum;
            PrimeNum = ValueNum;
        }

        if (operation == "Add")
        {
            RequestFinal = PrimeNum + SecondNum;
            VarSymbol = "Add";
        }

        if (operation == "Subtract")
        {
            RequestFinal = PrimeNum - SecondNum;
            VarSymbol = "Subtract";
        }

        if (operation == "Multiply")
        {
            RequestFinal = PrimeNum * SecondNum;
            VarSymbol = "Multiply";
        }

        if (operation == "Divide")
        {
            RequestFinal = PrimeNum / SecondNum;
            VarSymbol = "Divide";
        }

        if (RandomNum - RandomNum2 < 0)
        {
            RandomNumber = RandomNum;
            RandomNum = RandomNum2;
            RandomNum2 = RandomNumber;
        }

        FirstNumber.text = PrimeNum.ToString();
        SecondNumber.text = SecondNum.ToString();

        if (VarSymbol == "Add") { Symbol.text = "+"; }
        if (VarSymbol == "Subtract") { Symbol.text = "-"; }
        if (VarSymbol == "Multiply") { Symbol.text = "x"; }
        if (VarSymbol == "Divide") { Symbol.text = "/"; }

        Temporary = Random.Range(1, 6);
        if (Temporary == 1)
        {
            Answer1.text = RequestFinal.ToString(); Answer2.text = RandomNum.ToString(); Answer3.text = RandomNum2.ToString();
        }
        if (Temporary == 2)
        {
            Answer1.text = RequestFinal.ToString(); Answer2.text = RandomNum2.ToString(); Answer3.text = RandomNum.ToString();
        }
        if (Temporary == 3)
        {
            Answer1.text = RandomNum.ToString(); Answer2.text = RequestFinal.ToString(); Answer3.text = RandomNum2.ToString();
        }
        if (Temporary == 4)
        {
            Answer1.text = RandomNum.ToString(); Answer2.text = RandomNum2.ToString(); Answer3.text = RequestFinal.ToString();
        }
        if (Temporary == 5)
        {
            Answer1.text = RandomNum2.ToString(); Answer2.text = RequestFinal.ToString(); Answer3.text = RandomNum.ToString();
        }
        if (Temporary == 6)
        {
            Answer1.text = RandomNum2.ToString(); Answer2.text = RandomNum.ToString(); Answer3.text = RequestFinal.ToString();
        }
    }

    public void ReturnMenu()//Back button
    {
        Canvas.SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(-1.62f, 1.55f, -4.295f);
        Tick.GetComponent<Renderer>().enabled = false;
        Cross.GetComponent<Renderer>().enabled = false;
       
    }

    public void Answer_1()//Different answer eggs
    {
        if (Answer1.text == RequestFinal.ToString())
        {
            Correct();
        }
        else
        {
            InCorrect();
        }
    }

    public void Answer_2()
    {
        if (Answer2.text == RequestFinal.ToString())
        {
            Correct();
        }
        else
        {
            InCorrect();
        }
    }

    public void Answer_3()
    {
        if (Answer3.text == RequestFinal.ToString())
        {
            Correct();
        }
        else
        {
            InCorrect();
        }
    }

    public void Correct()//The tally system for the correct answers
    {
        Debug.Log("Is correct");
        Location = Location + 1;
        CorrectBox.text = RequestFinal.ToString();
        ScoreBoxClone.Add(Instantiate(ScoreBox, new Vector3(4.19f + (Location + 1) * 0.5f, 3.83f, 0.24f), Quaternion.identity));
        StartCoroutine(ExampleCoroutine());
        if (Location == 5)
        {
            Tick.GetComponent<Renderer>().enabled = true;
            
            var last = ScoreBoxClone[ScoreBoxClone.Count - 1];
            ScoreBoxClone.Remove(last);
            Destroy(last);
            
            var last2 = ScoreBoxClone[ScoreBoxClone.Count - 1];
            ScoreBoxClone.Remove(last2);
            Destroy(last2);
           
            var last3 = ScoreBoxClone[ScoreBoxClone.Count - 1];
            ScoreBoxClone.Remove(last3);
            Destroy(last3);
            
            var last4 = ScoreBoxClone[ScoreBoxClone.Count - 1];
            ScoreBoxClone.Remove(last4);
            Destroy(last4);
           
            var last5 = ScoreBoxClone[ScoreBoxClone.Count - 1];
            ScoreBoxClone.Remove(last5);
            Destroy(last5);
            
            Location = 0;
            
        }
    }

    public void InCorrect() //The tally system for the incorrect answers
    {
        Debug.Log("Is incorrect");
        LocationDeath = LocationDeath + 1;

        DeathBoxClone.Add(Instantiate(DeathBox, new Vector3(12.51f + (LocationDeath - 1) * -0.5f, 3.83f, 0.24f), Quaternion.identity));

        if (LocationDeath == 6)
        {

            Cross.GetComponent<Renderer>().enabled = true;

            var Last = DeathBoxClone[DeathBoxClone.Count - 1];
            DeathBoxClone.Remove(Last);
            Destroy(Last);

            var Last2 = DeathBoxClone[DeathBoxClone.Count - 1];
            DeathBoxClone.Remove(Last2);
            Destroy(Last2);

            var Last3 = DeathBoxClone[DeathBoxClone.Count - 1];
            DeathBoxClone.Remove(Last3);
            Destroy(Last3);

            var Last4 = DeathBoxClone[DeathBoxClone.Count - 1];
            DeathBoxClone.Remove(Last4);
            Destroy(Last4);

            var Last5 = DeathBoxClone[DeathBoxClone.Count - 1];
            DeathBoxClone.Remove(Last5);
            Destroy(Last5);

            LocationDeath = 1;
        }
    }

    IEnumerator ExampleCoroutine()//Sets a waiting timer
    {
        yield return new WaitForSeconds(1);
        CorrectBox.text = " ";
        calculateFn(VarSymbol);
    }
}