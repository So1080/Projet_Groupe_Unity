using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private int nb_monsters;
    [SerializeField] private int nb_monsters_wave;
    [SerializeField] private int nb_monsters_wave_old;

    [SerializeField] private GameObject newWavePopup;

    [SerializeField] private int nb_spawns;
    [SerializeField] private GameObject monster;


    private GameObject[] spawns = new GameObject[6];

    void Start()
    {
        nb_monsters = 0;

        //spawns = new GameObject[nb_spawns];

        newWavePopup = GameObject.Find("NewWavePopup");

        newWavePopup.active = false;

        for (int i = 0; i < nb_spawns; i++)
        {
            int j = i + 1;
            name = "spawn" + j;
            spawns[i] = GameObject.Find(name);
            Debug.Log(GameObject.Find(name));

            Vector3 pos_spawn = spawns[i].transform.position;

            Debug.Log(pos_spawn);
        }

        StartCoroutine(MonsterSpawn(0));

        /*
        if (nb_monsters == nb_monsters_wave)
        {
            //suite de fibonaci
            int nb_monsters_wave_new = nb_monsters_wave + nb_monsters_wave_old;
            nb_monsters_wave_old = nb_monsters_wave;
            nb_monsters_wave = nb_monsters_wave_new;

            StartCoroutine(MonsterSpawn());
        }
        */
    }


    void Update()
    {

    }



    public IEnumerator MonsterSpawn(int num_wave)
    {


        if (num_wave == 0)
        {
            yield return new WaitForSeconds(4);
        }

        if (num_wave <= 10)
        {
            while (nb_monsters_wave != nb_monsters)
            {
                Debug.Log(nb_monsters);
                if (nb_monsters_wave - nb_monsters == 1)
                {

                    int n1 = Random.Range(1, nb_spawns + 1);
                    Debug.Log("n1 = " + n1);
                    createMonster(n1);
                    //Debug.Log("create monster");

                    yield return new WaitForSeconds(4);
                    //yield return null;

                }
                else if (nb_monsters_wave - nb_monsters >= 2)
                {

                    int n1 = Random.Range(1, nb_spawns + 1);
                    Debug.Log("n1 = " + n1);
                    int n2 = Random.Range(1, nb_spawns + 1);

                    while (n1 == n2)
                    {
                        n2 = Random.Range(1, nb_spawns + 1);
                    }
                    Debug.Log("n2 = " + n2);
                    createMonster(n1);
                    //Debug.Log("creation monstre");
                    createMonster(n2);
                    //Debug.Log("creation monstre");


                    yield return new WaitForSeconds(4);
                    //yield return null;
                }
            }



            yield return new WaitForSecondsRealtime(2);

            if (nb_monsters == nb_monsters_wave)
            {
                //suite de fibonaci
                int nb_monsters_wave_new = nb_monsters_wave + nb_monsters_wave_old;
                nb_monsters_wave_old = nb_monsters_wave;
                nb_monsters_wave = nb_monsters_wave_new;
                nb_monsters = 0;

            }

            StartCoroutine(CreateNewWavePopup());
            StartCoroutine(MonsterSpawn(num_wave + 1));
            yield return null;
        }

        else
        {
            yield return null;
        }



    }

    public IEnumerator CreateNewWavePopup()
    {

        newWavePopup.active = true;
        yield return new WaitForSecondsRealtime(3);
        newWavePopup.active = false;

    }

    public void createMonster(int num_spawn)
    {
        Vector3 pos_spawn = spawns[num_spawn - 1].transform.position;

        Debug.Log(pos_spawn);
        Instantiate(monster, pos_spawn, Quaternion.identity);


        nb_monsters += 1;



    }

}



//POUBELLE


/*
        if (nb_monsters < nb_monsters_wave)
        {
            Debug.Log("monstre");
            yield return new WaitForSeconds(2);
            Debug.Log("monstre");
        }

         */

/*
if (nb_monsters < nb_monsters_wave)
{
    int n1 = Random.Range(1, nb_spawns + 1);

    if (nb_monsters_wave - nb_monsters >= 2)
    {
        int n2 = Random.Range(1, nb_spawns + 1);
        while (n1 == n2)
        {
            n2 = Random.Range(1, nb_spawns + 1);
        }
        StartCoroutine(Create2Monsters(n1, n2));
        nb_monsters += 2;
    } else
    {
        StartCoroutine(CreateMonster(n1));
        nb_monsters += 1;
    }

}
*/
//Debug.Log(nb_monsters);
//player = GameObject.FindGameObjectWithTag("Player");

/*
if (player.transform.position.y < 0 || Input.GetKeyDown(KeyCode.R))
{
    Debug.Log("Balle remise au dÃ©part");
    player.transform.position = playerSpawn;
}
*/

/*
int n = checkMonster();
if (n == 1)
{
    int n1 = Random.Range(1, nb_spawns + 1);
    StartCoroutine(CreateMonster(n1));
    nb_monsters += 1;
} else if (n == 2)
{
    int n1 = Random.Range(1, nb_spawns + 1);
    int n2 = Random.Range(1, nb_spawns + 1);
    while (n1 == n2)
    {
        n2 = Random.Range(1, nb_spawns + 1);
    }
    StartCoroutine(Create2Monsters(n1,n2));
    nb_monsters += 2;
}*/




/*
private int checkMonster()
{
    if (nb_monsters == nb_monsters_wave)
    {
        return 0;
    } else if (nb_monsters_wave - nb_monsters >= 2)
    {
        return 2;
    }
    else
    {
        return 1;
    }
}
*/
  