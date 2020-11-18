using UnityEngine;

public class EnemyManager : MonoBehaviour{
    public GameObject evilCube;
    public Vector3 spawnPos;

    private void Start(){
        Instantiate(evilCube,spawnPos, Quaternion.identity);
    }
}