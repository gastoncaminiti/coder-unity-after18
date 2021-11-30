using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroupController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> unitsPlayer;
    [SerializeField] private List<GameObject> unitsEnemy;

    //DESING DATA
    [SerializeField] private int playerResource = 0;
    [SerializeField] private int minSecond = 1;
    [SerializeField] private int maxSecond = 3;

    //EVENTS
    public static event Action<int> onResource;
    public static event Action<int> onPlayerUnits;


    public static int indexPlayer = 0;

    void Start()
    {
        StartCoroutine(GenerateResource());
        UnitController.onFinishMove += OnFinishMoveHandler;
    }

    private void OnFinishMoveHandler()
    {
        GroupController.indexPlayer++;
    }

    IEnumerator GenerateResource()
    {
        while (true)
        {
            int rngSecond = UnityEngine.Random.Range(minSecond, maxSecond);
            yield return new WaitForSeconds(rngSecond);
            playerResource++;
            onResource?.Invoke(playerResource);
        }
    }


   public void CreatePlayerUnit()
    {
        if (playerResource > 0)
        {
            GameObject newUnit = Instantiate(unitsPlayer[0], new Vector3(-10, 0, -10), unitsPlayer[0].transform.rotation);
            newUnit.GetComponent<UnitController>().SetPositionList(unitsPlayer.Count);
            unitsPlayer.Add(newUnit);
            playerResource--;
            onResource?.Invoke(playerResource);
            onPlayerUnits?.Invoke(unitsPlayer.Count);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
