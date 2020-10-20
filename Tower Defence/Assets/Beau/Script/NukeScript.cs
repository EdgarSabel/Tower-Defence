using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class NukeScript : MonoBehaviour
{
    GameObject explosion, armsPlayer, nukeCam, volume;
    Ability abilScript;
    public float explosionDuration, waitForDmg;
    public AudioSource explosionSound;
    private void Start()
    {
        explosion = GameObject.Find("Explosion");
        abilScript = GameObject.Find("Player").GetComponent<Ability>();
        volume = GameObject.Find("NukeShit").transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        Kaboom();
        StartCoroutine(Boem());
    }
    IEnumerator Boem()
    {
        yield return new WaitForSeconds(waitForDmg);
        this.GetComponent<MeshRenderer>().enabled = !enabled;
        abilScript.Boem();
    }
    public void Kaboom()
    {
        foreach(Transform child in explosion.transform)
        {
            child.gameObject.SetActive(true);
            child.GetComponent<ParticleSystem>().Play();
        }
        volume.SetActive(true);
        //explosionSound.Play();
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(explosionDuration);
        volume.SetActive(false);
        Destroy(this.gameObject);
    }
}
