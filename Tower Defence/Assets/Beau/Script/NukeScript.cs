using System.Collections;
using UnityEngine;

public class NukeScript : MonoBehaviour
{
    public Material normal, nuke; //skyboxes
    GameObject explosion, armsPlayer, nukeCam, volume, faceCube;
    Ability abilScript;
    public float explosionDuration, waitForInvis;
    public AudioSource explosionSound;
    private void Start()
    {
        normal = RenderSettings.skybox;
        explosion = GameObject.Find("Explosion");
        abilScript = GameObject.Find("Player").GetComponent<Ability>();
        volume = GameObject.Find("NukeShit").transform.GetChild(0).gameObject;
        faceCube = GameObject.Find("Camera").transform.GetChild(1).gameObject;
        explosionSound.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        Kaboom();
    }
    public void Kaboom()
    {
        foreach(Transform child in explosion.transform)
        {
            child.gameObject.SetActive(true);
            child.GetComponent<ParticleSystem>().Play();
        }
        StartCoroutine(WaitForInvis());
        volume.SetActive(true);
        StartCoroutine(End());
    }
    IEnumerator WaitForInvis()
    {
        yield return new WaitForSeconds(waitForInvis);
        abilScript.Boem();
        this.GetComponent<MeshRenderer>().enabled = !enabled;
        RenderSettings.skybox = nuke;
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(explosionDuration);
        volume.GetComponent<CapsuleCollider>().radius = 0;
        volume.SetActive(false);
        faceCube.SetActive(false);
        RenderSettings.skybox = normal;
        Destroy(this.gameObject);
    }
}
