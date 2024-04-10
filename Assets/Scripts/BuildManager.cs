using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Set uo for singleton memthod

    public static BuildManager instance;

    // This awake runs befgor start
    // sets the static instance to this gameObject
    private void Awake()
    {

        instance = this;

    }

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    // Basically a small function that returns if turretToBuild is null or not
    public bool CanBuild { get { return turretToBuild != null; } }

    // Quick function that the system uses to tell if the player has enough money to get the currently selected turret 
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node someNode)
    {

        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        // Build a turret
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, someNode.GetBuildPosition(), Quaternion.identity);
        someNode.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, someNode.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret built! Spent " + turretToBuild.cost + " dabloons. Player has " + PlayerStats.money + " left!");

    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
