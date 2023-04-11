using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UmbraEvolution.UmbraMazeMagician;
public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    public GameObject endScreen;
    private GameObject mazeGenerator;
    private GameObject startTile;
    private void Awake()
    {
        StartCoroutine(CreateMaze());
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    IEnumerator CreateMaze()
    {
        FindObjectOfType<MazeGenerator>().GenerateNewMaze();
        yield return new WaitForSeconds(1.2f);

        startTile = GameObject.FindGameObjectWithTag("StartTile");
        Instantiate(player, startTile.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        endScreen.SetActive(true);
    }
}
