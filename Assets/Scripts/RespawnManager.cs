using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private int nb_monsters;
    [SerializeField] private int nb_monsters_wave;
    [SerializeField] private int nb_monsters_wave_old;

    [SerializeField] private GameObject newWavePopup;

    [SerializeField] private int nb_spawns;
    [SerializeField] private GameObject monster1;

    [SerializeField] private GameObject monster2;

    [SerializeField] private GameObject monster3;

    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    [SerializeField] private GameObject spawn3;
    [SerializeField] private GameObject spawn4;
    [SerializeField] private GameObject spawn5;
    [SerializeField] private GameObject spawn6;

    [SerializeField] private float gap;




    private GameObject[] spawns = new GameObject[6];

    [System.Obsolete]
    void Start()
    {
        nb_monsters = 0;


        newWavePopup.active = false;

        spawns[0] = spawn1;
        spawns[1] = spawn2;
        spawns[2] = spawn3;
        spawns[3] = spawn4;
        spawns[4] = spawn5;
        spawns[5] = spawn6;


        StartCoroutine(MonsterSpawn(0));

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

        if ((num_wave == 11) && (nb_monsters == 0))
        {

            SceneManager.LoadScene("LoseMenu");
        }

        if (num_wave <= 10)
        {
            while (nb_monsters_wave != nb_monsters)
            {
                //Debug.Log(nb_monsters);
                if (nb_monsters_wave - nb_monsters == 1)
                {

                    int n1 = Random.Range(1, nb_spawns + 1);
                    //Debug.Log("n1 = " + n1);
                    createMonster(n1);
                    //Debug.Log("create monster");

                    yield return new WaitForSeconds(4);
                    //yield return null;

                }
                else if (nb_monsters_wave - nb_monsters >= 2)
                {

                    int n1 = Random.Range(1, nb_spawns + 1);
                    //Debug.Log("n1 = " + n1);
                    int n2 = Random.Range(1, nb_spawns + 1);

                    while (n1 == n2)
                    {
                        n2 = Random.Range(1, nb_spawns + 1);
                    }
                    //Debug.Log("n2 = " + n2);
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
        Vector3 pos = new Vector3(pos_spawn.x, 0, pos_spawn.z);

        Vector3 ecart = new Vector3(0, gap, 0);

        int n = Random.Range(1, 4);

        if(n == 1)
        {
            Instantiate(monster1, pos, Quaternion.identity);
        } else if (n == 2)
        {
            Instantiate(monster2, pos+ecart, Quaternion.identity);
        } else
        {
            Instantiate(monster3, pos, Quaternion.identity);
        }

        //Debug.Log(pos_spawn);
        


        nb_monsters += 1;



    }

}
  