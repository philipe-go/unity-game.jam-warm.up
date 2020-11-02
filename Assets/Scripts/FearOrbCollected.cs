using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearOrbCollected : MonoBehaviour
{
    public float GlowTimer;
    GameManager _gm;
    [SerializeField] Material _rendMat;

    void Start()
    {
        _gm = GameManager.instance;
        StartCoroutine(Glow(GlowTimer));
    }

    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gm.OrbCollected(5);
            Destroy(gameObject);
        }
    }

    IEnumerator Glow(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            _rendMat.SetColor("_BaseColor", Color.black);
            yield return new WaitForSeconds(time);
            _rendMat.SetColor("_BaseColor", Color.yellow);
        }
    }
}
