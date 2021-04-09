using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public IcoBoss boss;
    public int canonDmg = 30000;
    public List<EndZone> zones = new List<EndZone>();
    public List<GameObject> beams = new List<GameObject>();


    void Update()
    {
        foreach (var zone in zones)
        {
            if (!zone.active)
            {
                return;
            }
        }
        
        foreach (var beam in beams)
        {
            beam.SetActive(true);
            StartCoroutine(SwitchOffBeamAfterTime(beam));
        }
        
        boss.TakeDamage(canonDmg);

        foreach (var zone in zones)
        {
            zone.active = false;
            zone.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    IEnumerator SwitchOffBeamAfterTime(GameObject beam)
    {
        yield return new WaitForSeconds(2);
        beam.SetActive(false);
    }
}
