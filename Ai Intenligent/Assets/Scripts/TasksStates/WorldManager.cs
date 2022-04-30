using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DoorInformation
{
    public string name;
    public Transform transform;
    public bool open;
    public bool block;
}

[System.Serializable]
public struct WaypointInformation
{
    public string name;
    public Transform transform;
}

public class WorldManager : MonoBehaviour
{
    public DoorInformation[] doors;
    public WaypointInformation[] waypoints;

    public bool IsDoorOpen(string doorname)
    {
        foreach (DoorInformation door in doors)
        {
            if (door.name == doorname)
            {
                return door.open;
            }
        }
        return false;
    }

    public bool IsDoorBlock(string doorname)
    {
        foreach (DoorInformation door in doors)
        {
            if (door.name == doorname)
            {
                return door.block;
            }
        }
        return false;
    }

    public void OpenDoor(string doorname)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if ((doors[i].name == doorname) && (!doors[i].open))
            {
                doors[i].open = true;
                doors[i].transform.Translate(Vector3.up * 5);
                break;
            }
        }
    }

    public Vector3 GetWaypointPosition(string wpname)
    {
        foreach (WaypointInformation wp in waypoints)
        {
            if(wp.name == wpname)
            {
                return wp.transform.position;
            }
        }
        return Vector3.zero;
    }

    public void BargeDoor(string doorname)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if ((doors[i].name == doorname) && (!doors[i].open))
            {
                float numb = Random.Range(0, 1);
                Debug.Log(numb);
                if(numb >= 0.5f)
                {
                    doors[i].open = true;
                    doors[i].transform.Translate(Vector3.up * 5);
                }
            }
        }
    }
}
