using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int XP;
    public int current_level;
    public int requiered_xp;

    public GameObject UI;
    private GameObject popupWindow;

    private int num_upgrade1;
    private int num_upgrade2;
    private int num_upgrade3;

    private GameObject upgrade1;
    private GameObject upgrade2;
    private GameObject upgrade3;
    private readonly GameObject[] buttons1 = new GameObject[10];

    private readonly GameObject[] buttons2 = new GameObject[10];

    private readonly GameObject[] buttons3 = new GameObject[10];


    // Start is called before the first frame update
    void Start()
    {
        XP = 0;
        current_level = 0;
        requiered_xp = 5;

        UI = GameObject.Find("NewLevel");



        /*
        GameObject button1 = GameObject.Find("Button1");
        GameObject button2 = GameObject.Find("Button2");
        GameObject button3 = GameObject.Find("Button3");
       */
        /*
        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            name = "upgrade" + j + "button";
            buttons1[i] = GameObject.Find(name);
            Debug.Log(buttons1[i]);

            //buttons1[i].SetActive(false);
            //buttons1[i].name = "upgrade" + j + "button";
        }
        */

        /*
        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            name = "upgrade" + j + "button" + 2;
            buttons2[i] = GameObject.Find(name);
            Debug.Log(buttons2[i]);
            //buttons1[i].name = "upgrade" + j + "button";
        }

        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            name = "upgrade" + j + "button" + 3;
            buttons3[i] = GameObject.Find(name);
            Debug.Log(buttons1[i]);
            //buttons1[i].name = "upgrade" + j + "button";
        }
        */

        UI.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateXP(int xp)
    {
        Debug.Log("update xp");
        XP += xp;

        if (XP >= requiered_xp)
        {
            current_level += 1;
            requiered_xp = requiered_xp + (int)Mathf.Pow(requiered_xp, 2);

            //choix des amÃ©liorations
            num_upgrade1 = Random.Range(1, 11);
            num_upgrade2 = Random.Range(1, 11);
            while (num_upgrade1 == num_upgrade2)
            {
                num_upgrade2 = Random.Range(1, 11);
            }
            num_upgrade3 = Random.Range(1, 11);
            while (num_upgrade3 == num_upgrade2 || num_upgrade3 == num_upgrade1)
            {
                num_upgrade3 = Random.Range(1, 11);
            }

            //apparition de la fenetre popup
            //popupWindow = Instantiate(UI, new Vector3(0,0,0), Quaternion.identity);
            //UI.SetActive(true);
            StartCoroutine(CreatePopup(num_upgrade1, num_upgrade2, num_upgrade3));

            /*
            string name1 = "upgrade" + num_upgrade1 + "button";
            string name2 = "upgrade" + num_upgrade2 + "button";
            string name3 = "upgrade" + num_upgrade3 + "button";
            */

            /*
            Instantiate(buttons[num_upgrade1 -1], new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(buttons[num_upgrade2 - 1], new Vector3(0, 2, 0), Quaternion.identity);
            Instantiate(buttons[num_upgrade3 - 1], new Vector3(0, 3, 0), Quaternion.identity);
            */

            /*
            for (int i = 0; i < 10; i++)
            {
                int j = i + 1;
                name = "upgrade" + j + "button";
                buttons1[i] = GameObject.Find(name);
                Debug.Log(buttons1[i]);
                //buttons1[i].name = "upgrade" + j + "button";
            }

            for (int i = 0; i < 10; i++)
            {
                int j = i + 1;
                name = "upgrade" + j + "button" + 2;
                buttons2[i] = GameObject.Find(name);
                Debug.Log(buttons2[i]);
                //buttons1[i].name = "upgrade" + j + "button";
            }

            for (int i = 0; i < 10; i++)
            {
                int j = i + 1;
                name = "upgrade" + j + "button" + 3;
                buttons3[i] = GameObject.Find(name);
                Debug.Log(buttons1[i]);
                //buttons1[i].name = "upgrade" + j + "button";
            }
            */


            //GameObject button1 = GameObject.Find("Button1");
            //GameObject button2 = GameObject.Find("Button2");
            //GameObject button3 = GameObject.Find("Button3");


            //string name1 = "upgrade" + num_upgrade1 + "button";
            //string name2 = "upgrade" + num_upgrade2 + "button";
            //string name3 = "upgrade" + num_upgrade3 + "button";

            //Debug.Log(num_upgrade1);
            //Debug.Log(num_upgrade2);
            //Debug.Log(num_upgrade3);
            //Debug.Log(name1 + ' ' + name2 + ' ' + name3);

            //upgrade1 = GameObject.Find("upgrade" + num_upgrade1 + "button");
            //upgrade2 = GameObject.Find(name2);
            //upgrade3 = GameObject.Find(name3);

            //Debug.Log(upgrade1);


            /*
            Debug.Log(buttons1[num_upgrade1 - 1]);


            buttons1[0].SetActive(false);
            buttons1[1].SetActive(false);
            buttons1[2].SetActive(false);
            buttons1[3].SetActive(false);
            buttons1[4].SetActive(false);
            buttons1[5].SetActive(false);
            buttons1[6].SetActive(false);
            buttons1[7].SetActive(false);
            buttons1[8].SetActive(false);
            buttons1[9].SetActive(false);
            */
            /*
            buttons2[0].SetActive(false);
            buttons2[1].SetActive(false);
            buttons2[2].SetActive(false);
            buttons2[3].SetActive(false);
            buttons2[4].SetActive(false);
            buttons2[5].SetActive(false);
            buttons2[6].SetActive(false);
            buttons2[7].SetActive(false);
            buttons2[8].SetActive(false);
            buttons2[9].SetActive(false);

            buttons3[0].SetActive(false);
            buttons3[1].SetActive(false);
            buttons3[2].SetActive(false);
            buttons3[3].SetActive(false);
            buttons3[4].SetActive(false);
            buttons3[5].SetActive(false);
            buttons3[6].SetActive(false);
            buttons3[7].SetActive(false);
            buttons3[8].SetActive(false);
            buttons3[9].SetActive(false);
            */


            //buttons1[num_upgrade1 - 1].SetActive(true);

            /*
            buttons2[num_upgrade2 - 1].SetActive(true);
            buttons3[num_upgrade3 - 1].SetActive(true);*/

            //Button upgrade1 = (Button)button1.GetComponent(name1);
            //upgrade1.enabled = !upgrade1.enabled;

            //Button upgrade2 = (Button)button2.GetComponent(name2);
            //upgrade2.enabled = !upgrade2.enabled;

            //Button upgrade3 = (Button)button3.GetComponent(name3);
            //upgrade3.enabled = !upgrade3.enabled;


        }

    }

    public IEnumerator CreatePopup(int num1, int num2, int num3)
    {
        UI.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        UI.SetActive(false);
        /*
        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            name = "upgrade" + j + "button";
            buttons1[i] = GameObject.Find(name);
            Debug.Log(buttons1[i]);

            buttons1[i].active = false;
            //buttons1[i].name = "upgrade" + j + "button";
        }

        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            name = "upgrade" + j + "button" + 2;
            buttons2[i] = GameObject.Find(name);
            Debug.Log(buttons2[i]);

            buttons2[i].active = false;
            //buttons1[i].name = "upgrade" + j + "button";
        }

        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            name = "upgrade" + j + "button" + 3;
            buttons3[i] = GameObject.Find(name);
            Debug.Log(buttons3[i]);

            buttons3[i].active = false;
            //buttons1[i].name = "upgrade" + j + "button";
        }

        /*
        buttons1[0].SetActive(false);
        buttons1[1].SetActive(false);
        buttons1[2].SetActive(false);
        buttons1[3].SetActive(false);
        buttons1[4].SetActive(false);
        buttons1[5].SetActive(false);
        buttons1[6].SetActive(false);
        buttons1[7].SetActive(false);
        buttons1[8].SetActive(false);
        buttons1[9].SetActive(false);
        */

        /*
        buttons1[num1 - 1].active = true;
        buttons2[num2 - 1].active = true;

        buttons3[num3 - 1].active = true;
        */


    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("XP"))
        {
            UpdateXP(5);
            //Debug.Log("Gain 5 xp");
            //Debug.Log(XP);
            //Debug.Log(current_level);
        }

    }
}
