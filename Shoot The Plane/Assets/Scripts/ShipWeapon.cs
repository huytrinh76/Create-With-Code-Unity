using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private List<Transform> _listFirePoint;
    [SerializeField] private List<ParticleSystem> _listFirePointEffect;
    private float fire_rate_weapon = 0.15f;
    private IEnumerator SpawnBullet()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = Quaternion.Euler(0f, 0f, 0f); 
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet3.position = _listFirePoint[2].position;
        bullet3.rotation = Quaternion.Euler(0f, 0f, 2f); 
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet4.position = _listFirePoint[3].position;
        bullet4.rotation = Quaternion.Euler(0f, 0f, -2f);

        Transform effect1 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        effect1.position = _listFirePoint[0].position;
        effect1.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform effect2 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        effect2.position = _listFirePoint[1].position;
        effect2.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform effect3 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        effect3.position = _listFirePoint[2].position;
        effect3.rotation = Quaternion.Euler(0f, 0f, 1f);
        Transform effect4 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        effect4.position = _listFirePoint[3].position;
        effect4.rotation = Quaternion.Euler(0f, 0f, -1f);

        bullet1.GetComponent<Bullet>().Activate();
        effect1.GetComponent<ParticleSystem>().Play();
        bullet2.GetComponent<Bullet>().Activate();
        effect2.GetComponent<ParticleSystem>().Play();
        bullet3.GetComponent<Bullet>().Activate();
        effect3.GetComponent<ParticleSystem>().Play();
        bullet4.GetComponent<Bullet>().Activate();
        effect4.GetComponent<ParticleSystem>().Play();
        yield return null;
    }

    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(fire_rate_weapon);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(StartFire());
    }
}