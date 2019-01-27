using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGeneration : MonoBehaviour {
    private List<Transform> planets = new List<Transform>();

	// Use this for initialization
	void Start () {
        Transform solarCenter = GameObject.Find("SolarCenter").transform;
        generateSun(solarCenter);
        generatePlanets(solarCenter);
	}

    private void generateSun(Transform solarCenter) {
        GameObject sun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sun.transform.position = new Vector3(0, 0, 0);
        sun.transform.SetParent(solarCenter);
        float size = getRandomFromRange(SolarSettings.SUN_MIN_SIZE, SolarSettings.SUN_MAX_SIZE);
        Debug.Log("sunSize: " + size);
        sun.transform.localScale = new Vector3(size, size, size);
        sun.name = "Sun";
    }

    private void generatePlanets(Transform solarCenter) {
        int amountOfPlanets = generateAmountOfPlanets();
        float distanceFromSun = 40f;
        Debug.Log(amountOfPlanets);
        for (int i = 0; i < amountOfPlanets; i++) {
            distanceFromSun = generatePlanet(solarCenter, distanceFromSun, i);
        }
    }

    private float generatePlanet(Transform solarCenter, float distance, int currentPlanet) {
        GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planet.transform.position = new Vector3(0, 0, distance);
        planet.transform.parent = solarCenter;
        float size = getRandomFromRange(SolarSettings.PLANET_MIN_SIZE, SolarSettings.PLANET_MAX_SIZE);
        Debug.Log("planetSize: " + size);
        planet.transform.localScale = new Vector3(size, size, size);
        planet.name = "Planet"+currentPlanet;

        float angle = getRandomFromRange(0, 360);

        planet.transform.RotateAround(planet.transform.parent.position, new Vector3(0, 1f, 0), angle);

        TrailRenderer trail = planet.AddComponent(typeof(TrailRenderer)) as TrailRenderer;
        trail.time = 30;
        Color color = Color.red;
        if(distance >= 80 && distance < 150) {
            color = Color.green;
        } else if (distance >= 150)
        {
            color = Color.blue;
        }
        trail.material.color = color;
        trail.startWidth = 1f;
        trail.endWidth = 0.1f;
        trail.enabled = true;

        planets.Add(planet.transform);
        return distance += (20f + (size / 2));
    }

    private int generateAmountOfPlanets() {
        System.Random r = new System.Random();
        return r.Next(SolarSettings.PLANETS_MIN, SolarSettings.PLANETS_MAX);
    }

    private float getRandomFromRange(float min, float max) {
        return (float) Math.Round(UnityEngine.Random.Range(min, max));
    }

    private void Update() {
        float i = 1.0f;
        foreach (Transform planet in planets) {
            planet.RotateAround(planet.parent.position, new Vector3(0, 1f, 0), (5 * (1 / i)) * Time.deltaTime);
            i += 0.2f ;
        }
    }

}
