using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hitWallSound;
    [SerializeField] private AudioClip hitEnemySound;

    private Camera _camera;

    public float sphereX = 1;
    public float sphereY = 1;
    public float sphereZ = 1;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(
            _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    soundSource.PlayOneShot(hitEnemySound);
                    EventManager.TriggerEvent(GameEvent.ENEMY_HIT);
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                    soundSource.PlayOneShot(hitWallSound);
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale = new Vector3(sphereX, sphereY, sphereZ);
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnGUI()
    {
        int size = 16;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
