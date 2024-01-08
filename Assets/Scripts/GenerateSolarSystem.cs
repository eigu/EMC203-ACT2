using UnityEngine;

public class GenerateSolarSystem : MonoBehaviour
{
    public GameObject _sunPrefab;
    public GameObject _planetPrefab;
    public GameObject _moonPrefab;

    private GameObject _sun;
    private GameObject _planet;
    private GameObject _moon;

    private int _numberOfPlanets;

    private void Start()
    {
        _numberOfPlanets = Random.Range(1, 6);

        GenerateSun();
        GeneratePlanet();
    }

    private void GenerateSun()
    {
        _sun = Instantiate(_sunPrefab, Vector3.zero, Quaternion.identity);
    }

    private void GeneratePlanet()
    {
        Vector3 _previousPlanetPosition = _sun.transform.position;

        for (int i = 0; i < _numberOfPlanets; i++)
        {
            Vector3 _planetPosition = CalculateObjectPosition(_previousPlanetPosition, 10, 20);

            _planet = Instantiate(_planetPrefab, _planetPosition, Quaternion.identity, _sun.transform);

            _previousPlanetPosition = _planetPosition;

            if (Random.Range(0f, 1f) < 0.3f) GenerateMoon();
        }
    }

    private void GenerateMoon()
    {
        Vector3 _moonPosition = CalculateObjectPosition(_planet.transform.position, 3, 6);

        _moon = Instantiate(_moonPrefab, _moonPosition, Quaternion.identity, _planet.transform);
    }

    private Vector3 CalculateObjectPosition(Vector3 _previousPosition, float _minDistance, float _maxDistance)
    {
        float distance = Random.Range(_minDistance, _maxDistance);

        float _posX = _previousPosition.x + distance;
        float _posY = _previousPosition.y + distance;
        float _posZ = _previousPosition.z + distance;

        return new Vector3(_posX, _posY, _posZ);
    }
}
